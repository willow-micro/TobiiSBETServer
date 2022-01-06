﻿// Target: .NET 6 (LTS)

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
using System.ComponentModel;
using System.Diagnostics;
// Third-party
using EyeTracking;


namespace TobiiSBETServer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
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
            // Notifying
            DataContext = this;
            // Event handlers
            ContentRendered += this.OnContentRendered;
            Closed += this.OnClosed;
            this.StatusStr = "Initialized";
            this.SerialNumberStr = "serialnumber";
            this.DeviceNameStr = "devicename";
        }
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
        /// Internal field for the binding property StatusStr
        /// </summary>
        private string statusStr;
        /// <summary>
        /// A XAML binding property
        /// </summary>
        public string StatusStr
        {
            get { return statusStr; }
            set
            {
                statusStr = value;
                NotifyPropertyChanged(nameof(StatusStr));
            }
        }

        /// <summary>
        /// Internal field for the binding property SerialNumberStr
        /// </summary>
        private string serialNumberStr;
        /// <summary>
        /// A XAML binding property
        /// </summary>
        public string SerialNumberStr
        {
            get { return serialNumberStr; }
            set
            {
                serialNumberStr = value;
                NotifyPropertyChanged(nameof(SerialNumberStr));
            }
        }
        /// <summary>
        /// Internal field for the binding property DeviceNameStr
        /// </summary>
        private string deviceNameStr;
        /// <summary>
        /// A XAML binding property
        /// </summary>
        public string DeviceNameStr
        {
            get { return deviceNameStr; }
            set
            {
                deviceNameStr = value;
                NotifyPropertyChanged(nameof(DeviceNameStr));
            }
        }
        #endregion

        #region Event handlers
        /// <summary>
        /// Called when all content was loaded.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Args</param>
        private void OnContentRendered(object sender, EventArgs e)
        {
            Debug.Print("Debug: ContentRendered");
        }

        /// <summary>
        /// Called when app was closed.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Args</param>
        private void OnClosed(object sender, EventArgs e)
        {
            Debug.Print("Debug: Closed");
        }

        /// <summary>
        /// Ask user to close or not when the Esc key was pressed
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Args</param>
        private void AppCloseEvent(object sender, ExecutedRoutedEventArgs e)
        {
            Debug.Print("Debug: AppClose");

            if (MessageBox.Show("Are you sure to close?", "Close", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                //this.eyeTracker.StopReceivingGazeData();
                this.Close();
            }
        }
        #endregion

        #region Private methods

        #endregion
    }
}
