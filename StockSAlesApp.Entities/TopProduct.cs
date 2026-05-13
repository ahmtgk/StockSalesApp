using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSalesApp.Entities
{
    // En çok satılan ürün raporu için kullanılan model
    // Veritabanında bu tablo yok — GROUP BY sorgusu sonucunu taşır
    public class TopProduct
    {
        public string ProductName { get; set; }
        public int TotalQuantity { get; set; } // Toplam satılan adet
        public decimal TotalRevenue { get; set; } // Toplam gelir
    }
}
