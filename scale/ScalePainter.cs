using System.Drawing;

namespace scale
{
    public class ScalePainter
    {
        private MathModel ScaleData { get; set; }

        private Brush MainBrush { get; set; }
        private Pen MainPen { get; set; }

        private int ScaleLength { get; set; }
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
            g.FillRectangle(MainBrush, 10, formsPanelHeight / 2 - (ScaleLength / 100), formsPanelWidth - 20, ScaleLength / 50);
            // TODO: scaling and values
        }
    }
}