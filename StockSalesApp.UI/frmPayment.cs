using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockSalesApp.Business;
using StockSalesApp.Entities;

namespace StockSalesApp.UI
{
    public partial class frmPayment : Form
    {
        private readonly CashService _cashService = new CashService();
        private readonly decimal _totalAmount;
        private readonly List<CashAccount> _banks;

        // Onaylanmış ödeme bilgisi — frmSale buradan okur
        public PaymentInfo ConfirmedPayment { get; private set; }

        public frmPayment(decimal totalAmount)
        {
            InitializeComponent();
            _totalAmount = totalAmount;
            _banks = _cashService.GetBanks();
        }

        // BUTON OLAYLARI 

        private void frmPayment_Load(object sender, EventArgs e)
        {
            SetTotalLabel();
            LoadBanks();
            rbCash.Checked = true;
            UpdatePanelVisibility();

            // Kart seçilince tutar otomatik dolsun
            txtBankAmount.Text = _totalAmount.ToString("N2");
        }

        private void rbCash_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePanelVisibility();
        }

        private void rbBank_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePanelVisibility();

            // Kart seçilince tutarı otomatik doldur
            if (rbBank.Checked)
                txtBankAmount.Text = _totalAmount.ToString("N2");
        }

        private void rbMixed_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePanelVisibility();
        }

        private void txtCashGiven_TextChanged(object sender, EventArgs e)
        {
            CalculateCashChange();
        }

        private void txtBankAmount_TextChanged(object sender, EventArgs e)
        {
            CalculateRemainingCash();
        }

        private void txtMixedCashGiven_TextChanged(object sender, EventArgs e)
        {
            CalculateMixedChange();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            ConfirmPayment();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // PRIVATE METODLAR 

        private void SetTotalLabel()
        {
            lblTotalAmount.Text = $"Ödenecek Tutar: {_totalAmount:N2} ₺";
        }

        private void LoadBanks()
        {
            cmbBank.Items.Clear();
            foreach (var bank in _banks)
                cmbBank.Items.Add(bank.Name);
            if (cmbBank.Items.Count > 0)
                cmbBank.SelectedIndex = 0;
        }

        // Sadece seçilen ödeme yöntemine göre panel gösterir
        private void UpdatePanelVisibility()
        {
            grpCash.Visible = rbCash.Checked;
            grpBank.Visible = rbBank.Checked || rbMixed.Checked;
            grpMixedCash.Visible = rbMixed.Checked;
        }

        // Sadece nakit para üstünü hesaplar
        private void CalculateCashChange()
        {
            if (!decimal.TryParse(txtCashGiven.Text, out decimal given)) given = 0;
            decimal change = given - _totalAmount;
            lblChange.Text = change >= 0
                ? $"{change:N2} ₺"
                : $"-{Math.Abs(change):N2} ₺ (Eksik)";
            lblChange.ForeColor = change >= 0
                ? System.Drawing.Color.Green
                : System.Drawing.Color.Red;
        }

        // Sadece karma ödemede kalan nakit tutarı hesaplar
        private void CalculateRemainingCash()
        {
            if (!decimal.TryParse(txtBankAmount.Text, out decimal bankAmt)) bankAmt = 0;
            decimal remaining = _totalAmount - bankAmt;
            lblRemainingCash.Text = remaining >= 0
                ? $"{remaining:N2} ₺"
                : "0,00 ₺";
        }

        // Sadece karma ödemede nakit para üstünü hesaplar
        private void CalculateMixedChange()
        {
            if (!decimal.TryParse(txtBankAmount.Text, out decimal bankAmt)) bankAmt = 0;
            if (!decimal.TryParse(txtMixedCashGiven.Text, out decimal cashGiven)) cashGiven = 0;
            decimal remaining = _totalAmount - bankAmt;
            decimal change = cashGiven - remaining;
            lblMixedChange.Text = change >= 0
                ? $"{change:N2} ₺"
                : $"-{Math.Abs(change):N2} ₺ (Eksik)";
            lblMixedChange.ForeColor = change >= 0
                ? System.Drawing.Color.Green
                : System.Drawing.Color.Red;
        }

        // Sadece ödeme onayını işler
        private void ConfirmPayment()
        {
            try
            {
                if (rbCash.Checked)
                    ConfirmedPayment = BuildCashPayment();
                else if (rbBank.Checked)
                    ConfirmedPayment = BuildBankPayment();
                else
                    ConfirmedPayment = BuildMixedPayment();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Sadece nakit ödeme nesnesi oluşturur
        private PaymentInfo BuildCashPayment()
        {
            if (!decimal.TryParse(txtCashGiven.Text, out decimal given) || given <= 0)
                throw new Exception("Geçerli bir nakit tutar girin.");

            if (given < _totalAmount)
                throw new Exception(
                    $"Alınan tutar yetersiz. Eksik: {_totalAmount - given:N2} ₺");

            return new PaymentInfo
            {
                TotalAmount = _totalAmount,
                PaymentMethod = "CASH",
                CashGiven = given,
                CashChange = given - _totalAmount
            };
        }

        // Sadece kart ödeme nesnesi oluşturur
        private PaymentInfo BuildBankPayment()
        {
            if (cmbBank.SelectedIndex < 0)
                throw new Exception("Lütfen bir banka seçin.");

            // Kart tutarı kutusu boş veya geçersizse
            if (!decimal.TryParse(txtBankAmount.Text, out decimal bankAmt) || bankAmt <= 0)
                throw new Exception("Lütfen geçerli bir kart tutarı girin.");

            // Girilen tutar toplam tutardan az
            if (bankAmt < _totalAmount)
            {
                decimal eksik = _totalAmount - bankAmt;
                throw new Exception(
                    $"Kart tutarı yetersiz!\n\n" +
                    $"Ödenecek Tutar : {_totalAmount:N2} ₺\n" +
                    $"Girilen Tutar  : {bankAmt:N2} ₺\n" +
                    $"Eksik Kalan    : {eksik:N2} ₺\n\n" +
                    $"Kalan {eksik:N2} ₺ için nakit veya başka kart ile ödeme yapılması gerekiyor.\n" +
                    $"Karma ödeme yapmak için 'Karma (Nakit+Kart)' seçeneğini kullanın.");
            }

            // Girilen tutar toplam tutardan fazla
            if (bankAmt > _totalAmount)
                throw new Exception(
                    $"Kart tutarı fazla!\n\n" +
                    $"Ödenecek Tutar : {_totalAmount:N2} ₺\n" +
                    $"Girilen Tutar  : {bankAmt:N2} ₺\n\n" +
                    $"Kart ödemesinde para üstü verilemez.\n" +
                    $"Lütfen tam tutarı ({_totalAmount:N2} ₺) girin.");

            var bank = _banks[cmbBank.SelectedIndex];

            return new PaymentInfo
            {
                TotalAmount = _totalAmount,
                PaymentMethod = "BANK",
                BankAccountId = bank.Id,
                BankName = bank.Name,
                BankAmount = _totalAmount // Her zaman tam tutar
            };
        }

        // Sadece karma ödeme nesnesi oluşturur
        private PaymentInfo BuildMixedPayment()
        {
            if (cmbBank.SelectedIndex < 0)
                throw new Exception("Lütfen bir banka seçin.");

            if (!decimal.TryParse(txtBankAmount.Text, out decimal bankAmt) || bankAmt <= 0)
                throw new Exception("Geçerli bir kart tutarı girin.");

            if (bankAmt >= _totalAmount)
                throw new Exception("Kart tutarı toplam tutara eşit veya fazla olamaz. Kart ödemesini seçin.");

            decimal remaining = _totalAmount - bankAmt;

            if (!decimal.TryParse(txtMixedCashGiven.Text, out decimal cashGiven) || cashGiven <= 0)
                throw new Exception("Geçerli bir nakit tutar girin.");

            if (cashGiven < remaining)
                throw new Exception(
                    $"Alınan nakit yetersiz. Kalan: {remaining:N2} ₺");

            var bank = _banks[cmbBank.SelectedIndex];

            return new PaymentInfo
            {
                TotalAmount = _totalAmount,
                PaymentMethod = "MIXED",
                BankAccountId = bank.Id,
                BankName = bank.Name,
                BankAmount = bankAmt,
                CashAmount = remaining,
                CashGiven = cashGiven,
                CashChange = cashGiven - remaining
            };
        }
    }
}
