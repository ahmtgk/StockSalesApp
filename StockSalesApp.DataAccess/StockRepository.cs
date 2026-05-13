using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using StockSalesApp.Entities;


namespace StockSalesApp.DataAccess
{
    public class StockRepository
    {
        // Stok hareketi kaydeder (giriş veya çıkış)
        // Neden conn ve transaction alıyor?
        // Çünkü bu metot tek başına çalışmaz — satış işleminin içinde çağrılır. Hata olursa tüm işlem birlikte geri alınır.
        public void Add(StockMovement sm, SqlConnection conn, SqlTransaction transaction)
        {
            var cmd = new SqlCommand(@"
                INSERT INTO StockMovements (ProductId, Quantity, MovementType, MovementDate)
                VALUES (@ProductId, @Quantity, @MovementType, GETDATE())",
                conn, transaction);

            cmd.Parameters.AddWithValue("@ProductId", sm.ProductId);
            cmd.Parameters.AddWithValue("@Quantity", sm.Quantity);
            cmd.Parameters.AddWithValue("@MovementType", sm.MovementType); // "IN" veya "OUT"
            cmd.ExecuteNonQuery();
        }
        // Stok hareketleri raporunu getirir
        public List<StockMovement> GetAll()
        {
            var list = new List<StockMovement>();
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand(@"
                    SELECT sm.Id, sm.ProductId, sm.Quantity, sm.MovementType, sm.MovementDate, p.Name AS ProductName 
                    FROM StockMovements sm  
                    INNER JOIN Products p ON sm.ProductId = p.Id 
                    ORDER BY sm.MovementDate DESC", conn);
                // ORDER BY DESC = en yeni hareket en üstte görünür

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new StockMovement
                        {
                            Id = (int)reader["Id"],
                            ProductId = (int)reader["ProductId"],
                            Quantity = (int)reader["Quantity"],
                            MovementType = reader["MovementType"].ToString(),
                            MovementDate = (DateTime)reader["MovementDate"],
                            ProductName = reader["ProductName"].ToString()
                        });
                    }
                }
            }
            return list;
        }
        // Belirli bir ürünün stok hareketlerini getirir
        public List<StockMovement> GetByProductId(int productId)
        {
            var list = new List<StockMovement>();
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand(@"
            SELECT sm.Id, sm.ProductId, sm.Quantity, sm.MovementType, sm.MovementDate, p.Name AS ProductName
            FROM StockMovements sm
            INNER JOIN Products p ON sm.ProductId = p.Id
            WHERE sm.ProductId = @ProductId
            ORDER BY sm.MovementDate DESC", conn);
                cmd.Parameters.AddWithValue("@ProductId", productId);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new StockMovement
                        {
                            Id = (int)reader["Id"],
                            ProductId = (int)reader["ProductId"],
                            Quantity = (int)reader["Quantity"],
                            MovementType = reader["MovementType"].ToString(),
                            MovementDate = (DateTime)reader["MovementDate"],
                            ProductName = reader["ProductName"].ToString()
                        });
                    }
                }
            }
            return list;
        }
    }
}
