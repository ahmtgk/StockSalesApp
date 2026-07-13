using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSalesApp.Entities
{
    public class CashAccount
    {
        public int Id { get; set; }
        public string Name { get; set; } // Kasa, Banka1, Banka2
        public string AccountType { get; set; } // CASH veya BANK
        public decimal Balance { get; set; }
    }
}
