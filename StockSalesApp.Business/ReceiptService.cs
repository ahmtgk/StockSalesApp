using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using StockSalesApp.Entities;
using System.IO;

namespace StockSalesApp.Business
{
    public static class ReceiptService
    {
        // QuestPDF lisans ayarı (.NET 8 için)
        static ReceiptService()
        {
            QuestPDF.Settings.License = LicenseType.Community;
        }

        public static string GenerateReceipt(
            int saleId,
            List<SaleDetail> details,
            PaymentInfo payment)
        {
            // Fişler klasörünü oluştur
            string folder = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "StockSalesApp", "Receipts");
            Directory.CreateDirectory(folder);

            string path = Path.Combine(folder, $"Fis_{saleId}_{DateTime.Now:yyyyMMddHHmmss}.pdf");

            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A5);
                    page.Margin(1.5f, Unit.Centimetre);
                    page.DefaultTextStyle(x => x.FontSize(10).FontFamily("Arial"));

                    page.Content().Column(col =>
                    {
                        // Başlık
                        col.Item().AlignCenter().Text("SATIŞ FİŞİ")
                            .FontSize(18).Bold();
                        col.Item().AlignCenter().Text($"Fiş No: #{saleId}")
                            .FontSize(11);
                        col.Item().AlignCenter().Text(DateTime.Now.ToString("dd.MM.yyyy HH:mm"))
                            .FontSize(10);
                        col.Item().PaddingVertical(5).LineHorizontal(1);

                        // Ürün listesi başlık
                        col.Item().Row(row =>
                        {
                            row.RelativeItem(3).Text("Ürün").Bold();
                            row.RelativeItem(1).AlignCenter().Text("Adet").Bold();
                            row.RelativeItem(2).AlignRight().Text("Birim").Bold();
                            row.RelativeItem(2).AlignRight().Text("Toplam").Bold();
                        });
                        col.Item().LineHorizontal(0.5f);

                        // Ürün satırları
                        foreach (var d in details)
                        {
                            col.Item().Row(row =>
                            {
                                row.RelativeItem(3).Text(d.ProductName);
                                row.RelativeItem(1).AlignCenter().Text(d.Quantity.ToString());
                                row.RelativeItem(2).AlignRight().Text($"{d.UnitPrice:N2} ₺");
                                row.RelativeItem(2).AlignRight().Text($"{d.TotalPrice:N2} ₺");
                            });
                        }

                        col.Item().LineHorizontal(1);

                        // Toplam
                        col.Item().Row(row =>
                        {
                            row.RelativeItem(6).Text("TOPLAM").Bold();
                            row.RelativeItem(2).AlignRight()
                                .Text($"{payment.TotalAmount:N2} ₺").Bold();
                        });

                        col.Item().PaddingVertical(5).LineHorizontal(0.5f);

                        // Ödeme detayı
                        col.Item().Text("ÖDEME BİLGİLERİ").Bold();

                        switch (payment.PaymentMethod)
                        {
                            case "CASH":
                                col.Item().Text($"Nakit Tahsilat : {payment.TotalAmount:N2} ₺");
                                col.Item().Text($"Alınan         : {payment.CashGiven:N2} ₺");
                                if (payment.CashChange > 0)
                                    col.Item().Text($"Para Üstü     : {payment.CashChange:N2} ₺");
                                break;

                            case "BANK":
                                col.Item().Text($"Kart Tahsilat  : {payment.TotalAmount:N2} ₺");
                                col.Item().Text($"Banka          : {payment.BankName}");
                                break;

                            case "MIXED":
                                col.Item().Text($"Kart           : {payment.BankAmount:N2} ₺  ({payment.BankName})");
                                col.Item().Text($"Nakit          : {payment.CashAmount:N2} ₺");
                                col.Item().Text($"Alınan Nakit   : {payment.CashGiven:N2} ₺");
                                if (payment.CashChange > 0)
                                    col.Item().Text($"Para Üstü     : {payment.CashChange:N2} ₺");
                                break;
                        }

                        col.Item().PaddingVertical(5).LineHorizontal(0.5f);
                        col.Item().AlignCenter().Text("Bizi tercih ettiğiniz için teşekkürler!")
                            .Italic().FontSize(9);
                    });
                });
            }).GeneratePdf(path);

            return path;
        }
    }
}
