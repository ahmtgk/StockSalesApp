using ClosedXML.Excel;
using StockSalesApp.Entities;
using System;
using System.Collections.Generic;

namespace StockSalesApp.Business
{
    public class ExcelExportService
    {
        // Satış raporunu Excel'e aktar
        public void ExportSalesReport(List<Sale> sales, DateTime start, DateTime end, string path)
        {
            using (var wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add("Satış Raporu");

                SetTitle(ws, $"Satış Raporu  |  {start:dd.MM.yyyy} — {end:dd.MM.yyyy}", 5);
                SetHeaders(ws, 2, new[] { "Satış No", "Kasiyer", "Toplam Tutar (₺)", "Ödeme Yöntemi", "Tarih" });

                int row = 3;
                decimal grandTotal = 0;

                foreach (var s in sales)
                {
                    ws.Cell(row, 1).Value = s.Id;
                    ws.Cell(row, 2).Value = s.Username;
                    ws.Cell(row, 3).Value = s.TotalAmount;
                    ws.Cell(row, 3).Style.NumberFormat.Format = "#,##0.00";
                    ws.Cell(row, 4).Value = s.PaymentMethod ?? "-";
                    ws.Cell(row, 5).Value = s.SaleDate.ToString("dd.MM.yyyy HH:mm");
                    grandTotal += s.TotalAmount;
                    row++;
                }

                SetTotalRow(ws, row, 3, grandTotal, 5);
                FormatWorksheet(ws, 5);
                wb.SaveAs(path);
            }
        }

        // En çok satılan ürünleri Excel'e aktar
        public void ExportTopProducts(List<TopProduct> products, DateTime start, DateTime end, string path)
        {
            using (var wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add("En Çok Satılan");

                SetTitle(ws, $"En Çok Satılan  |  {start:dd.MM.yyyy} — {end:dd.MM.yyyy}", 3);
                SetHeaders(ws, 2, new[] { "Ürün Adı", "Satılan Adet", "Toplam Gelir (₺)" });

                int row = 3;
                foreach (var p in products)
                {
                    ws.Cell(row, 1).Value = p.ProductName;
                    ws.Cell(row, 2).Value = p.TotalQuantity;
                    ws.Cell(row, 3).Value = p.TotalRevenue;
                    ws.Cell(row, 3).Style.NumberFormat.Format = "#,##0.00";
                    row++;
                }

                FormatWorksheet(ws, 3);
                wb.SaveAs(path);
            }
        }

        // Stok durumunu Excel'e aktar
        public void ExportStockReport(List<Product> products, string path)
        {
            using (var wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add("Stok Raporu");

                SetTitle(ws, $"Stok Durumu  |  {DateTime.Today:dd.MM.yyyy}", 5);
                SetHeaders(ws, 2, new[] { "Ürün Adı", "Barkod", "Alış Fiyatı (₺)", "Satış Fiyatı (₺)", "Stok" });

                int row = 3;
                foreach (var p in products)
                {
                    ws.Cell(row, 1).Value = p.Name;
                    ws.Cell(row, 2).Value = p.Barcode;
                    ws.Cell(row, 3).Value = p.PurchasePrice;
                    ws.Cell(row, 3).Style.NumberFormat.Format = "#,##0.00";
                    ws.Cell(row, 4).Value = p.SalePrice;
                    ws.Cell(row, 4).Style.NumberFormat.Format = "#,##0.00";
                    ws.Cell(row, 5).Value = p.StockQuantity;

                    if (p.StockQuantity == 0)
                        ws.Row(row).Style.Fill.BackgroundColor = XLColor.FromArgb(255, 200, 200);
                    else if (p.StockQuantity <= 5)
                        ws.Row(row).Style.Fill.BackgroundColor = XLColor.FromArgb(255, 240, 200);

                    row++;
                }

                FormatWorksheet(ws, 5);
                wb.SaveAs(path);
            }
        }

        // ─── PRIVATE METODLAR ────────────────────────────────────────────

        private void SetTitle(IXLWorksheet ws, string title, int colCount)
        {
            ws.Cell(1, 1).Value = title;
            ws.Range(1, 1, 1, colCount).Merge();
            ws.Cell(1, 1).Style.Font.Bold = true;
            ws.Cell(1, 1).Style.Font.FontSize = 14;
            ws.Cell(1, 1).Style.Fill.BackgroundColor = XLColor.FromArgb(30, 58, 107);
            ws.Cell(1, 1).Style.Font.FontColor = XLColor.White;
            ws.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
        }

        private void SetHeaders(IXLWorksheet ws, int row, string[] headers)
        {
            for (int i = 0; i < headers.Length; i++)
            {
                ws.Cell(row, i + 1).Value = headers[i];
                ws.Cell(row, i + 1).Style.Font.Bold = true;
                ws.Cell(row, i + 1).Style.Fill.BackgroundColor = XLColor.FromArgb(46, 95, 163);
                ws.Cell(row, i + 1).Style.Font.FontColor = XLColor.White;
                ws.Cell(row, i + 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            }
        }

        private void SetTotalRow(IXLWorksheet ws, int row, int totalCol, decimal total, int colCount)
        {
            ws.Cell(row, 1).Value = "TOPLAM";
            ws.Range(row, 1, row, totalCol - 1).Merge();
            ws.Cell(row, totalCol).Value = total;
            ws.Cell(row, totalCol).Style.NumberFormat.Format = "#,##0.00";
            ws.Range(row, 1, row, colCount).Style.Font.Bold = true;
            ws.Range(row, 1, row, colCount).Style.Fill.BackgroundColor =
                XLColor.FromArgb(200, 230, 200);
        }

        private void FormatWorksheet(IXLWorksheet ws, int colCount)
        {
            ws.Columns(1, colCount).AdjustToContents();
            ws.SheetView.FreezeRows(2);
        }
    }
}
