using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockSalesApp.DataAccess;
using StockSalesApp.Entities;
using System.Security.Cryptography; // SHA256 için
using System.Text;                  // Encoding için

namespace StockSalesApp.Business
{
    public class UserService
    {
        // DataAccess katmanındaki repository'yi burada kullanıyoruz
        // "private readonly" = sadece bu sınıf kullanır, sonradan değiştirilemez
        private readonly UserRepository _repo = new UserRepository();
        // Login ekranından çağrılır
        // Kullanıcı adını veritabanında arar, şifresini karşılaştırır
        // Doğruysa User nesnesi döner, yanlışsa null döner
        public User Login(string username, string password)
        {
            // Önce kullanıcı adıyla veritabanında kullanıcıyı bul
            var user = _repo.GetByUsername(username);

            // Kullanıcı bulunamadıysa direkt null döner
            if (user == null) return null;

            // Girilen şifreyi hashle, veritabanındaki hashlenmiş şifreyle karşılaştır
            // Şifreyi düz metin olarak veritabanına kaydetmiyoruz — güvenlik için
            if (user.PasswordHash != HashPassword(password)) return null;

            // Her şey doğruysa kullanıcı nesnesini döner
            return user;
        }
        // Kullanıcı yönetim ekranında tüm kullanıcıları listeler
        public List<User> GetAll()
        {
            return _repo.GetAll();
        }
        // Yeni kullanıcı ekler
        // Şifreyi hashleyip öyle kaydeder — veritabanında düz şifre olmaz
        public void Add(User user, string plainPassword)
        {
            // Boş kullanıcı adı kontrolü
            if (string.IsNullOrWhiteSpace(user.Username))
                throw new System.Exception("Kullanıcı adı boş olamaz.");

            // Boş şifre kontrolü
            if (string.IsNullOrWhiteSpace(plainPassword))
                throw new System.Exception("Şifre boş olamaz.");

            // Düz şifreyi hashle, User nesnesine yaz
            user.PasswordHash = HashPassword(plainPassword);

            // Repository'ye gönder, veritabanına kaydet
            _repo.Add(user);
        }
        // Mevcut kullanıcıyı günceller
        // plainPassword boş gelirse şifreyi değiştirmez, sadece diğer bilgileri günceller
        public void Update(User user, string plainPassword = null)
        {
            if (string.IsNullOrWhiteSpace(user.Username))
                throw new System.Exception("Kullanıcı adı boş olamaz.");

            // Eğer yeni şifre girildiyse hashle ve güncelle
            // Girilmediyse mevcut hash veritabanında kalır
            if (!string.IsNullOrWhiteSpace(plainPassword))
                user.PasswordHash = HashPassword(plainPassword);

            _repo.Update(user);
        }
        // Kullanıcıyı siler
        public void Delete(int id)
        {
            _repo.Delete(id);
        }
        // Şifreyi SHA256 algoritmasıyla hashler
        // "public" çünkü login formunda test amaçlı da kullanılabilir
        // Örnek: "1234" girince "03ac674..." gibi 64 karakterli string üretir
        public string HashPassword(string password)
        {
            // SHA256: tek yönlü şifreleme — hash'ten şifreye dönemezsin
            using (var sha = SHA256.Create())
            {
                // Şifreyi byte dizisine çevir
                var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Byte dizisini okunabilir hex string'e dönüştür (örn: "a3f2...")
                var sb = new StringBuilder();
                foreach (var b in bytes)
                    sb.Append(b.ToString("x2")); // x2 = 2 haneli hex

                return sb.ToString();
            }
        }
    }
}