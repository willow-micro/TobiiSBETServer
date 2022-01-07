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
        private string appStatusStr;
        /// <summary>
        /// A XAML binding property
        /// </summary>
        public string AppStatusStr
        {
            get { return appStatusStr; }
            set
            {
                appStatusStr = value;
                NotifyPropertyChanged(nameof(AppStatusStr));
            }
        }
        /// <summary>
        /// Internal field for the binding property
        /// </summary>
        private string deviceInfoStr;
        /// <summary>
        /// A XAML binding property
        /// </summary>
        public string DeviceInfoStr
        {
            get { return deviceInfoStr; }
            set
            {
                deviceInfoStr = value;
                NotifyPropertyChanged(nameof(DeviceInfoStr));
            }
        }
        /// <summary>
        /// Internal field for the binding property
        /// </summary>
        private string frequencyStr;
        /// <summary>
        /// A XAML binding property
        /// </summary>
        public string FrequencyStr
        {
            get { return frequencyStr; }
            set
            {
                frequencyStr = value;
                NotifyPropertyChanged(nameof(FrequencyStr));
            }
        }
        /// <summary>
        /// Internal field for the binding property
        /// </summary>
        private string screenDimensionsStr;
        /// <summary>
        /// A XAML binding property
        /// </summary>
        public string ScreenDimensionsStr
        {
            get { return screenDimensionsStr; }
            set
            {
                screenDimensionsStr = value;
                NotifyPropertyChanged(nameof(ScreenDimensionsStr));
            }
        }
        /// <summary>
        /// Internal field for the binding property
        /// </summary>
        private string deviceStatusStr;
        /// <summary>
        /// A XAML binding property
        /// </summary>
        public string DeviceStatusStr
        {
            get { return deviceStatusStr; }
            set
            {
                deviceStatusStr = value;
                NotifyPropertyChanged(nameof(DeviceStatusStr));
            }
        }
        /// <summary>
        /// Internal field for the binding property
        /// </summary>
        private bool isFixationFilterEnabled;
        /// <summary>
        /// A XAML binding property
        /// </summary>
        public bool IsFixationFilterEnabled
        {
            get { return isFixationFilterEnabled; }
            set
            {
                isFixationFilterEnabled = value;
                NotifyPropertyChanged(nameof(IsFixationFilterEnabled));
            }
        }
        /// <summary>
        /// Internal field for the binding property
        /// </summary>
        private int angularVelocityThreshold;
        /// <summary>
        /// A XAML binding property
        /// </summary>
        public int AngularVelocityThreshold
        {
            get { return angularVelocityThreshold; }
            set
            {
                angularVelocityThreshold = value;
                NotifyPropertyChanged(nameof(AngularVelocityThreshold));
            }
        }
        /// <summary>
        /// Internal field for the binding property
        /// </summary>
        private int durationThreshold;
        /// <summary>
        /// A XAML binding property
        /// </summary>
        public int DurationThreshold
        {
            get { return durationThreshold; }
            set
            {
                durationThreshold = value;
                NotifyPropertyChanged(nameof(DurationThreshold));
            }
        }
        /// <summary>
        /// Internal field for the binding property
        /// </summary>
        private int consecutiveDataCount;
        /// <summary>
        /// A XAML binding property
        /// </summary>
        public int ConsecutiveDataCount
        {
            get { return consecutiveDataCount; }
            set
            {
                consecutiveDataCount = value;
                NotifyPropertyChanged(nameof(ConsecutiveDataCount));
            }
        }
        /// <summary>
        /// Internal field for the binding property
        /// </summary>
        private bool isDebouncingEnabled;
        /// <summary>
        /// A XAML binding property
        /// </summary>
        public bool IsDebouncingEnabled
        {
            get { return isDebouncingEnabled; }
            set
            {
                isDebouncingEnabled = value;
                NotifyPropertyChanged(nameof(IsDebouncingEnabled));
            }
        }
        /// <summary>
        /// Internal field for the binding property
        /// </summary>
        private int debounceTime;
        /// <summary>
        /// A XAML binding property
        /// </summary>
        public int DebounceTime
        {
            get { return debounceTime; }
            set
            {
                debounceTime = value;
                NotifyPropertyChanged(nameof(DebounceTime));
            }
        }
        /// <summary>
        /// Internal field for the binding property
        /// </summary>
        private bool isLFHFComputerEnabled;
        /// <summary>
        /// A XAML binding property
        /// </summary>
        public bool IsLFHFComputerEnabled
        {
            get { return isLFHFComputerEnabled; }
            set
            {
                isLFHFComputerEnabled = value;
                NotifyPropertyChanged(nameof(IsLFHFComputerEnabled));
            }
        }
        /// <summary>
        /// Internal field for the binding property
        /// </summary>
        private float lfLowFreq;
        /// <summary>
        /// A XAML binding property
        /// </summary>
        public float LFLowFreq
        {
            get { return lfLowFreq; }
            set
            {
                lfLowFreq = value;
                NotifyPropertyChanged(nameof(LFLowFreq));
            }
        }
        /// <summary>
        /// Internal field for the binding property
        /// </summary>
        private float lfHighFreq;
        /// <summary>
        /// A XAML binding property
        /// </summary>
        public float LFHighFreq
        {
            get { return lfHighFreq; }
            set
            {
                lfHighFreq = value;
                NotifyPropertyChanged(nameof(LFHighFreq));
            }
        }
        /// <summary>
        /// Internal field for the binding property
        /// </summary>
        private float hfLowFreq;
        /// <summary>
        /// A XAML binding property
        /// </summary>
        public float HFLowFreq
        {
            get { return hfLowFreq; }
            set
            {
                hfLowFreq = value;
                NotifyPropertyChanged(nameof(HFLowFreq));
            }
        }
        /// <summary>
        /// Internal field for the binding property
        /// </summary>
        private float hfHighFreq;
        /// <summary>
        /// A XAML binding property
        /// </summary>
        public float HFHighFreq
        {
            get { return hfHighFreq; }
            set
            {
                hfHighFreq = value;
                NotifyPropertyChanged(nameof(HFHighFreq));
            }
        }
        /// <summary>
        /// Internal field for the binding property
        /// </summary>
        private float idealFreqResolution;
        /// <summary>
        /// A XAML binding property
        /// </summary>
        public float IdealFreqResolution
        {
            get { return idealFreqResolution; }
            set
            {
                idealFreqResolution = value;
                NotifyPropertyChanged(nameof(IdealFreqResolution));
            }
        }
        /// <summary>
        /// Internal field for the binding property
        /// </summary>
        private float computeSpanSec;
        /// <summary>
        /// A XAML binding property
        /// </summary>
        public float ComputeSpanSec
        {
            get { return computeSpanSec; }
            set
            {
                computeSpanSec = value;
                NotifyPropertyChanged(nameof(ComputeSpanSec));
            }
        }
        /// <summary>
        /// Internal field for the binding property
        /// </summary>
        private int portNumber;
        /// <summary>
        /// A XAML binding property
        /// </summary>
        public int PortNumber
        {
            get { return portNumber; }
            set
            {
                portNumber = value;
                NotifyPropertyChanged(nameof(PortNumber));
            }
        }
        /// <summary>
        /// Internal field for the binding property
        /// </summary>
        private string serverURL;
        /// <summary>
        /// A XAML binding property
        /// </summary>
        public string ServerURL
        {
            get { return serverURL; }
            set
            {
                serverURL = value;
                NotifyPropertyChanged(nameof(ServerURL));
            }
        }
        /// <summary>
        /// Internal field for the binding property
        /// </summary>
        private bool isETStartButtonEnabled;
        /// <summary>
        /// A XAML binding property
        /// </summary>
        public bool IsETStartButtonEnabled
        {
            get { return isETStartButtonEnabled; }
            set
            {
                isETStartButtonEnabled = value;
                NotifyPropertyChanged(nameof(IsETStartButtonEnabled));
            }
        }
        /// <summary>
        /// Internal field for the binding property
        /// </summary>
        private bool isETStopButtonEnabled;
        /// <summary>
        /// A XAML binding property
        /// </summary>
        public bool IsETStopButtonEnabled
        {
            get { return isETStopButtonEnabled; }
            set
            {
                isETStopButtonEnabled = value;
                NotifyPropertyChanged(nameof(IsETStopButtonEnabled));
            }
        }
        /// <summary>
        /// Internal field for the binding property
        /// </summary>
        private bool isShowPreviewButtonEnabled;
        /// <summary>
        /// A XAML binding property
        /// </summary>
        public bool IsShowPreviewButtonEnabled
        {
            get { return isShowPreviewButtonEnabled; }
            set
            {
                isShowPreviewButtonEnabled = value;
                NotifyPropertyChanged(nameof(IsShowPreviewButtonEnabled));
            }
        }
        /// <summary>
        /// Internal field for the binding property
        /// </summary>
        private bool isWSStartButtonEnabled;
        /// <summary>
        /// A XAML binding property
        /// </summary>
        public bool IsWSStartButtonEnabled
        {
            get { return isWSStartButtonEnabled; }
            set
            {
                isWSStartButtonEnabled = value;
                NotifyPropertyChanged(nameof(IsWSStartButtonEnabled));
            }
        }
        /// <summary>
        /// Internal field for the binding property
        /// </summary>
        private bool isWSStopButtonEnabled;
        /// <summary>
        /// A XAML binding property
        /// </summary>
        public bool IsWSStopButtonEnabled
        {
            get { return isWSStopButtonEnabled; }
            set
            {
                isWSStopButtonEnabled = value;
                NotifyPropertyChanged(nameof(IsWSStopButtonEnabled));
            }
        }
        /// <summary>
        /// Internal field for the binding property
        /// </summary>
        private bool isNotETStarted;
        /// <summary>
        /// A XAML binding property
        /// </summary>
        public bool IsNotETStarted
        {
            get { return isNotETStarted; }
            set
            {
                isNotETStarted = value;
                NotifyPropertyChanged(nameof(IsNotETStarted));
            }
        }
        /// <summary>
        /// Internal field for the binding property
        /// </summary>
        private bool isNotWSStarted;
        /// <summary>
        /// A XAML binding property
        /// </summary>
        public bool IsNotWSStarted
        {
            get { return isNotWSStarted; }
            set
            {
                isNotWSStarted = value;
                NotifyPropertyChanged(nameof(IsNotWSStarted));
            }
        }
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
            // Initialize all binding paramters
            InitializeParameters();
            // Set button states
            UpdateAppState(AppState.WaitForETStart);
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

        private void ETStartButtonClicked(object sender, RoutedEventArgs e)
        {
            UpdateAppState(AppState.WaitForWSStart);
        }
        private void ETStopButtonClicked(object sender, RoutedEventArgs e)
        {
            UpdateAppState(AppState.WaitForETStart);
        }
        private void ShowPreviewButtonClicked(object sender, RoutedEventArgs e)
        {
            Debug.Print("ShowPreviewButton was clicked");
        }
        private void WSStartButtonClicked(object sender, RoutedEventArgs e)
        {
            UpdateAppState(AppState.WSStarted);
        }
        private void WSStopButtonClicked(object sender, RoutedEventArgs e)
        {
            UpdateAppState(AppState.WaitForWSStart);
        }
        #endregion

        #region Private methods
        private void UpdateAppState(AppState state)
        {
            switch (state)
            {
                case AppState.WaitForETStart:
                    this.IsNotETStarted = true;
                    this.IsNotWSStarted = true;
                    this.IsETStartButtonEnabled = true;
                    this.IsETStopButtonEnabled = false;
                    this.IsShowPreviewButtonEnabled = false;
                    this.IsWSStartButtonEnabled = false;
                    this.IsWSStopButtonEnabled = false;
                    break;
                case AppState.WaitForWSStart:
                    this.IsNotETStarted = false;
                    this.IsNotWSStarted = true;
                    this.IsETStartButtonEnabled = false;
                    this.IsETStopButtonEnabled = true;
                    this.IsShowPreviewButtonEnabled = true;
                    this.IsWSStartButtonEnabled = true;
                    this.IsWSStopButtonEnabled = false;
                    break;
                case AppState.WSStarted:
                    this.IsNotETStarted = false;
                    this.IsNotWSStarted = false;
                    this.IsETStartButtonEnabled = false;
                    this.IsETStopButtonEnabled = false;
                    this.IsShowPreviewButtonEnabled = true;
                    this.IsWSStartButtonEnabled = false;
                    this.IsWSStopButtonEnabled = true;
                    break;
                default:
                    this.IsNotETStarted = true;
                    this.IsNotWSStarted = true;
                    this.IsETStartButtonEnabled = true;
                    this.IsETStopButtonEnabled = false;
                    this.IsShowPreviewButtonEnabled = false;
                    this.IsWSStartButtonEnabled = false;
                    this.IsWSStopButtonEnabled = false;
                    break;
            }
        }
        private void InitializeParameters()
        {
            this.AppStatusStr = "Initialized";
            this.DeviceInfoStr = "modelname (serialno)";
            this.FrequencyStr = "[freq] Hz";
            this.ScreenDimensionsStr = "1920x1080 (X x Y mm)";
            this.DeviceStatusStr = "Ready";
            this.IsFixationFilterEnabled = true;
            this.AngularVelocityThreshold = 30;
            this.DurationThreshold = 150;
            this.ConsecutiveDataCount = 5;
            this.IsDebouncingEnabled = true;
            this.DebounceTime = 100;
            this.IsLFHFComputerEnabled = true;
            this.LFLowFreq = 0.04f;
            this.LFHighFreq = 0.15f;
            this.HFLowFreq = 0.15f;
            this.HFHighFreq = 0.50f;
            this.IdealFreqResolution = 0.04f;
            this.ComputeSpanSec = 0.5f;
            this.ServerURL = "ws://localhost";
            this.PortNumber = 3000;            
        }
        #endregion
    }
}
