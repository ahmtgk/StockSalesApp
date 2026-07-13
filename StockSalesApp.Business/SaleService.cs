using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using StockSalesApp.DataAccess;
using StockSalesApp.Entities;

namespace StockSalesApp.Business
{
    public class SaleService
    {
        // ALANLAR 
        private readonly SaleRepository _saleRepo = new SaleRepository();
        private readonly ProductRepository _productRepo = new ProductRepository();
        private readonly StockRepository _stockRepo = new StockRepository();
        private readonly CashRepository _cashRepo = new CashRepository();

        // Ana satış metodu — tüm adımları transaction içinde yönetir
        public void CompleteSale(Sale sale, List<SaleDetail> details, PaymentInfo payment)
        {
            if (details == null || details.Count == 0)
                throw new Exception("Sepet boş olamaz.");

            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // ADIM 1: Tüm ürünlerin stok kontrolü
                        // Önce hepsini kontrol et, sonra kaydetmeye başla
                        // Yoksa ilk 2 ürün kaydedilip 3. üründe hata çıkabilir
                        ValidateStock(details);

                        // ADIM 2: Sales tablosuna satış başlığını kaydet
                        // Ödeme yöntemini de sale nesnesine yaz
                        sale.PaymentMethod = payment.PaymentMethod;
                        int saleId = _saleRepo.Add(sale, conn, transaction);

                        // ADIM 3-5: Sepetteki her ürün için
                        ProcessSaleDetails(saleId, details, conn, transaction);

                        // ADIM 6: Ödeme tipine göre kasa/banka bakiyelerini güncelle
                        ProcessPayment(saleId, payment, conn, transaction);

                        // ADIM 7: PDF fiş oluştur ve yolunu veritabanına kaydet
                        string receiptPath = ReceiptService.GenerateReceipt(
                            saleId, details, payment);
                        _cashRepo.UpdateReceiptPath(saleId, receiptPath, conn, transaction);

                        // Tüm adımlar başarılıysa veritabanına kalıcı yaz
                        transaction.Commit();
                    }
                    catch
                    {
                        // Herhangi bir adımda hata olursa hepsini geri al
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        // Dashboard için bugünkü toplam satış tutarı
        public decimal GetTodayTotalAmount() => _saleRepo.GetTodayTotalAmount();

        // Dashboard için bugünkü satış adedi
        public int GetTodaySaleCount() => _saleRepo.GetTodaySaleCount();

        // Dashboard için son 10 satış
        public List<Sale> GetLast10() => _saleRepo.GetLast10();

        // Tüm satışları listeler
        public List<Sale> GetAll() => _saleRepo.GetAll();

        // Tarih aralığına göre satış raporu
        public List<Sale> GetByDateRange(DateTime start, DateTime end)
        {
            if (start > end)
                throw new Exception("Başlangıç tarihi bitiş tarihinden büyük olamaz.");
            return _saleRepo.GetByDateRange(start, end);
        }

        // En çok satılan ürünler raporu
        public List<TopProduct> GetTopProducts(DateTime start, DateTime end)
        {
            if (start > end)
                throw new Exception("Başlangıç tarihi bitiş tarihinden büyük olamaz.");
            return _saleRepo.GetTopProducts(start, end);
        }

        // Sadece stok yeterliliğini kontrol eder
        // Hepsi kontrol edilir — ilk hatada Exception fırlatılır
        private void ValidateStock(List<SaleDetail> details)
        {
            foreach (var detail in details)
            {
                var product = _productRepo.GetById(detail.ProductId);

                if (product == null)
                    throw new Exception($"Ürün bulunamadı: ID {detail.ProductId}");

                if (product.StockQuantity < detail.Quantity)
                    throw new Exception(
                        $"'{product.Name}' için yeterli stok yok. " +
                        $"Mevcut: {product.StockQuantity}, " +
                        $"İstenen: {detail.Quantity}");
            }
        }

        // Sadece satış kalemlerini işler
        // Her ürün için: detay kaydı + stok düşme + hareket logu
        private void ProcessSaleDetails(int saleId, List<SaleDetail> details,
            SqlConnection conn, SqlTransaction transaction)
        {
            foreach (var detail in details)
            {
                var product = _productRepo.GetById(detail.ProductId);
                detail.SaleId = saleId;

                // SaleDetails tablosuna bu ürünü kaydet
                _saleRepo.AddDetail(detail, conn, transaction);

                // Products tablosunda stok miktarını düşür
                int newStock = product.StockQuantity - detail.Quantity;
                _productRepo.UpdateStock(detail.ProductId, newStock, conn, transaction);

                // StockMovements tablosuna OUT hareketi ekle
                _stockRepo.Add(new StockMovement
                {
                    ProductId = detail.ProductId,
                    Quantity = detail.Quantity,
                    MovementType = "OUT"
                }, conn, transaction);
            }
        }

        // Sadece ödeme tipine göre doğru metodu çağırır
        // switch-case: 3 farklı ödeme tipi var, her biri farklı işlem yapıyor
        // CASH → sadece kasa güncellenir
        // BANK → sadece banka güncellenir
        // MIXED → hem banka hem kasa güncellenir
        private void ProcessPayment(int saleId, PaymentInfo payment,
            SqlConnection conn, SqlTransaction transaction)
        {
            var cash = _cashRepo.GetCash(); // Kasa hesabını al

            switch (payment.PaymentMethod)
            {
                case "CASH":
                    ProcessCashPayment(saleId, payment, cash, conn, transaction);
                    break;

                case "BANK":
                    ProcessBankPayment(saleId, payment, conn, transaction);
                    break;

                case "MIXED":
                    ProcessMixedPayment(saleId, payment, cash, conn, transaction);
                    break;

                default:
                    throw new Exception($"Geçersiz ödeme tipi: {payment.PaymentMethod}");
            }
        }

        // Sadece nakit ödemeyi işler
        // Kasaya giriş yap, para üstü varsa kasadan çıkış yap
        private void ProcessCashPayment(int saleId, PaymentInfo payment,
            CashAccount cash, SqlConnection conn, SqlTransaction transaction)
        {
            // Müşteriden alınan tutar kasaya giriyor
            _cashRepo.AddMovement(new CashMovement
            {
                SaleId = saleId,
                AccountId = cash.Id,
                Amount = payment.TotalAmount,
                MovementType = "IN",
                Description = $"Satış #{saleId} — Nakit tahsilat"
            }, conn, transaction);

            decimal newBalance = cash.Balance + payment.TotalAmount;

            // Para üstü varsa kasadan çıkıyor
            if (payment.CashChange > 0)
            {
                _cashRepo.AddMovement(new CashMovement
                {
                    SaleId = saleId,
                    AccountId = cash.Id,
                    Amount = payment.CashChange,
                    MovementType = "OUT",
                    Description = $"Satış #{saleId} — Para üstü"
                }, conn, transaction);

                // Bakiyeden para üstünü düş
                newBalance -= payment.CashChange;
            }

            // Kasa bakiyesini güncelle
            _cashRepo.UpdateBalance(cash.Id, newBalance, conn, transaction);
        }

        // Sadece kart ödemesini işler
        // Sadece seçilen bankanın bakiyesi artıyor, kasaya dokunulmuyor
        private void ProcessBankPayment(int saleId, PaymentInfo payment,
            SqlConnection conn, SqlTransaction transaction)
        {
            var bank = _cashRepo.GetById(payment.BankAccountId);

            _cashRepo.AddMovement(new CashMovement
            {
                SaleId = saleId,
                AccountId = payment.BankAccountId,
                Amount = payment.TotalAmount,
                MovementType = "IN",
                Description = $"Satış #{saleId} — {bank.Name} ile tahsilat"
            }, conn, transaction);

            // Banka bakiyesini güncelle
            decimal newBalance = bank.Balance + payment.TotalAmount;
            _cashRepo.UpdateBalance(payment.BankAccountId, newBalance, conn, transaction);
        }

        // Sadece karma ödemeyi işler
        // Önce banka kısmı, sonra nakit kısmı işlenir
        // Para üstü varsa kasadan düşülür
        private void ProcessMixedPayment(int saleId, PaymentInfo payment,
            CashAccount cash, SqlConnection conn, SqlTransaction transaction)
        {
            var bank = _cashRepo.GetById(payment.BankAccountId);

            // BANKA KISMI
            _cashRepo.AddMovement(new CashMovement
            {
                SaleId = saleId,
                AccountId = payment.BankAccountId,
                Amount = payment.BankAmount,
                MovementType = "IN",
                Description = $"Satış #{saleId} — {bank.Name} ile kısmi tahsilat"
            }, conn, transaction);

            decimal newBankBalance = bank.Balance + payment.BankAmount;
            _cashRepo.UpdateBalance(payment.BankAccountId, newBankBalance, conn, transaction);

            // NAKİT KISMI 
            _cashRepo.AddMovement(new CashMovement
            {
                SaleId = saleId,
                AccountId = cash.Id,
                Amount = payment.CashAmount,
                MovementType = "IN",
                Description = $"Satış #{saleId} — Nakit kısmi tahsilat"
            }, conn, transaction);

            decimal newCashBalance = cash.Balance + payment.CashAmount;

            // Para üstü varsa kasadan çıkış
            if (payment.CashChange > 0)
            {
                _cashRepo.AddMovement(new CashMovement
                {
                    SaleId = saleId,
                    AccountId = cash.Id,
                    Amount = payment.CashChange,
                    MovementType = "OUT",
                    Description = $"Satış #{saleId} — Para üstü"
                }, conn, transaction);

                newCashBalance -= payment.CashChange;
            }

            // Kasa bakiyesini güncelle
            _cashRepo.UpdateBalance(cash.Id, newCashBalance, conn, transaction);
        }
    }
}
