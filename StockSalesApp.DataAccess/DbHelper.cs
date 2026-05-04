using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace StockSalesApp.DataAccess
{
    public class DbHelper
    {
        private static readonly string ConnectionString =
            "Server=(localdb)\\MSSQLLocalDB;Database=StockSalesDB;Trusted_Connection=True;TrustServerCertificate=True;";

        // Bu metot her çağrıldığında yeni bir bağlantı nesnesi üretir
        // "static" olduğu için new DbHelper() yapmadan direkt DbHelper.GetConnection() diye çağırılır
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
