using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockSalesApp.DataAccess;
using StockSalesApp.Entities;

namespace StockSalesApp.Business
{
    public class CashService
    {
        private readonly CashRepository _repo = new CashRepository();

        // Tüm hesapları getirir
        public List<CashAccount> GetAll() => _repo.GetAll();

        // Sadece bankaları getirir
        public List<CashAccount> GetBanks() => _repo.GetBanks();

        // Kasayı getirir
        public CashAccount GetCash() => _repo.GetCash();
    }
}
