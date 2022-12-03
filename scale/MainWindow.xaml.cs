using System.Drawing;
using System.Windows;
using System.Windows.Forms;
using System;

namespace scale
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Graphics G { get; set; }

        private Brush MainBrush { get; set; }
        private Pen MainPen { get; set; }

        private MathModel ScaleData { get; set; }

        public MainWindow()
        {
            ScaleData = new MathModel();

            InitializeComponent();
        }

        private void Panel_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            G = e.Graphics;
            MainBrush = new SolidBrush(Color.Black);
            MainPen = new Pen(MainBrush);

            G.DrawLine(MainPen, new System.Drawing.Point(0, 0), new System.Drawing.Point((int) formsHost.MinWidth, (int) formsHost.MinHeight));
            // G.DrawLine(MainPen, new System.Drawing.Point(0, 0), new System.Drawing.Point(100, 100));
        }

        private void numberLine_Checked(object sender, RoutedEventArgs e)
        {
            ScaleData.SetScaleKind("numberLine");
        }

        private void timeLine_Checked(object sender, RoutedEventArgs e)
        {
            ScaleData.SetScaleKind("timeLine");
        }

        private void thermometer_Checked(object sender, RoutedEventArgs e)
        {
            ScaleData.SetScaleKind("thermometer");
        }

        private void begin_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            ScaleData.SetScaleBegin(double.Parse(begin.Text));
        }

        private void end_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            ScaleData.SetScaleBegin(double.Parse(end.Text));
        }
    }
}