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

namespace StockSalesApp.UI
{
    public partial class frmMain : Form
    {
        private readonly User _currentUser;

        public frmMain(User user)
        {
            InitializeComponent();
            _currentUser = user;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // Şimdilik boş, sonra dolduracağız
        }
    }
}
