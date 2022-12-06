using System.Drawing;
// For the purpose of debugging.
using System.Windows;

namespace scale
{
    public class ScalePainter
    {
        private MathModel ScaleData { get; set; }

        private Brush MainBrush { get; set; }
        private Pen MainPen { get; set; }

        private int ScaleLength { get; set; }
        // The unit of the scale: How big the numbers are.
        private double ScaleUnit { get; set; }
        private int ScaleCount { get; set; }
        // The lines thicknesses: The proportions of the base line to the width shell be well looking.
        private int Thickness { get; set; }

        public ScalePainter(MathModel mathModel, Brush mainBrush, Pen mainPen)
        {
            ScaleData = mathModel;

            MainBrush = mainBrush;
            MainPen = mainPen;
        }

        public void DrawNumberLine(Graphics g, int formsPanelWidth, int formsPanelHeight)
        {
            ScaleLength = formsPanelWidth - 40;
            ScaleUnit = GetDecimalPlacesScale(ScaleData.GetScaleBegin());
            double tmpScaleCount = GetDecimalPlacesScale(ScaleData.GetScaleEnd());
            if (ScaleUnit > tmpScaleCount)
                ScaleUnit = tmpScaleCount;
            ScaleCount = GetScaleCount();
            g.FillRectangle(MainBrush, 10, formsPanelHeight / 2 - (ScaleLength / 100), formsPanelWidth - 20, ScaleLength / 50);
            
            // The scale is painted.
            for (int i = 0; i <= ScaleCount; i++)
            {
                g.FillRectangle(MainBrush, 20 + (i * (ScaleLength / (ScaleCount))), formsPanelHeight / 2 - (ScaleLength / 28), ScaleLength / 100, ScaleLength / 14);
                g.DrawString((ScaleData.GetScaleBegin() + i * ScaleUnit).ToString(), new Font("Segoe UI", 13), MainBrush, 15 + (i * (ScaleLength / (ScaleCount)) - 1), formsPanelHeight / 2 + (ScaleLength / 20));
            }
        }

        private double GetDecimalPlacesScale(double number)
        {
            string decimalPlaces = number.ToString();
            string[] splitNumberString = decimalPlaces.Split(',');
            if (splitNumberString.Length > 1)
                return DefineUnit(-splitNumberString[1].Length);
            int zeros = 0;
            for (int i = decimalPlaces.Length - 1; i > 0; i--)
            {
                if (decimalPlaces[i] == '0')
                    zeros++;
                else
                    break;
            }
            return DefineUnit(zeros);
        }

        private int GetScaleCount()
        {
            return (int)((ScaleData.GetScaleEnd() - ScaleData.GetScaleBegin()) / ScaleUnit);
        }

        private double DefineUnit(int scaleUnit)
        {
            double defaultScale = 1;
            if (scaleUnit > 0)
            {
                for (int i = 0; i < ScaleUnit; i++)
                    defaultScale *= 10;
            }
            else if (scaleUnit < 0)
            {
                for (int i = 0; i > ScaleCount; i--)
                    defaultScale *= 0.1;
            }
            return defaultScale;
        }
    }
}