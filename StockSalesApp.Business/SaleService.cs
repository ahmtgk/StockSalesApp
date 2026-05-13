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
    public class SaleService
    {
        private readonly SaleRepository _saleRepo = new SaleRepository();
        private readonly ProductRepository _productRepo = new ProductRepository();
        private readonly StockRepository _stockRepo = new StockRepository();
       
        // Satışı tamamlar — sepetteki tüm ürünleri kaydeder
        // Parametre olarak ne alır?
        // sale    = satışın genel bilgisi (kim yaptı, toplam tutar)
        // details = sepetteki ürünlerin listesi (hangi ürün, kaç adet, fiyatı)
        // Sırasıyla şunları yapar:
        // 1. Stok yeterliliğini kontrol eder
        // 2. Sales tablosuna satışı kaydeder
        // 3. SaleDetails tablosuna her ürünü kaydeder
        // 4. Her ürünün stok miktarını düşürür
        // 5. StockMovements tablosuna "OUT" hareketi ekler
        // Hata olursa hepsi geri alınır

        public void CompleteSale(Sale sale, List<SaleDetail> details)
        {
            if (details == null || details.Count == 0)
                throw new System.Exception("Sepet boş olamaz.");

            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();

                // Transaction: tüm işlemler tek bir paket gibi davranır
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // --- 1- Tüm ürünlerin stok kontrolü ---
                        // Önce hepsini kontrol et, sonra kaydetmeye başla.
                        // Eğer sırayla kontrol edip kaydetmeye başlarsak, ortada bir hata olursa bazı ürünler kaydedilmiş olurdu.
                        foreach (var detail in details)
                        {
                            var product = _productRepo.GetById(detail.ProductId);

                            if (product == null)
                                throw new System.Exception($"Ürün bulunamadı: ID {detail.ProductId}");

                            if (product.StockQuantity < detail.Quantity)
                                throw new System.Exception(
                                    $"'{product.Name}' ürünü için yeterli stok yok. " +
                                    $"Mevcut: {product.StockQuantity}, İstenen: {detail.Quantity}");
                        }

                        // --- 2- Sales tablosuna satış başlığını kaydet ---
                        // Dönen saleId'yi sonraki adımlarda kullanacağız
                        int saleId = _saleRepo.Add(sale, conn, transaction);

                        // --- Her sepet ürünü için ---
                        foreach (var detail in details)
                        {
                            // Güncel stok bilgisini tekrar al (az önce GetById yaptık ama döngü içinde tekrar almak daha güvenli)
                            var product = _productRepo.GetById(detail.ProductId);

                            // Detay satırına satış ID'sini yaz
                            detail.SaleId = saleId;

                            // 3- SaleDetails tablosuna bu ürünü kaydet
                            _saleRepo.AddDetail(detail, conn, transaction);

                            // 4- Products tablosunda stok miktarını düşür
                            int newStock = product.StockQuantity - detail.Quantity;
                            _productRepo.UpdateStock(detail.ProductId, newStock, conn, transaction);

                            // 5- StockMovements tablosuna "OUT" hareketi ekle
                            _stockRepo.Add(new StockMovement
                            {
                                ProductId = detail.ProductId,
                                Quantity = detail.Quantity,
                                MovementType = "OUT" // Satıldı = çıkış hareketi
                            }, conn, transaction);
                        }

                        // Tüm adımlar başarılıysa veritabanına kalıcı olarak yaz
                        transaction.Commit();
                    }
                    catch
                    {
                        // Herhangi bir adımda hata olursa hiçbir şey kaydedilmez
                        transaction.Rollback();
                        throw; // Hata mesajını UI'a ilet
                    }
                }
            }
        }

        // Tüm satışları listeler (rapor ekranı için)
        public List<Sale> GetAll()
        {
            return _saleRepo.GetAll();
        }

        public decimal GetTodayTotalAmount() => _saleRepo.GetTodayTotalAmount();
        public int GetTodaySaleCount() => _saleRepo.GetTodaySaleCount();
        public List<Sale> GetLast10() => _saleRepo.GetLast10();

        // Tarih aralığına göre satış raporu
        public List<Sale> GetByDateRange(DateTime start, DateTime end)
        {
            if (start > end)
                throw new Exception("Başlangıç tarihi bitiş tarihinden büyük olamaz.");

            return _saleRepo.GetByDateRange(start, end);
        }

        // En çok satılan ürünler raporu
        public List<TopProduct> GetTopProducts(DateTime start, DateTime end)
        {
            if (start > end)
                throw new Exception("Başlangıç tarihi bitiş tarihinden büyük olamaz.");

            return _saleRepo.GetTopProducts(start, end);
        }
    }
}
