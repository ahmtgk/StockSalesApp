using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using StockSalesApp.Entities;
using System.Collections.Generic;

namespace StockSalesApp.DataAccess
{
    public class UserRepository
    {
        public User GetByUsername(string username)
        {
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open(); // Veritabanı bağlantısını aç

                // SqlCommand: veritabanına göndereceğimiz SQL sorgusu
                // @Username bir placeholder — gerçek değeri aşağıda Parameters ile veriyoruz
                // Bu sayede SQL Injection saldırısı imkansız hale gelir
                // JOIN ile Roles tablosundan kullanıcının rol adını da çekiyoruz
                var cmd = new SqlCommand(@"
                    SELECT u.Id, u.Username, u.PasswordHash, u.RoleId, r.RoleName
                    FROM Users u
                    INNER JOIN Roles r ON u.RoleId = r.Id
                    WHERE u.Username = @Username", conn);

                // @Username placeholder'ına kullanıcının girdiği değeri bağla
                cmd.Parameters.AddWithValue("@Username", username);

                // ExecuteReader: SELECT sorgularında kullanılır, satırları tek tek okur
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Veritabanından gelen veriyi User nesnesine dönüştür
                        return new User
                        {
                            Id = (int)reader["Id"],
                            Username = reader["Username"].ToString(),
                            PasswordHash = reader["PasswordHash"].ToString(),
                            RoleId = (int)reader["RoleId"],
                            RoleName = reader["RoleName"].ToString()
                        };
                    }
                }
            }
            return null;
        }
        public List<User> GetAll()
        {
            var list = new List<User>(); // Sonuçları toplayacak boş liste

            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand(@"
                    SELECT u.Id, u.Username, u.PasswordHash, u.RoleId, r.RoleName
                    FROM Users u
                    INNER JOIN Roles r ON u.RoleId = r.Id", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    // while ile her satırı oku, listeye ekle
                    while (reader.Read())
                    {
                        list.Add(new User
                        {
                            Id = (int)reader["Id"],
                            Username = reader["Username"].ToString(),
                            PasswordHash = reader["PasswordHash"].ToString(),
                            RoleId = (int)reader["RoleId"],
                            RoleName = reader["RoleName"].ToString()
                        });
                    }
                }
            }
            return list;
        }
        // Yeni kullanıcı ekler (şifre Business katmanında hashlenmiş gelir)
        public void Add(User user)
        {
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand(@"
                    INSERT INTO Users (Username, PasswordHash, RoleId)
                    VALUES (@Username, @PasswordHash, @RoleId)", conn);

                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
                cmd.Parameters.AddWithValue("@RoleId", user.RoleId);
                // ExecuteNonQuery: INSERT/UPDATE/DELETE için kullanılır
                cmd.ExecuteNonQuery();
            }
        }
        // Mevcut kullanıcının bilgilerini günceller
        public void Update(User user)
        {
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand(@"
                    UPDATE Users
                    SET Username     = @Username,
                        PasswordHash = @PasswordHash,
                        RoleId       = @RoleId
                    WHERE Id = @Id", conn);

                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
                cmd.Parameters.AddWithValue("@RoleId", user.RoleId);
                cmd.Parameters.AddWithValue("@Id", user.Id);
                cmd.ExecuteNonQuery();
            }
        }
        public void Delete(int id)
        {
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    "DELETE FROM Users WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
