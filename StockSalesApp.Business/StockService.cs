using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using StockSalesApp.DataAccess;
using StockSalesApp.Entities;

namespace StockSalesApp.Business
{
    public class StockService
    {
        private readonly StockRepository _stockRepo = new StockRepository();
        private readonly ProductRepository _productRepo = new ProductRepository();
        // Stok girişi yapar (ürün satın alındığında çağrılır)
        // StockMovements tablosuna kayıt atar
        // Products tablosundaki StockQuantity'yi artırır
        // İkisi aynı transaction içinde olur — biri başarısız olursa ikisi de geri alınır
        public void StockIn(int productId, int quantity)
        {
            if (quantity <= 0)
                throw new System.Exception("Giriş miktarı sıfırdan büyük olmalıdır.");

            // Ürün var mı kontrol et
            var product = _productRepo.GetById(productId);
            if (product == null)
                throw new System.Exception("Ürün bulunamadı.");

            // Transaction başlat: iki işlem ya ikisi birden olur ya da ikisi de olmaz
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Stok hareketi kaydını ekle (MovementType = "IN" = giriş)
                        _stockRepo.Add(new StockMovement
                        {
                            ProductId = productId,
                            Quantity = quantity,
                            MovementType = "IN"
                        }, conn, transaction);

                        // 2. Ürünün stok miktarını artır
                        int newStock = product.StockQuantity + quantity;
                        _productRepo.UpdateStock(productId, newStock, conn, transaction);

                        // Her iki işlem de başarılıysa veritabanına kalıcı olarak yaz
                        transaction.Commit();
                    }
                    catch
                    {
                        // Herhangi bir hata olursa her iki işlemi de geri al
                        transaction.Rollback();
                        throw; // Hatayı UI katmanına ilet, orada mesaj gösterilsin
                    }
                }
            }
        }
        // Stok çıkışı yapar (fire, kayıp, bozulma gibi durumlar için)
        public void StockOut(int productId, int quantity)
        {
            if (quantity <= 0)
                throw new Exception("Çıkış miktarı sıfırdan büyük olmalıdır.");

            var product = _productRepo.GetById(productId);
            if (product == null)
                throw new Exception("Ürün bulunamadı.");

            // Yeterli stok var mı kontrol et
            if (product.StockQuantity < quantity)
                throw new Exception(
                    $"Yetersiz stok. Mevcut stok: {product.StockQuantity}");

            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Stok hareketi ekle (OUT)
                        _stockRepo.Add(new StockMovement
                        {
                            ProductId = productId,
                            Quantity = quantity,
                            MovementType = "OUT"
                        }, conn, transaction);

                        // Stok miktarını düşür
                        int newStock = product.StockQuantity - quantity;
                        _productRepo.UpdateStock(productId, newStock, conn, transaction);

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        // Tüm stok hareketlerini getirir (rapor ekranı için)
        public List<StockMovement> GetAll()
        {
            return _stockRepo.GetAll();
        }
    }
}
