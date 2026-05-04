using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using StockSalesApp.Entities;
using System.Windows.Forms;

namespace StockSalesApp.UI
{
    public partial class frmSale : Form
    {
        private readonly User _currentUser;

        public frmSale(User user)
        {
            InitializeComponent();
            _currentUser = user;
        }
    }
}
