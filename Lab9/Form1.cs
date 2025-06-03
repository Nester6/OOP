using System;
using System.Drawing;
using System.Windows.Forms;

namespace ParametricGraph
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            if (!double.TryParse(inputR.Text, out double r)) return;
            if (!double.TryParse(inputH.Text, out double h)) return;
            if (!double.TryParse(inputTMin.Text, out double tMin)) return;
            if (!double.TryParse(inputTMax.Text, out double tMax)) return;
            if (tMin >= tMax) return;

            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int centerX = canvas.Width / 2;
            int centerY = canvas.Height / 2;
            float scale = 30f;

            using Pen axisPen = new Pen(Color.Gray, 1);
            g.DrawLine(axisPen, 0, centerY, canvas.Width, centerY); // X
            g.DrawLine(axisPen, centerX, 0, centerX, canvas.Height); // Y

            for (int x = centerX; x < canvas.Width; x += (int)scale)
                g.DrawString(((x - centerX) / scale).ToString(), DefaultFont, Brushes.Black, x, centerY + 2);
            for (int x = centerX; x > 0; x -= (int)scale)
                g.DrawString(((x - centerX) / scale).ToString(), DefaultFont, Brushes.Black, x, centerY + 2);
            for (int y = centerY; y < canvas.Height; y += (int)scale)
                g.DrawString((-(y - centerY) / scale).ToString(), DefaultFont, Brushes.Black, centerX + 2, y);
            for (int y = centerY; y > 0; y -= (int)scale)
                g.DrawString((-(y - centerY) / scale).ToString(), DefaultFont, Brushes.Black, centerX + 2, y);

            using Pen graphPen = new Pen(Color.Red, 2);
            PointF? prevPoint = null;

            for (double t = tMin; t <= tMax; t += 0.01)
            {
                double x = r * t - h * Math.Sin(t);
                double y = r - h * Math.Cos(t);

                PointF screenPoint = new PointF(
                    centerX + (float)(x * scale),
                    centerY - (float)(y * scale)
                );

                if (prevPoint != null)
                    g.DrawLine(graphPen, prevPoint.Value, screenPoint);

                prevPoint = screenPoint;
            }
        }

        private void drawButton_Click(object sender, EventArgs e)
        {
            canvas.Invalidate();
        }
    }
}
