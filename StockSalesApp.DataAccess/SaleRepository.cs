using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using StockSalesApp.Entities;

namespace StockSalesApp.DataAccess
{
    public class SaleRepository
    {
        // Satış başlığını kaydeder, yeni ID döner
        public int Add(Sale sale, SqlConnection conn, SqlTransaction transaction)
        {
            var cmd = new SqlCommand(@"
                INSERT INTO Sales (UserId, TotalAmount, SaleDate, PaymentMethod)
                VALUES (@UserId, @TotalAmount, GETDATE(), @PaymentMethod);
                SELECT SCOPE_IDENTITY();",
                conn, transaction);
            cmd.Parameters.AddWithValue("@UserId", sale.UserId);
            cmd.Parameters.AddWithValue("@TotalAmount", sale.TotalAmount);
            cmd.Parameters.AddWithValue("@PaymentMethod", sale.PaymentMethod ?? "");
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        // Satış kalemini kaydeder
        public void AddDetail(SaleDetail detail, SqlConnection conn, SqlTransaction transaction)
        {
            var cmd = new SqlCommand(@"
                INSERT INTO SaleDetails (SaleId, ProductId, Quantity, UnitPrice, TotalPrice)
                VALUES (@SaleId, @ProductId, @Quantity, @UnitPrice, @TotalPrice)",
                conn, transaction);
            cmd.Parameters.AddWithValue("@SaleId", detail.SaleId);
            cmd.Parameters.AddWithValue("@ProductId", detail.ProductId);
            cmd.Parameters.AddWithValue("@Quantity", detail.Quantity);
            cmd.Parameters.AddWithValue("@UnitPrice", detail.UnitPrice);
            cmd.Parameters.AddWithValue("@TotalPrice", detail.TotalPrice);
            cmd.ExecuteNonQuery();
        }
        // Tüm satışları getirir
        public List<Sale> GetAll()
        {
            var list = new List<Sale>();
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand(@"
                    SELECT s.Id, s.UserId, s.TotalAmount, s.SaleDate,
                           s.PaymentMethod, s.ReceiptPath,
                           u.Username
                    FROM Sales s
                    INNER JOIN Users u ON s.UserId = u.Id
                    ORDER BY s.SaleDate DESC", conn);
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read()) list.Add(Map(reader));
            }
            return list;
        }
        // Son 10 satışı getirir (Dashboard için)
        public List<Sale> GetLast10()
        {
            var list = new List<Sale>();
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand(@"
                    SELECT TOP 10
                        s.Id, s.UserId, s.TotalAmount, s.SaleDate,
                        s.PaymentMethod, s.ReceiptPath,
                        u.Username
                    FROM Sales s
                    INNER JOIN Users u ON s.UserId = u.Id
                    ORDER BY s.SaleDate DESC", conn);
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read()) list.Add(Map(reader));
            }
            return list;
        }
        // Tarih aralığına göre satışları getirir (Raporlar için)
        public List<Sale> GetByDateRange(DateTime start, DateTime end)
        {
            var list = new List<Sale>();
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand(@"
                    SELECT
                        s.Id, s.UserId, s.TotalAmount, s.SaleDate,
                        s.PaymentMethod, s.ReceiptPath,
                        u.Username
                    FROM Sales s
                    INNER JOIN Users u ON s.UserId = u.Id
                    WHERE CAST(s.SaleDate AS DATE) >= @Start
                      AND CAST(s.SaleDate AS DATE) <= @End
                    ORDER BY s.SaleDate DESC", conn);
                cmd.Parameters.AddWithValue("@Start", start.Date);
                cmd.Parameters.AddWithValue("@End", end.Date);
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read()) list.Add(Map(reader));
            }
            return list;
        }
        // Bugünkü toplam satış tutarı (Dashboard kartı için)
        public decimal GetTodayTotalAmount()
        {
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand(@"
                    SELECT ISNULL(SUM(TotalAmount), 0)
                    FROM Sales
                    WHERE CAST(SaleDate AS DATE) = CAST(GETDATE() AS DATE)", conn);
                return Convert.ToDecimal(cmd.ExecuteScalar());
            }
        }
        // Bugünkü satış adedi (Dashboard kartı için)
        public int GetTodaySaleCount()
        {
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand(@"
                    SELECT COUNT(*)
                    FROM Sales
                    WHERE CAST(SaleDate AS DATE) = CAST(GETDATE() AS DATE)", conn);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        // En çok satılan ürünler (Raporlar için)
        public List<TopProduct> GetTopProducts(DateTime start, DateTime end)
        {
            var list = new List<TopProduct>();
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand(@"
                    SELECT TOP 10
                        p.Name AS ProductName,
                        SUM(sd.Quantity)   AS TotalQuantity,
                        SUM(sd.TotalPrice) AS TotalRevenue
                    FROM SaleDetails sd
                    INNER JOIN Products p ON sd.ProductId = p.Id
                    INNER JOIN Sales    s ON sd.SaleId    = s.Id
                    WHERE CAST(s.SaleDate AS DATE) >= @Start
                      AND CAST(s.SaleDate AS DATE) <= @End
                    GROUP BY p.Id, p.Name
                    ORDER BY TotalQuantity DESC", conn);
                cmd.Parameters.AddWithValue("@Start", start.Date);
                cmd.Parameters.AddWithValue("@End", end.Date);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new TopProduct
                        {
                            ProductName = reader["ProductName"].ToString(),
                            TotalQuantity = (int)reader["TotalQuantity"],
                            TotalRevenue = (decimal)reader["TotalRevenue"]
                        });
                    }
                }
            }
            return list;
        }
        // MAP METODU 
        // Tekrar eden reader kodunu tek yerde toplar — DRY prensibi
        // GetAll, GetLast10, GetByDateRange metodları bu metodu kullanır
        private Sale Map(SqlDataReader r)
        {
            return new Sale
            {
                Id = (int)r["Id"],
                UserId = (int)r["UserId"],
                TotalAmount = (decimal)r["TotalAmount"],
                SaleDate = (DateTime)r["SaleDate"],
                Username = r["Username"].ToString(),
                // ?. operatörü: bu sütunlar null gelebilir
                // null gelirse ToString() çağrılmaz, null döner
                PaymentMethod = r["PaymentMethod"]?.ToString(),
                ReceiptPath = r["ReceiptPath"]?.ToString()
            };
        }
    }
}
