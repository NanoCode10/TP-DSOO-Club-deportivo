using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using ClubDeportivo.Entidades;

namespace ClubDeportivo.Forms.cobrar_cuota
{
    /// Renderiza credencial CR-80 (85.6 x 54 mm) con banda superior.
    internal sealed class CredencialPrinter
    {
        private const float CardWidthMm = 85.6f;
        private const float CardHeightMm = 54.0f;
        private const float CornerRadiusMm = 4.0f;
        private const float MarginMm = 3.5f;

        private static float MmTo100thInch(float mm) => mm / 25.4f * 100f;

        private SocioCardData? _data;

        public void Print(SocioCardData data, bool preview = true)
        {
            _data = data;

            var doc = new PrintDocument
            {
                DocumentName = $"Carnet Socio {data.CodSocio}",
                OriginAtMargins = false
            };
            doc.PrintPage += OnPrintPage;

            if (preview)
            {
                using var prev = new PrintPreviewDialog { Document = doc, Width = 900, Height = 700 };
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

            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            var w = MmTo100thInch(CardWidthMm);
            var h = MmTo100thInch(CardHeightMm);
            var r = MmTo100thInch(CornerRadiusMm);
            var m = MmTo100thInch(MarginMm);

            float x = (e.PageBounds.Width - w) / 2f;
            float y = (e.PageBounds.Height - h) / 2f;
            var cardRect = new RectangleF(x, y, w, h);

            using var white = new SolidBrush(Color.White);
            using var borderPen = new Pen(Color.FromArgb(40, 40, 40), 2f);
            using var bandBrush = new SolidBrush(Color.FromArgb(38, 166, 91)); // verde
            using var lightText = new SolidBrush(Color.White);
            using var darkText = new SolidBrush(Color.FromArgb(30, 30, 30));
            using var grayText = new SolidBrush(Color.FromArgb(90, 90, 90));

            using (var path = RoundedRect(cardRect, r))
            { g.FillPath(white, path); g.DrawPath(borderPen, path); }

            var bandRect = new RectangleF(cardRect.Left, cardRect.Top, cardRect.Width, MmTo100thInch(12f));
            using (var bandPath = RoundedRect(bandRect, r, topLeft: true, topRight: true, bottomLeft: false, bottomRight: false))
            { g.FillPath(bandBrush, bandPath); }

            using var fTitle = new Font("Segoe UI", 11, FontStyle.Bold);
            using var fBold = new Font("Segoe UI", 9, FontStyle.Bold);
            using var fNorm = new Font("Segoe UI", 9);
            using var fSmall = new Font("Segoe UI", 8);

            var titleRect = new RectangleF(bandRect.Left + MmTo100thInch(4f), bandRect.Top + MmTo100thInch(2.3f),
                                           bandRect.Width - MmTo100thInch(8f), bandRect.Height);
            g.DrawString("CLUB DEPORTIVO", fTitle, lightText, titleRect);

            float left = cardRect.Left + m;
            float top = bandRect.Bottom + MmTo100thInch(2.5f);
            float line = MmTo100thInch(6.0f);

            g.DrawString(_data.NombreApellido, fBold, darkText, new PointF(left, top)); top += line;
            g.DrawString($"Socio Nº: {_data.CodSocio}", fNorm, darkText, new PointF(left, top)); top += line;

            if (!string.IsNullOrWhiteSpace(_data.Documento))
            { g.DrawString($"Documento: {_data.Documento}", fNorm, darkText, new PointF(left, top)); top += line; }

            g.DrawString($"Email: {_data.Email}", fSmall, grayText, new PointF(left, top));
            top += MmTo100thInch(4.8f);
            g.DrawString($"Tel:   {_data.Telefono}", fSmall, grayText, new PointF(left, top));

            string vence = _data.Vencimiento.HasValue ? _data.Vencimiento.Value.ToString("dd/MM/yyyy") : "-";
            string estado = string.IsNullOrWhiteSpace(_data.Estado) ? "-" : _data.Estado;

            var rightColX = cardRect.Right - m - MmTo100thInch(40f);
            g.DrawString("Vence:", fSmall, grayText, new PointF(rightColX, bandRect.Bottom + MmTo100thInch(4.5f)));
            g.DrawString(vence, fBold, darkText, new PointF(rightColX + MmTo100thInch(12f), bandRect.Bottom + MmTo100thInch(4.2f)));

            g.DrawString("Estado:", fSmall, grayText, new PointF(rightColX, bandRect.Bottom + MmTo100thInch(11.0f)));
            g.DrawString(estado, fBold, darkText, new PointF(rightColX + MmTo100thInch(12f), bandRect.Bottom + MmTo100thInch(10.7f)));

            var footer = $"Emitido: {DateTime.Today:dd/MM/yyyy}";
            var sizeF = g.MeasureString(footer, fSmall);
            g.DrawString(footer, fSmall, grayText, new PointF(cardRect.Right - m - sizeF.Width, cardRect.Bottom - m - sizeF.Height));

            e.HasMorePages = false;
        }

        private static GraphicsPath RoundedRect(RectangleF r, float radius,
            bool topLeft = true, bool topRight = true, bool bottomLeft = true, bool bottomRight = true)
        {
            var path = new GraphicsPath();
            float d = radius * 2;

            if (topLeft) path.AddArc(r.Left, r.Top, d, d, 180, 90); else path.AddLine(r.Left, r.Top, r.Left, r.Top);
            if (topRight) path.AddArc(r.Right - d, r.Top, d, d, 270, 90); else path.AddLine(r.Right, r.Top, r.Right, r.Top);
            if (bottomRight) path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90); else path.AddLine(r.Right, r.Bottom, r.Right, r.Bottom);
            if (bottomLeft) path.AddArc(r.Left, r.Bottom - d, d, d, 90, 90); else path.AddLine(r.Left, r.Bottom, r.Left, r.Bottom);

            path.CloseFigure();
            return path;
        }
    }
}
