using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockSalesApp.DataAccess;
using StockSalesApp.Entities; 

namespace StockSalesApp.Business
{
    public class ProductService
    {
        private readonly ProductRepository _repo = new ProductRepository();
        // Ürün listesi ekranı için tüm ürünleri getirir
        public List<Product> GetAll()
        {
            return _repo.GetAll();
        }
        // Arama kutusundan çağrılır
        public List<Product> Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return _repo.GetAll(); // Arama boşsa tüm listeyi getir

            return _repo.Search(keyword);
        }
        // Satış ekranında barkod okutunca çağrılır
        public Product GetByBarcode(string barcode)
        {
            if (string.IsNullOrWhiteSpace(barcode))
                throw new System.Exception("Barkod boş olamaz.");

            var product = _repo.GetByBarcode(barcode);

            if (product == null)
                throw new System.Exception("Bu barkoda ait ürün bulunamadı.");

            return product;
        }
        // ID ile tek ürün getirir
        public Product GetById(int id)
        {
            return _repo.GetById(id);
        }
        // Yeni ürün ekler — önce kuralları kontrol eder
        public void Add(Product p)
        {
            // Zorunlu alan kontrolleri — UI'da da kontrol edilir ama
            // Business katmanında da olması güvenlik için
            if (string.IsNullOrWhiteSpace(p.Name))
                throw new System.Exception("Ürün adı boş olamaz.");

            if (string.IsNullOrWhiteSpace(p.Barcode))
                throw new System.Exception("Barkod boş olamaz.");

            if (p.PurchasePrice <= 0)
                throw new System.Exception("Alış fiyatı sıfırdan büyük olmalıdır.");

            if (p.SalePrice <= 0)
                throw new System.Exception("Satış fiyatı sıfırdan büyük olmalıdır.");

            if (p.SalePrice < p.PurchasePrice)
                throw new System.Exception("Satış fiyatı alış fiyatından küçük olamaz.");

            if (p.StockQuantity < 0)
                throw new System.Exception("Stok miktarı negatif olamaz.");

            _repo.Add(p);
        }
        // Ürün bilgilerini günceller
        public void Update(Product p)
        {
            if (string.IsNullOrWhiteSpace(p.Name))
                throw new System.Exception("Ürün adı boş olamaz.");

            if (p.SalePrice < p.PurchasePrice)
                throw new System.Exception("Satış fiyatı alış fiyatından küçük olamaz.");

            _repo.Update(p);
        }
        // Ürünü siler
        public void Delete(int id)
        {
            _repo.Delete(id);
        }
        public int GetTotalCount() => _repo.GetTotalCount();
        public int GetCriticalStockCount() => _repo.GetCriticalStockCount();
    }
}