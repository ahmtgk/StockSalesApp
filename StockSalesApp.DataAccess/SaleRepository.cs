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
        // Satış başlığını kaydeder, yeni kaydın ID'sini döner
        // ID lazım çünkü SaleDetails satırlarına bu ID yazılacak
        public int Add(Sale sale, SqlConnection conn, SqlTransaction transaction)
        {
            var cmd = new SqlCommand(@"
                INSERT INTO Sales (UserId, TotalAmount, SaleDate)
                VALUES (@UserId, @TotalAmount, GETDATE());
                SELECT SCOPE_IDENTITY();",
                conn, transaction);
            // SELECT SCOPE_IDENTITY(): az önce eklenen satırın otomatik artan ID'sini verir

            cmd.Parameters.AddWithValue("@UserId", sale.UserId);
            cmd.Parameters.AddWithValue("@TotalAmount", sale.TotalAmount);

            // ExecuteScalar: tek bir değer dönen sorgular için — burada yeni ID'yi döner
            return Convert.ToInt32(cmd.ExecuteScalar());
        }
        // Sepetteki her ürünü SaleDetails tablosuna satır olarak ekler
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
        // Tüm satışları listeler (rapor ekranı için)
        public List<Sale> GetAll()
        {
            var list = new List<Sale>();
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    "SELECT * FROM Sales ORDER BY SaleDate DESC", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Sale
                        {
                            Id = (int)reader["Id"],
                            UserId = (int)reader["UserId"],
                            TotalAmount = (decimal)reader["TotalAmount"],
                            SaleDate = (DateTime)reader["SaleDate"]
                        });
                    }
                }
            }
            return list;
        }
        // Bugünkü toplam satış tutarını getirir (Dashboard)
        public decimal GetTodayTotalAmount()
        {
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand(@"
            SELECT ISNULL(SUM(TotalAmount), 0)
            FROM Sales
            WHERE CAST(SaleDate AS DATE) = CAST(GETDATE() AS DATE)", conn);
                // ISNULL(..., 0) = satış yoksa null yerine 0 döner
                // CAST(... AS DATE) = sadece tarihi karşılaştırır, saati yoksayar
                return Convert.ToDecimal(cmd.ExecuteScalar());
            }
        }
        // Bugünkü satış adedini getirir
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
        
        public List<Sale> GetLast10()
        {
            var list = new List<Sale>();
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand(@"
            SELECT TOP 10 s.Id, s.UserId, s.TotalAmount, s.SaleDate,
                         u.Username
            FROM Sales s
            INNER JOIN Users u ON s.UserId = u.Id
            ORDER BY s.SaleDate DESC", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Sale
                        {
                            Id = (int)reader["Id"],
                            UserId = (int)reader["UserId"],
                            TotalAmount = (decimal)reader["TotalAmount"],
                            SaleDate = (DateTime)reader["SaleDate"],
                            Username = reader["Username"].ToString()
                        });
                    }
                }
            }
            return list;
        }
        // Tarih aralığına göre satışları getirir (Günlük Satış Raporu)
        public List<Sale> GetByDateRange(DateTime start, DateTime end)
        {
            var list = new List<Sale>();
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand(@"
            SELECT s.Id, s.UserId, s.TotalAmount, s.SaleDate, u.Username
            FROM Sales s
            INNER JOIN Users u ON s.UserId = u.Id
            WHERE CAST(s.SaleDate AS DATE) >= @Start
            AND CAST(s.SaleDate AS DATE) <= @End
            ORDER BY s.SaleDate DESC", conn);

                cmd.Parameters.AddWithValue("@Start", start.Date);
                cmd.Parameters.AddWithValue("@End", end.Date);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Sale
                        {
                            Id = (int)reader["Id"],
                            UserId = (int)reader["UserId"],
                            TotalAmount = (decimal)reader["TotalAmount"],
                            SaleDate = (DateTime)reader["SaleDate"],
                            Username = reader["Username"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        // En çok satılan ürünleri getirir (satılan toplam adete göre sıralı)
        public List<TopProduct> GetTopProducts(DateTime start, DateTime end)
        {
            var list = new List<TopProduct>();
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand(@"
            SELECT TOP 10
                p.Name AS ProductName,
                SUM(sd.Quantity) AS TotalQuantity,
                SUM(sd.TotalPrice) AS TotalRevenue
            FROM SaleDetails sd
            INNER JOIN Products p ON sd.ProductId = p.Id
            INNER JOIN Sales s ON sd.SaleId = s.Id
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
    }
}
