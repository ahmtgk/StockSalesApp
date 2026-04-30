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
    }
}
