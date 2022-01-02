// Target: .NET Core 3.1 (LTS)

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
using System.Windows.Navigation;
using System.Windows.Shapes;
// Additional
// Third-party
using EyeTracking;


namespace TobiiSBETServer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Properties

        #endregion

        #region Fields
        /// <summary>
        /// An instance from EyeTracking.TobiiSBETDriver
        /// </summary>
        private readonly TobiiSBEyeTracker eyeTracker;
        /// <summary>
        /// An instance from EyeTracking.PupilDataProcessor
        /// </summary>
        private readonly PupilDataProcessor pupilDataProcessor;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            // Hook event handlers
            ContentRendered += this.MainWindowContentRendered;
            Closed += this.OnClosed;
        }
        #endregion

        #region Event handlers
        /// <summary>
        /// Called when all content was loaded.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Args</param>
        private void MainWindowContentRendered(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Ask user to close or not when the Esc key was pressed
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Args</param>
        private void AppCloseEvent(object sender, ExecutedRoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure to close?", "Close", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                //this.eyeTracker.StopReceivingGazeData();
                this.Close();
            }
        }

        /// <summary>
        /// Called when app was closed.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Args</param>
        private void OnClosed(object sender, EventArgs e)
        {

        }
        #endregion

        #region Private methods

        #endregion
    }
}
