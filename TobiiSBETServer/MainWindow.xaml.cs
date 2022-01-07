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
using WebSocketSharp.Server;


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
        private TobiiSBEyeTracker eyeTracker;
        /// <summary>
        /// An instance from EyeTracking.PupilDataProcessor
        /// </summary>
        private PupilDataProcessor pupilDataProcessor;
        /// <summary>
        /// Primary screen width in DIP
        /// </summary>
        private readonly double screenWidthInPixels;
        /// <summary>
        /// Primary screen height in DIP
        /// </summary>
        private readonly double screenHeightInPixels;
        /// <summary>
        /// WebSocket Server
        /// </summary>
        private WebSocketServer webSocketServer;
        /// <summary>
        /// Count time for debounce
        /// </summary>
        private long debounceTemp;
        /// <summary>
        /// Unix Time in ms when received gaze data last time
        /// </summary>
        private long prevUnixTimeInMs;
        /// <summary>
        /// Preview window
        /// </summary>
        private PreviewWindow previewWindow;
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
                ServerURL = $"ws://{GetHostAddress()}:{value}/{ServicePath}";
            }
        }
        /// <summary>
        /// Internal field for the binding property
        /// </summary>
        private string servicePath;
        /// <summary>
        /// A XAML binding property
        /// </summary>
        public string ServicePath
        {
            get { return servicePath; }
            set
            {
                servicePath = value;
                NotifyPropertyChanged(nameof(ServicePath));
                ServerURL = $"ws://{GetHostAddress()}:{PortNumber}/{value}";
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
            // Initialize XAML
            InitializeComponent();
            // For notifying
            DataContext = this;
            // Set event handlers
            ContentRendered += OnContentRendered;
            Closed += OnClosed;

            // Initialize internal parameters
            screenWidthInPixels = System.Windows.SystemParameters.PrimaryScreenWidth;
            screenHeightInPixels = System.Windows.SystemParameters.PrimaryScreenHeight;

            // Initialize all binding paramters
            InitializeParameters();

            // Set button states
            UpdateAppState(AppState.WaitForETStart);

            // Initialize eye tracker
            //InitializeEyeTracker();
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
            if (previewWindow != null)
            {
                previewWindow.Close();
            }
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
                if (previewWindow != null)
                {
                    previewWindow.Close();
                }
                //eyeTracker.StopReceivingGazeData();
                Close();
            }
        }

        private void ETStartButtonClicked(object sender, RoutedEventArgs e)
        {
            UpdateAppState(AppState.WaitForWSStart);
            //eyeTracker.StartReceivingGazeData();
        }
        private void ETStopButtonClicked(object sender, RoutedEventArgs e)
        {
            if (previewWindow != null)
            {
                previewWindow.Close();
            }
            UpdateAppState(AppState.WaitForETStart);
            //eyeTracker.StopReceivingGazeData();
        }
        private void ShowPreviewButtonClicked(object sender, RoutedEventArgs e)
        {
            Debug.Print("ShowPreviewButton was clicked");
            previewWindow = new PreviewWindow(4.0);
            previewWindow.Closing += (s, e) =>
            {
                IsShowPreviewButtonEnabled = true;
            };
            previewWindow.Show();
            IsShowPreviewButtonEnabled = false;
            //previewWindow.PlaceGazePoint(screenWidthInPixels, screenHeightInPixels, screenWidthInPixels / 2, screenHeightInPixels / 2);
        }
        private void WSStartButtonClicked(object sender, RoutedEventArgs e)
        {
            UpdateAppState(AppState.WSStarted);
            StartWSServer();
        }
        private void WSStopButtonClicked(object sender, RoutedEventArgs e)
        {
            UpdateAppState(AppState.WaitForWSStart);
            StopWSServer();
        }

        private void OnGazeData(object sender, OnGazeDataEventArgs e)
        {
            if (e.IsLeftValid &&
                0.0 <= e.LeftX && e.LeftX <= eyeTracker.GetScreenWidthInPixels() &&
                0.0 <= e.LeftY && e.LeftY <= eyeTracker.GetScreenHeightInPixels())
            {
                int xPos = (int)e.LeftX;
                int yPos = (int)e.LeftY;
                
                if (e.LeftEyeMovementType == EyeMovementType.Fixation)
                {
                    if (this.debounceTemp > DebounceTime)
                    {
                        long unixTimeInMs = GetUnixTimeInMs();
                        WSBroadCastString($"t{unixTimeInMs}x{xPos}y{yPos}");
                    }

                    previewWindow.ShowGazePoint();
                    previewWindow.PlaceGazePoint(eyeTracker.GetScreenWidthInPixels(), eyeTracker.GetScreenHeightInPixels(), e.LeftX, e.LeftY);

                    debounceTemp = 0;
                }
                else
                {
                    long unixTimeInMs = GetUnixTimeInMs();
                    debounceTemp += unixTimeInMs - prevUnixTimeInMs;
                    prevUnixTimeInMs = unixTimeInMs;

                    previewWindow.HideGazePoint();
                }
            }
        }
        #endregion

        #region Private methods
        private void UpdateAppState(AppState state)
        {
            switch (state)
            {
                case AppState.WaitForETStart:
                    IsNotETStarted = true;
                    IsNotWSStarted = true;
                    IsETStartButtonEnabled = true;
                    IsETStopButtonEnabled = false;
                    IsShowPreviewButtonEnabled = false;
                    IsWSStartButtonEnabled = false;
                    IsWSStopButtonEnabled = false;
                    AppStatusStr = "Eye Tracker is Ready";
                    break;
                case AppState.WaitForWSStart:
                    IsNotETStarted = false;
                    IsNotWSStarted = true;
                    IsETStartButtonEnabled = false;
                    IsETStopButtonEnabled = true;
                    IsShowPreviewButtonEnabled = true;
                    IsWSStartButtonEnabled = true;
                    IsWSStopButtonEnabled = false;
                    AppStatusStr = "Server is Ready";
                    break;
                case AppState.WSStarted:
                    IsNotETStarted = false;
                    IsNotWSStarted = false;
                    IsETStartButtonEnabled = false;
                    IsETStopButtonEnabled = false;
                    IsShowPreviewButtonEnabled = true;
                    IsWSStartButtonEnabled = false;
                    IsWSStopButtonEnabled = true;
                    AppStatusStr = "Server is Running";
                    break;
                default:
                    IsNotETStarted = true;
                    IsNotWSStarted = true;
                    IsETStartButtonEnabled = true;
                    IsETStopButtonEnabled = false;
                    IsShowPreviewButtonEnabled = false;
                    IsWSStartButtonEnabled = false;
                    IsWSStopButtonEnabled = false;
                    AppStatusStr = "Eye Tracker is Ready";
                    break;
            }
        }
        private void InitializeParameters()
        {
            AppStatusStr = "Initialized";
            DeviceInfoStr = "modelname (serialno)";
            FrequencyStr = "-- Hz";
            ScreenDimensionsStr = "-x- (-x- mm)";
            DeviceStatusStr = "Ready";
            IsFixationFilterEnabled = true;
            AngularVelocityThreshold = 30;
            DurationThreshold = 150;
            ConsecutiveDataCount = 5;
            IsDebouncingEnabled = true;
            DebounceTime = 100;
            IsLFHFComputerEnabled = true;
            LFLowFreq = 0.04f;
            LFHighFreq = 0.15f;
            HFLowFreq = 0.15f;
            HFHighFreq = 0.50f;
            IdealFreqResolution = 0.04f;
            ComputeSpanSec = 0.5f;
            ServicePath = "SBET";
            PortNumber = 8008;
            ServerURL = $"ws://{GetHostAddress()}:{PortNumber}/{ServicePath}";
        }

        private void InitializeEyeTracker()
        {
            try
            {
                eyeTracker = new TobiiSBEyeTracker(screenWidthInPixels, screenHeightInPixels, VelocityCalcType.UCSGazeVector, AngularVelocityThreshold, DurationThreshold);
                eyeTracker.OnGazeData += OnGazeData;
            }
            catch (ArgumentOutOfRangeException e)
            {
                Debug.Print(e.Message);
                Close();
            }
            catch (InvalidOperationException e)
            {
                if (MessageBox.Show(e.Message, "OK", MessageBoxButton.OK, MessageBoxImage.Error) == MessageBoxResult.OK)
                {
                    Close();
                }
            }

            DeviceInfoStr = $"{eyeTracker.GetModel()}[{eyeTracker.GetSerialNumber}]";
            FrequencyStr = "90 Hz";
            ScreenDimensionsStr = $"{eyeTracker.GetScreenWidthInPixels()}x{eyeTracker.GetScreenHeightInPixels()} ({eyeTracker.GetScreenWidthInMillimeters()}x{eyeTracker.GetScreenHeightInMillimeters()} mm)";
            DeviceStatusStr = "Initialized";
        }

        private void StartWSServer()
        {
            webSocketServer = new WebSocketServer($"ws://{GetHostAddress()}:{PortNumber}");
            webSocketServer.AddWebSocketService<ServerBehavior>($"/{ServicePath}");
            webSocketServer.Start();
            Debug.Print($"Server was started on {ServerURL}");
        }

        private void StopWSServer()
        {
            if (webSocketServer.IsListening)
            {
                webSocketServer.Stop();
            }                
            Debug.Print("Server was stopped");
        }

        private void WSBroadCastString(string payload)
        {
            if (webSocketServer.IsListening)
            {
                webSocketServer.WebSocketServices[$"/{ServicePath}"].Sessions.Broadcast(payload);
                Debug.Print($"Broadcast: {payload}");
            }
        }
        #endregion

        #region Static methods
        private static string GetHostAddress()
        {
            string ipAddress = "";
            string hostname = System.Net.Dns.GetHostName();
            System.Net.IPAddress[] addresses = System.Net.Dns.GetHostAddresses(hostname);
            foreach (System.Net.IPAddress address in addresses)
            {
                string ipAddressStr = address.ToString();
                if (ipAddressStr.IndexOf(".") > 0 && !ipAddressStr.StartsWith("127."))
                {
                    ipAddress = ipAddressStr;
                    break;
                }
            }
            return ipAddress;
        }

        private static long GetUnixTimeInMs()
        {
            DateTimeOffset now = DateTimeOffset.UtcNow;
            return now.ToUnixTimeMilliseconds();
        }
        #endregion
    }
}
