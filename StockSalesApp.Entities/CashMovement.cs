using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSalesApp.Entities
{
    public class CashMovement
    {
        public int Id { get; set; }
        public int SaleId { get; set; }
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
        public string MovementType { get; set; } // IN veya OUT
        public string Description { get; set; }
        public DateTime MovementDate { get; set; }
        public string AccountName { get; set; } // JOIN ile gelir
    }
}
