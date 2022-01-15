// Target: .NET 6 (LTS)

// Default
using System;
using System.Windows;
using System.Windows.Input;
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
        #nullable enable
        /// <summary>
        /// An instance from EyeTracking.PupilDataProcessor
        /// </summary>
        private PupilDataProcessor? pupilDataProcessor;
        #nullable disable
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
        /// Previous unix time in ms when received gaze data last time
        /// </summary>
        private long prevUnixTimeInMs;
        /// <summary>
        /// Preview window
        /// </summary>
        private readonly PreviewWindow previewWindow;
        /// <summary>
        /// Number of gaze data to collect
        /// </summary>
        private int collectGazeDataCount;
        /// <summary>
        /// If collecting gaze data, become true
        /// </summary>
        private bool isGazeDataCollecting;
        /// <summary>
        /// Array of gaze data to collect
        /// </summary>
        private SBGazeCollectData[] collectGazeDataArray;
        /// <summary>
        /// Previous eye movement type when received gaze data last time
        /// </summary>
        private EyeMovementType prevEyeMovementType;
        /// <summary>
        /// Previous gaze data
        /// </summary>
        private SBGazeCollectData prevGazeData;
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
                if (!isFixationFilterEnabled)
                {
                    IsDebouncingEnabled = isFixationFilterEnabled;
                }
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
                if (isDebouncingEnabled && !IsFixationFilterEnabled)
                {
                    IsFixationFilterEnabled = isDebouncingEnabled;
                }
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

            // Setup preview window
            previewWindow = new PreviewWindow(4.0);
            previewWindow.Closing += (s, e) =>
            {
                IsShowPreviewButtonEnabled = true;
            };

            // Initialize all binding paramters
            InitializeParameters();

            // Set button states
            UpdateAppState(AppState.WaitForETStart);

            // Initialize eye tracker
            InitializeEyeTracker();
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
            Debug.Print("OnContentRendered");
        }

        /// <summary>
        /// Called when app was closed.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Args</param>
        private void OnClosed(object sender, EventArgs e)
        {
            eyeTracker.StopReceivingGazeData();
            previewWindow.Close();
            Debug.Print("OnClosed");
        }

        /// <summary>
        /// Ask user to close or not when the Esc key was pressed
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Args</param>
        private void AppCloseEvent(object sender, ExecutedRoutedEventArgs e)
        {
            Debug.Print("AppCloseEvent(esc)");

            if (MessageBox.Show("Are you sure to close?", "Close", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Close();
            }
        }

        /// <summary>
        /// Click event handler for the start eye tracking button
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Args</param>
        private void ETStartButtonClicked(object sender, RoutedEventArgs e)
        {
            collectGazeDataCount = 0;
            isGazeDataCollecting = false;
            collectGazeDataArray = new SBGazeCollectData[ConsecutiveDataCount];

            if (IsDebouncingEnabled)
            {
                prevUnixTimeInMs = GetUnixTimeInMs();
                debounceTemp = (long)DebounceTime + 1;
                prevEyeMovementType = EyeMovementType.Unknown;
                prevGazeData = new SBGazeCollectData(GetUnixTimeInMs(), 0, 0);
            }

            if (IsLFHFComputerEnabled)
            {
                pupilDataProcessor = new PupilDataProcessor((int)eyeTracker.GetFrequency(), new FrequencyRange(LFLowFreq, LFHighFreq), new FrequencyRange(HFLowFreq, HFHighFreq), IdealFreqResolution, ComputeSpanSec);
            }

            eyeTracker.ModifyFixationVelocityThresh(IsFixationFilterEnabled ? AngularVelocityThreshold : 1);
            eyeTracker.ModifyFixationDurationThresh(IsFixationFilterEnabled ? DurationThreshold : 0);

            UpdateAppState(AppState.WaitForWSStart);
            eyeTracker.StartReceivingGazeData();
            DeviceStatusStr = "Tracking";
        }
        /// <summary>
        /// Click event handler for the stop eye tracker button
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Args</param>
        private void ETStopButtonClicked(object sender, RoutedEventArgs e)
        {
            previewWindow.Hide();
            UpdateAppState(AppState.WaitForETStart);
            eyeTracker.StopReceivingGazeData();
            DeviceStatusStr = "Ready";

            if (IsLFHFComputerEnabled)
            {
                pupilDataProcessor = null;
            }
        }
        /// <summary>
        /// Click event handler for the show preview window button
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Args</param>
        private void ShowPreviewButtonClicked(object sender, RoutedEventArgs e)
        {
            previewWindow.Show();
            IsShowPreviewButtonEnabled = false;
            previewWindow.PlaceGazePoint(screenWidthInPixels, screenHeightInPixels, screenWidthInPixels / 2, screenHeightInPixels / 2);
        }
        /// <summary>
        /// Click event handler for the start websocket server button
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Args</param>
        private void WSStartButtonClicked(object sender, RoutedEventArgs e)
        {
            UpdateAppState(AppState.WSStarted);
            StartWSServer();
        }
        /// <summary>
        /// Click event handler for the stop websocket server button
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Args</param>
        private void WSStopButtonClicked(object sender, RoutedEventArgs e)
        {
            UpdateAppState(AppState.WaitForWSStart);
            StopWSServer();
        }

        /// <summary>
        /// OnGazeData event handler. Receives gaze data from the eye tracker
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Args</param>
        private void OnGazeData(object sender, OnGazeDataEventArgs e)
        {
            // Gaze data (left)
            if (e.IsLeftValid)
            {
                long unixTime = GetUnixTimeInMs();
                int xPos = (int)(e.LeftX);
                int yPos = (int)(e.LeftY);

                // For FixationStarted event
                if (IsDebouncingEnabled)
                {
                    if (e.LeftEyeMovementType == EyeMovementType.Fixation)
                    {
                        if (previewWindow != null)
                        {
                            previewWindow.ShowGazePoint();
                            previewWindow.PlaceGazePoint(eyeTracker.GetScreenWidthInPixels(), eyeTracker.GetScreenHeightInPixels(), e.LeftX, e.LeftY);
                        }
                        if (this.debounceTemp > DebounceTime)
                        {
                            collectGazeDataCount = 0;
                            isGazeDataCollecting = true;
                        }
                        if (isGazeDataCollecting)
                        {
                            AppendSBGazeDataToCollection(GetUnixTimeInMs(), xPos, yPos);
                        }
                        if (collectGazeDataCount >= ConsecutiveDataCount)
                        {
                            isGazeDataCollecting = false;
                            SendSBGazeDataCollection();
                        }
                        debounceTemp = 0;
                    }
                    else
                    {
                        debounceTemp += unixTime - prevUnixTimeInMs;
                        prevUnixTimeInMs = unixTime;
                    }
                }
                else
                {
                    if (e.LeftEyeMovementType == EyeMovementType.Fixation)
                    {
                        if (previewWindow != null)
                        {
                            previewWindow.ShowGazePoint();
                            previewWindow.PlaceGazePoint(eyeTracker.GetScreenWidthInPixels(), eyeTracker.GetScreenHeightInPixels(), e.LeftX, e.LeftY);
                        }
                        if (collectGazeDataCount < ConsecutiveDataCount)
                        {
                            isGazeDataCollecting = true;
                            AppendSBGazeDataToCollection(unixTime, xPos, yPos);
                        }
                        if (collectGazeDataCount >= ConsecutiveDataCount)
                        {
                            isGazeDataCollecting = false;
                            collectGazeDataCount = 0;
                            SendSBGazeDataCollection();
                        }
                    }
                }

                // For FixationEnded event
                if (e.LeftEyeMovementType == EyeMovementType.Saccade &&
                    prevEyeMovementType == EyeMovementType.Fixation)
                {
                    string payloadText = $"e{WSEventID.FixationEnded},t{prevGazeData.time},x{prevGazeData.x},y{prevGazeData.y}";
                    Debug.Print($"{Enum.GetName(typeof(WSEventID), WSEventID.FixationEnded)}[{WSEventID.FixationEnded}]: {payloadText}");
                    if (!IsNotWSStarted)
                    {
                        WSBroadCastString(payloadText);
                    }
                }
                prevEyeMovementType = e.LeftEyeMovementType;
                prevGazeData = new SBGazeCollectData(unixTime, xPos, yPos);
            }

            // Pupil data
            // For LFHFComputed event
            if (IsLFHFComputerEnabled && pupilDataProcessor != null)
            {
                // Add diameter
                if (pupilDataProcessor.UpdateWith(new PupilDataForProcess(e.LeftPD, e.IsLeftPDValid)) == LFHFComputeStatus.Ready)
                {
                    long unixTime = GetUnixTimeInMs();
                    string payloadText = $"e{WSEventID.LFHFComputed},t{unixTime},r{pupilDataProcessor.LatestLFHF:F3}";
                    Debug.Print($"{Enum.GetName(typeof(WSEventID), WSEventID.LFHFComputed)}[{WSEventID.LFHFComputed}]: {payloadText}");
                    if (!IsNotWSStarted)
                    {
                        WSBroadCastString(payloadText);
                    }
                }
            }
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Update app state with a given state
        /// </summary>
        /// <param name="state">State for updating</param>
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
                    break;
            }
        }
        /// <summary>
        /// Initialize XAML binding parameters
        /// </summary>
        private void InitializeParameters()
        {
            AppStatusStr = "--";
            DeviceInfoStr = "--";
            FrequencyStr = "-- Hz";
            ScreenDimensionsStr = "-x- (-x- mm)";
            DeviceStatusStr = "--";
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
        /// <summary>
        /// Initialzie a eye tracker
        /// </summary>
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
            DeviceInfoStr = $"{eyeTracker.GetModel()}";
            FrequencyStr = $"{eyeTracker.GetFrequency():F2} Hz";
            ScreenDimensionsStr = $"{eyeTracker.GetScreenWidthInPixels()}x{eyeTracker.GetScreenHeightInPixels()} ({eyeTracker.GetScreenWidthInMillimeters():F2}x{eyeTracker.GetScreenHeightInMillimeters():F2} mm)";
            DeviceStatusStr = "Initialized";
        }
        /// <summary>
        /// Start websocket server
        /// </summary>
        private void StartWSServer()
        {
            webSocketServer = new WebSocketServer($"ws://{GetHostAddress()}:{PortNumber}");
            webSocketServer.AddWebSocketService<ServerBehavior>($"/{ServicePath}");
            webSocketServer.Start();
            Debug.Print($"Server was started on {ServerURL}");
        }
        /// <summary>
        /// Stop websocket server
        /// </summary>
        private void StopWSServer()
        {
            if (webSocketServer.IsListening)
            {
                webSocketServer.Stop();
            }                
            Debug.Print("Server was stopped");
        }
        /// <summary>
        /// Broadcast a given string from the running websocket server
        /// </summary>
        /// <param name="payload">A payload string to broadcast over the websocket connection</param>
        /// <exception cref="InvalidOperationException">"Websocket server is not running. Cannot broadcast."</exception>
        private void WSBroadCastString(string payload)
        {
            if (webSocketServer.IsListening)
            {
                webSocketServer.WebSocketServices[$"/{ServicePath}"].Sessions.Broadcast(payload);
                Debug.Print($"Broadcast: {payload}");
            }
            else
            {
                throw new InvalidOperationException("Websocket server is not running. Cannot broadcast.");
            }
        }
        /// <summary>
        /// Append gaze data to the collection. When the collection is full, send it with SendSBGazeDataCollection().
        /// </summary>
        /// <param name="time">Unix time</param>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        private void AppendSBGazeDataToCollection(long time, int x, int y)
        {
            collectGazeDataArray[collectGazeDataCount].time = time;
            collectGazeDataArray[collectGazeDataCount].x = x;
            collectGazeDataArray[collectGazeDataCount].y = y;
            collectGazeDataCount++;
        }
        /// <summary>
        /// Send collected gaze data over the websocket connection
        /// </summary>
        private void SendSBGazeDataCollection()
        {
            string payloadText = $"e{WSEventID.FixationStarted},n{ConsecutiveDataCount}";
            foreach (SBGazeCollectData collectData in collectGazeDataArray)
            {
                payloadText += $",t{collectData.time},x{collectData.x},y{collectData.y}";
            }
            Debug.Print($"{Enum.GetName(typeof(WSEventID), WSEventID.FixationStarted)}[{WSEventID.FixationStarted}]: {payloadText}");
            if (!IsNotWSStarted)
            {
                WSBroadCastString(payloadText);
            }
            collectGazeDataCount = 0;
        }
        #endregion

        #region Static methods
        /// <summary>
        /// Get host ipv4 address
        /// </summary>
        /// <returns>[string] IPv4 address</returns>
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
        /// <summary>
        /// Get current unix time in ms
        /// </summary>
        /// <returns>[long] Unix time</returns>
        private static long GetUnixTimeInMs()
        {
            DateTimeOffset now = DateTimeOffset.UtcNow;
            return now.ToUnixTimeMilliseconds();
        }
        #endregion
    }
}
