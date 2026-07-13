using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSalesApp.Entities
{
    // Ödeme formundan SaleService'e gönderilecek ödeme bilgisi
    public class PaymentInfo
    {
        public decimal TotalAmount { get; set; } // Sepet tutarı
        public string PaymentMethod { get; set; } // CASH, BANK, MIXED

        // Nakit ödeme
        public decimal CashGiven { get; set; } // Müşteriden alınan nakit
        public decimal CashChange { get; set; } // Para üstü

        // Kart ödeme
        public int BankAccountId { get; set; } // Hangi banka
        public string BankName { get; set; } // Banka adı
        public decimal BankAmount { get; set; } // Kart ile ödenen tutar

        // Karma ödeme için kalan nakit tutar
        public decimal CashAmount { get; set; } // Nakit ödenen kısım
    }
}
