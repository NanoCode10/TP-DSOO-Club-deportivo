using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using ClubDeportivo.Entidades;

namespace ClubDeportivo.Utilidades
{
    internal class ComprobantePrinter
    {
        private const float ContentWidthMm = 80f;
        private const float MarginMm = 10f;

        private static float MmTo100thInch(float mm) => mm / 25.4f * 100f;

        private ComprobanteActividadData? _data;

        public void Print(ComprobanteActividadData data, bool preview = true)
        {
            _data = data;

            var doc = new PrintDocument
            {
                DocumentName = $"Comprobante {data.NumeroComprobante}",
                OriginAtMargins = false
            };

            int width100th = (int)Math.Round(MmTo100thInch(ContentWidthMm + MarginMm * 2));
            int height100th = (int)Math.Round(MmTo100thInch(150f));

            doc.DefaultPageSettings.PaperSize = new PaperSize("Comprobante", width100th, height100th);
            doc.DefaultPageSettings.Landscape = false;

            doc.PrintPage += OnPrintPage;

            if (preview)
            {
                using var prev = new PrintPreviewDialog
                {
                    Document = doc,
                    Width = 400,
                    Height = 600,
                    StartPosition = FormStartPosition.CenterScreen
                };
                prev.ShowDialog();
            }
            else
            {
                doc.Print();
            }
        }

        private void OnPrintPage(object? sender, PrintPageEventArgs e)
        {
            if (_data is null) return;

            var g = e.Graphics!;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            var margin = MmTo100thInch(MarginMm);
            var contentWidth = MmTo100thInch(ContentWidthMm);

            float x = margin;
            float y = margin;
            float lineHeight = MmTo100thInch(6f);

            using var blackBrush = new SolidBrush(Color.Black);
            using var grayBrush = new SolidBrush(Color.Gray);
            using var boldFont = new Font("Arial", 10, FontStyle.Bold);
            using var normalFont = new Font("Arial", 9);
            using var smallFont = new Font("Arial", 8);
            using var largeFont = new Font("Arial", 12, FontStyle.Bold);

            // ENCABEZADO
            g.DrawString("CLUB DEPORTIVO", largeFont, blackBrush,
                        new RectangleF(x, y, contentWidth, MmTo100thInch(8f)),
                        new StringFormat { Alignment = StringAlignment.Center });
            y += MmTo100thInch(10f);

            g.DrawString("COMPROBANTE DE ACTIVIDAD", boldFont, blackBrush,
                        new RectangleF(x, y, contentWidth, MmTo100thInch(6f)),
                        new StringFormat { Alignment = StringAlignment.Center });
            y += MmTo100thInch(8f);

            g.DrawLine(new Pen(Color.Black, 1f), x, y, x + contentWidth, y);
            y += MmTo100thInch(5f);

            // INFORMACIÓN
            g.DrawString($"N°: {_data.NumeroComprobante}", normalFont, blackBrush, x, y);
            y += lineHeight;

            g.DrawString($"Fecha: {_data.FechaPago:dd/MM/yyyy HH:mm}", normalFont, blackBrush, x, y);
            y += lineHeight * 1.5f;

            // DATOS DEL PAGO
            g.DrawString("CLIENTE:", boldFont, blackBrush, x, y);
            y += lineHeight;
            g.DrawString(_data.NombreApellido, normalFont, blackBrush, x, y);
            y += lineHeight * 1.5f;

            g.DrawString("ACTIVIDAD:", boldFont, blackBrush, x, y);
            y += lineHeight;
            g.DrawString(_data.Actividad, normalFont, blackBrush, x, y);
            y += lineHeight * 1.5f;

            g.DrawString("MEDIO PAGO:", boldFont, blackBrush, x, y);
            y += lineHeight;
            g.DrawString(_data.MedioPago, normalFont, blackBrush, x, y);
            y += lineHeight * 1.5f;

            // MONTO
            g.DrawString("TOTAL PAGADO:", boldFont, blackBrush, x, y);
            y += lineHeight;
            g.DrawString($"$ {_data.Monto:N2}", boldFont, blackBrush, x, y);
            y += lineHeight * 2f;

            g.DrawLine(new Pen(Color.Black, 1f), x, y, x + contentWidth, y);
            y += MmTo100thInch(5f);

            // PIE
            g.DrawString("¡Gracias por su pago!", smallFont, grayBrush,
                        new RectangleF(x, y, contentWidth, MmTo100thInch(5f)),
                        new StringFormat { Alignment = StringAlignment.Center });

            e.HasMorePages = false;
        }
    }
}