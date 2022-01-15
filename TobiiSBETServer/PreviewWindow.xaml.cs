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
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="pointRadius">Gaze point radius</param>
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

        #region Event handlers
        /// <summary>
        /// Closing event handler
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Args</param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Show gaze point in the preview window
        /// </summary>
        public void ShowGazePoint()
        {
            Dispatcher.Invoke(() =>
            {
                gazePoint.Fill = Brushes.DarkBlue;
            }); 
        }
        /// <summary>
        /// Hide gaze point in the preview window
        /// </summary>
        public void HideGazePoint()
        {
            Dispatcher.Invoke(() =>
            {
                gazePoint.Fill = Brushes.Transparent;
            });
        }
        /// <summary>
        /// Place gaze point int the preview window
        /// </summary>
        /// <param name="screenWidth">Screen width</param>
        /// <param name="screenHeight">Screen height</param>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
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
