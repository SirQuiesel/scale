using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using Brush = System.Drawing.Brush;
using Button = System.Windows.Controls.Button;
using Color = System.Drawing.Color;
using Label = System.Windows.Controls.Label;
using Pen = System.Drawing.Pen;

namespace scale
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Graphics G { get; set; }

        // Forms Brushes
        private Brush MainBrush { get; set; }
        private Pen MainPen { get; set; }

        private MathModel ScaleData { get; set; }
        private ScalePainter PaintScale { get; set; }

        // Defines the Lnegth Width of an marker element.
        private GridLength MarkerWidth { get; set; }

        public MainWindow()
        {
            MainBrush = new SolidBrush(Color.Black);
            MainPen = new Pen(MainBrush);

            ScaleData = new MathModel();
            PaintScale = new ScalePainter(ScaleData, MainBrush, MainPen);
            MarkerWidth = new GridLength(100);

            InitializeComponent();
        }

        private void Panel_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            G = e.Graphics;
            PaintScale.DrawNumberLine(G, formsPanel.Width, formsPanel.Height);
        }

        private void numberLine_Checked(object sender, RoutedEventArgs e)
        {
            ScaleData.SetScaleKind("numberLine");
            paintButton.Content = "Zahlenstrahl zeichnen";

        }

        private void timeLine_Checked(object sender, RoutedEventArgs e)
        {
            ScaleData.SetScaleKind("timeLine");
            paintButton.Content = "Zeitstrahl zeichnen";
        }

        private void thermometer_Checked(object sender, RoutedEventArgs e)
        {
            ScaleData.SetScaleKind("thermometer");
            paintButton.Content = "Thermometer zeichnen";
        }

        private void saveStartAndEndPoints_Click(object sender, RoutedEventArgs e)
        {
            ScaleData.SetScaleBegin(double.Parse(begin.Text));
            ScaleData.SetScaleEnd(double.Parse(end.Text));
        }

        private void saveMarker_Click(object sender, RoutedEventArgs e)
        {
            double newMarker = double.Parse(marker.Text);
            if (!ScaleData.ContainsScaleValue(newMarker))
            {
                ScaleData.AddScaleValue(newMarker);
                listedMarkersLabel.Visibility = Visibility.Visible;
                AddMarkerToUIList(newMarker);
            }
        }

        private void paintButton_Click(object sender, RoutedEventArgs e)
        {
            formsPanel.Refresh();
        }

        /// Ads a marker label and a delete button to the listedMarkersPanel.
        /// The delete button will delete the markers value from the MathModel and the elementGrid from the listedMarkersPanel.
        private void AddMarkerToUIList(double marker)
        {
            Grid elementGrid = new Grid();
            RowDefinition elementRow = new RowDefinition();
            ColumnDefinition elementColumn0 = new ColumnDefinition();
            ColumnDefinition elementColumn1 = new ColumnDefinition();
            elementRow.Height = GridLength.Auto;
            elementColumn0.Width = MarkerWidth;
            elementColumn1.Width = MarkerWidth;
            elementGrid.RowDefinitions.Add(elementRow);
            elementGrid.ColumnDefinitions.Add(elementColumn0);
            elementGrid.ColumnDefinitions.Add(elementColumn1);

            Label markerLabel = new Label();
            markerLabel.Content = marker;
            Grid.SetRow(markerLabel, 0);
            Grid.SetColumn(markerLabel, 0);
            elementGrid.Children.Add(markerLabel);

            Button deleteMarker = new Button();
            deleteMarker.Content = "x";
            deleteMarker.MinWidth = 25;
            deleteMarker.Click += (sender, args) =>
            {
                ScaleData.DeleteScaleValue(marker);
                listedMarkersPanel.Children.Remove(elementGrid);
                if (ScaleData.ScaleValuesCount() == 0)
                    listedMarkersLabel.Visibility = Visibility.Hidden;
            };
            Grid.SetRow(deleteMarker, 0);
            Grid.SetColumn(deleteMarker, 1);
            elementGrid.Children.Add(deleteMarker);

            listedMarkersPanel.Children.Add(elementGrid);
        }
    }
}