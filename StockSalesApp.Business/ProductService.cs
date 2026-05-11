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
            // Boş arama — tüm listeyi getir
            if (string.IsNullOrWhiteSpace(keyword))
                return _repo.GetAll();

            // Çok kısa arama — en az 2 karakter
            if (keyword.Trim().Length < 2)
                throw new Exception("Arama için en az 2 karakter girmelisiniz.");

            // Sadece harf, rakam, tire ve boşluğa izin verir. Özel karakter, SQL özel karakteri gibi şeyler girince hata ver
            foreach (char c in keyword)
            {
                if (!char.IsLetterOrDigit(c) && c != ' ' && c != '-')
                    throw new Exception("Arama yalnızca harf, rakam ve tire içerebilir.");
            }

            return _repo.Search(keyword);
        }
        public Product GetByBarcode(string barcode)
        {
            if (string.IsNullOrWhiteSpace(barcode))
                throw new System.Exception("Barkod boş olamaz.");

            var product = _repo.GetByBarcode(barcode);

            if (product == null)
                throw new System.Exception("Bu barkoda ait ürün bulunamadı.");

            return product;
        }
        public Product GetById(int id)
        {
            return _repo.GetById(id);
        }
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
        public void Update(Product p)
        {
            if (string.IsNullOrWhiteSpace(p.Name))
                throw new System.Exception("Ürün adı boş olamaz.");

            if (p.SalePrice < p.PurchasePrice)
                throw new System.Exception("Satış fiyatı alış fiyatından küçük olamaz.");

            _repo.Update(p);
        }
        public void Delete(int id)
        {
            _repo.Delete(id);
        }
        public int GetTotalCount() => _repo.GetTotalCount();
        public int GetCriticalStockCount() => _repo.GetCriticalStockCount();
    }
}