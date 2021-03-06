// Target: .NET 6 (LTS)

// Default
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
// Additional
using System.ComponentModel;
// Third-party


namespace TobiiSBETServer
{
    /// <summary>
    /// Interaction logic for PreviewWindow.xaml
    /// </summary>
    public partial class PreviewWindow : Window, INotifyPropertyChanged
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

        #region XAML binding handler
        /// <summary>
        /// Event handler object for XAML binding properties
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Notifier for xaml binding properties
        /// </summary>
        /// <param name="name">Name of the property</param>
        /// <example>
        /// <code>
        /// private string _HogeStr;
        /// public string HogeStr
        /// {
        ///     get { return _HogeStr; }
        ///     set
        ///     {
        ///         _HogeStr = value;
        ///         NotifyPropertyChanged(nameof(HogeStr));
        ///     }
        /// }
        /// </code>
        /// </example>
        private void NotifyPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        #region XAML binding properties
        /// <summary>
        /// Internal field for the binding property
        /// </summary>
        private string previewStatusStr;
        /// <summary>
        /// A XAML binding property
        /// </summary>
        public string PreviewStatusStr
        {
            get { return previewStatusStr; }
            set
            {
                previewStatusStr = value;
                NotifyPropertyChanged(nameof(PreviewStatusStr));
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="pointRadius">Gaze point radius</param>
        public PreviewWindow(double pointRadius)
        {
            InitializeComponent();
            // For notifying
            DataContext = this;

            pointDiameter = pointRadius * 2.0;
            gazePoint = new Ellipse()
            {
                Fill = Brushes.Transparent,
                Width = pointDiameter,
                Height = pointDiameter
            };
            PreviewCanvas.Children.Add(gazePoint);
            PreviewStatusStr = "Valid:-- Move:-- X:-- Y:-- Velo:-- LPD:-- RPD:-- LFHF:--";
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

        /// <summary>
        /// Update status string in the bottom status bar
        /// </summary>
        /// <param name="data">Data to update</param>
        public void UpdateStatusStr(PreviewData data)
        {
            PreviewStatusStr = $"Valid:{(data.isValid ? "ok" : "no")} Move:{Enum.GetName(typeof(EyeTracking.EyeMovementType), data.eyeMovementType),11} X:{String.Format("{0,4:}", data.isValid ? data.x : 0)} Y:{String.Format("{0,4:}", data.isValid ? data.y : 0)} Velo:{String.Format("{0,5:0.00}", data.isValid ? data.angularVelocity : 0)} LPD:{String.Format("{0,4:0.00}", data.isValid ? data.leftPD : 0.0f)} RPD:{String.Format("{0,4:0.00}", data.isValid ? data.rightPD : 0.0f)} LFHF:{String.Format("{0,3:0.00}", data.latestLFHF)}";
        }
        #endregion
    }
}
