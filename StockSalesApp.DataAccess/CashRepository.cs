using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using StockSalesApp.Entities;

namespace StockSalesApp.DataAccess
{
    public class CashRepository
    {
        // Tüm hesapları getirir
        public List<CashAccount> GetAll()
        {
            var list = new List<CashAccount>();
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    "SELECT * FROM CashAccounts ORDER BY Id", conn);
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read()) list.Add(MapAccount(reader));
            }
            return list;
        }

        // Sadece bankaları getirir
        public List<CashAccount> GetBanks()
        {
            var list = new List<CashAccount>();
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    "SELECT * FROM CashAccounts WHERE AccountType = 'BANK'", conn);
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read()) list.Add(MapAccount(reader));
            }
            return list;
        }

        // ID ile hesap getirir
        public CashAccount GetById(int id)
        {
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    "SELECT * FROM CashAccounts WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                using (var reader = cmd.ExecuteReader())
                    if (reader.Read()) return MapAccount(reader);
            }
            return null;
        }

        // Kasayı getirir (AccountType = CASH)
        public CashAccount GetCash()
        {
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    "SELECT * FROM CashAccounts WHERE AccountType = 'CASH'", conn);
                using (var reader = cmd.ExecuteReader())
                    if (reader.Read()) return MapAccount(reader);
            }
            return null;
        }

        // Bakiye günceller (transaction içinde)
        public void UpdateBalance(int accountId, decimal newBalance,
            SqlConnection conn, SqlTransaction transaction)
        {
            var cmd = new SqlCommand(
                "UPDATE CashAccounts SET Balance = @Balance WHERE Id = @Id",
                conn, transaction);
            cmd.Parameters.AddWithValue("@Balance", newBalance);
            cmd.Parameters.AddWithValue("@Id", accountId);
            cmd.ExecuteNonQuery();
        }

        // Kasa hareketi ekler (transaction içinde)
        public void AddMovement(CashMovement movement,
            SqlConnection conn, SqlTransaction transaction)
        {
            var cmd = new SqlCommand(@"
                INSERT INTO CashMovements
                    (SaleId, AccountId, Amount, MovementType, Description, MovementDate)
                VALUES
                    (@SaleId, @AccountId, @Amount, @MovementType, @Description, GETDATE())",
                conn, transaction);
            cmd.Parameters.AddWithValue("@SaleId", movement.SaleId);
            cmd.Parameters.AddWithValue("@AccountId", movement.AccountId);
            cmd.Parameters.AddWithValue("@Amount", movement.Amount);
            cmd.Parameters.AddWithValue("@MovementType", movement.MovementType);
            cmd.Parameters.AddWithValue("@Description", movement.Description ?? "");
            cmd.ExecuteNonQuery();
        }

        // Fiş yolunu günceller
        public void UpdateReceiptPath(int saleId, string path,
            SqlConnection conn, SqlTransaction transaction)
        {
            var cmd = new SqlCommand(
                "UPDATE Sales SET ReceiptPath = @Path WHERE Id = @Id",
                conn, transaction);
            cmd.Parameters.AddWithValue("@Path", path);
            cmd.Parameters.AddWithValue("@Id", saleId);
            cmd.ExecuteNonQuery();
        }

        private CashAccount MapAccount(SqlDataReader r)
        {
            return new CashAccount
            {
                Id = (int)r["Id"],
                Name = r["Name"].ToString(),
                AccountType = r["AccountType"].ToString(),
                Balance = (decimal)r["Balance"]
            };
        }
    }
}
