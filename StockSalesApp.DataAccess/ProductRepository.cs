using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using StockSalesApp.Entities;

namespace StockSalesApp.DataAccess
{
    public class ProductRepository
    {
        // Ürün listesi ekranı için: tüm ürünleri getirir
        public List<Product> GetAll()
        {
            var list = new List<Product>();
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM Products", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        list.Add(Map(reader)); // Map: aşağıda tanımlı yardımcı metot
                }
            }
            return list;
        }
        // ID ile tek ürün getirir (satış sırasında stok kontrolü için)
        public Product? GetById(int id)
        {
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    "SELECT * FROM Products WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read()) return Map(reader);
                }
            }
            return null;
        }
        // Barkod okutunca ürünü getirir
        public Product? GetByBarcode(string barcode)
        {
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    "SELECT * FROM Products WHERE Barcode = @Barcode", conn);
                cmd.Parameters.AddWithValue("@Barcode", barcode);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read()) return Map(reader);
                }
            }
            return null;
        }
        // Arama kutusundan isim veya barkodla arama
        // LIKE ve % işareti: "laptop" yazınca "gaming laptop" da bulunur
        public List<Product> Search(string keyword)
        {
            var list = new List<Product>();
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand(@"
                    SELECT * FROM Products
                    WHERE Name LIKE @K OR Barcode LIKE @K", conn);
                cmd.Parameters.AddWithValue("@K", "%" + keyword + "%");
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read()) list.Add(Map(reader));
                }
            }
            return list;
        }
        // Yeni ürün ekler
        public void Add(Product p)
        {
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand(@"
                    INSERT INTO Products (Name, Barcode, PurchasePrice, SalePrice, StockQuantity)
                    VALUES (@Name, @Barcode, @PurchasePrice, @SalePrice, @StockQuantity)", conn);

                cmd.Parameters.AddWithValue("@Name", p.Name);
                cmd.Parameters.AddWithValue("@Barcode", p.Barcode);
                cmd.Parameters.AddWithValue("@PurchasePrice", p.PurchasePrice);
                cmd.Parameters.AddWithValue("@SalePrice", p.SalePrice);
                cmd.Parameters.AddWithValue("@StockQuantity", p.StockQuantity);
                cmd.ExecuteNonQuery();
            }
        }
        // Ürün bilgilerini günceller (stok değişmez, o ayrı metotla yapılır)
        public void Update(Product p)
        {
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand(@"
                    UPDATE Products
                    SET Name          = @Name,
                        Barcode       = @Barcode,
                        PurchasePrice = @PurchasePrice,
                        SalePrice     = @SalePrice
                    WHERE Id = @Id", conn);

                cmd.Parameters.AddWithValue("@Name", p.Name);
                cmd.Parameters.AddWithValue("@Barcode", p.Barcode);
                cmd.Parameters.AddWithValue("@PurchasePrice", p.PurchasePrice);
                cmd.Parameters.AddWithValue("@SalePrice", p.SalePrice);
                cmd.Parameters.AddWithValue("@Id", p.Id);
                cmd.ExecuteNonQuery();
            }
        }
        // Ürünü siler
        public void Delete(int id)
        {
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    "DELETE FROM Products WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }
        // SADECE stok miktarını günceller — satış tamamlanınca çağrılır
        // conn ve transaction dışarıdan geliyor çünkü bu işlem büyük bir transaction'ın parçası: satış + detay + stok hep birlikte commit/rollback olmalı
        public void UpdateStock(int productId, int newQuantity,
                                SqlConnection conn, SqlTransaction transaction)
        {
            var cmd = new SqlCommand(@"
                UPDATE Products
                SET StockQuantity = @Q
                WHERE Id = @Id", conn, transaction);

            cmd.Parameters.AddWithValue("@Q", newQuantity);
            cmd.Parameters.AddWithValue("@Id", productId);
            cmd.ExecuteNonQuery();
        }
        // Kod tekrarını önlemek için: reader'dan Product nesnesi üretir
        // "private" = sadece bu sınıf kullanır, dışarıdan erişilemez
        private Product Map(SqlDataReader r)
        {
            return new Product
            {
                Id = (int)r["Id"],
                Name = r["Name"].ToString(),
                Barcode = r["Barcode"].ToString(),
                PurchasePrice = (decimal)r["PurchasePrice"],
                SalePrice = (decimal)r["SalePrice"],
                StockQuantity = (int)r["StockQuantity"]
            };
        }
        // Toplam ürün sayısını getirir
        public int GetTotalCount()
        {
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT COUNT(*) FROM Products", conn);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        // Stok miktarı 5 ve altındaki ürün sayısını getirir (kritik stok uyarısı)
        public int GetCriticalStockCount()
        {
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    "SELECT COUNT(*) FROM Products WHERE StockQuantity <= 5", conn);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
    }
}
