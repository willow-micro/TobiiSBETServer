// Target: .NET 6 (LTS)

// Default
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
// Additional
using System.Diagnostics;
// Third-party


namespace TobiiSBETServer
{
    /// <summary>
    /// Interaction logic for PreviewWindow.xaml
    /// </summary>
    public partial class PreviewWindow : Window
    {
        #region Fields
        /// <summary>
        /// Diameter in pixels for the gaze point
        /// </summary>
        private readonly double pointDiameter;
        /// <summary>
        /// Gaze point for preview
        /// </summary>
        private readonly Ellipse gazePoint;
        #endregion

        #region Constructors
        public PreviewWindow(double pointRadius)
        {
            InitializeComponent();
            pointDiameter = pointRadius * 2.0;
            gazePoint = new Ellipse()
            {
                Fill = Brushes.Transparent,
                Width = pointDiameter,
                Height = pointDiameter
            };
            PreviewCanvas.Children.Add(gazePoint);
        }
        #endregion

        #region Public methods
        public void ShowGazePoint()
        {
            Dispatcher.Invoke(() =>
            {
                gazePoint.Fill = Brushes.DarkBlue;
            }); 
        }

        public void HideGazePoint()
        {
            Dispatcher.Invoke(() =>
            {
                gazePoint.Fill = Brushes.Transparent;
            });
        }

        public void PlaceGazePoint(double screenWidth, double screenHeight, double x, double y)
        {
            Dispatcher.Invoke(() =>
            {
                Canvas.SetLeft(gazePoint, x * 640 / screenWidth - pointDiameter / 2.0);
                Canvas.SetTop(gazePoint, y * 360 / screenHeight - pointDiameter / 2.0);
            });
        }
        #endregion
    }
}
