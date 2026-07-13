using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSalesApp.Entities
{
    public class Sale
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime SaleDate { get; set; }
        public string Username { get; set; } // Dashboard için
        public string PaymentMethod { get; set; } // Ödeme yöntemi
        public string ReceiptPath { get; set; } // Fiş PDF yolu
    }
}
