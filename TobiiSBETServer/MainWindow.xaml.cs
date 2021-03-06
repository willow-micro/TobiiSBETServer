// Target: .NET 6 (LTS)

// Default
using System;
using System.Windows;
using System.Windows.Input;
// Additional
using System.ComponentModel;
using System.IO;
//using System.Diagnostics;
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
        /// Unix time for calc debounceTemp
        /// </summary>
        private long debounceTempUnixTimeInMs;
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
        /// <summary>
        /// StreamWriter for log output
        /// </summary>
        private StreamWriter logWriter;
        /// <summary>
        /// If waiting for the event FixationEnded, becomes true
        /// </summary>
        private bool isWaitingForFixationEnded;
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
            Console.WriteLine("OnContentRendered");
        }

        /// <summary>
        /// Called when app was closed.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Args</param>
        private void OnClosed(object sender, EventArgs e)
        {
            if (eyeTracker != null)
            {
                eyeTracker.StopReceivingGazeData();
            }
            if (previewWindow != null)
            {
                previewWindow.Close();
            }
            Console.WriteLine("OnClosed");
            Environment.Exit(0);
        }

        /// <summary>
        /// Ask user to close or not when the Esc key was pressed
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Args</param>
        private void AppCloseEvent(object sender, ExecutedRoutedEventArgs e)
        {
            Console.WriteLine("AppCloseEvent(esc)");

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

            isWaitingForFixationEnded = false;

            if (IsDebouncingEnabled)
            {
                debounceTempUnixTimeInMs = GetUnixTimeInMs();
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
            // Initialize StreamWriter for logging
            if (InitializeLogWriter() == false)
            {
                Console.WriteLine("Logging not started");
            }
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
            if (logWriter.BaseStream != null)
            {
                logWriter.Flush();
                logWriter.Close();
            }
        }

        /// <summary>
        /// OnGazeData event handler. Receives gaze data from the eye tracker
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Args</param>
        private void OnGazeData(object sender, OnGazeDataEventArgs e)
        {
            long unixTime = GetUnixTimeInMs();
            bool[] areEventsFired = new bool[] { false, false, false };

            // Gaze data (left)
            if (e.IsLeftValid)
            {                
                int xPos = (int)(e.LeftX);
                int yPos = (int)(e.LeftY);

                if (IsDebouncingEnabled)
                {
                    if (e.LeftEyeMovementType == EyeMovementType.Fixation)
                    {
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
                            // FixationStarted
                            isGazeDataCollecting = false;
                            SendSBGazeDataCollection();
                            areEventsFired[(int)WSEventID.FixationStarted] = true;
                        }
                        debounceTemp = 0;
                    }
                    else
                    {
                        // Count times without fixation for debouncing
                        debounceTemp += unixTime - debounceTempUnixTimeInMs;
                        debounceTempUnixTimeInMs = unixTime;
                    }
                }
                else
                {
                    if (e.LeftEyeMovementType == EyeMovementType.Fixation)
                    {
                        if (collectGazeDataCount < ConsecutiveDataCount)
                        {
                            isGazeDataCollecting = true;
                            AppendSBGazeDataToCollection(unixTime, xPos, yPos);
                        }
                        if (collectGazeDataCount >= ConsecutiveDataCount)
                        {
                            // FixationStarted
                            isGazeDataCollecting = false;
                            collectGazeDataCount = 0;
                            SendSBGazeDataCollection();
                            areEventsFired[(int)WSEventID.FixationStarted] = true;
                        }
                    }
                }

                if (e.LeftEyeMovementType != EyeMovementType.Fixation)
                {
                    if (isGazeDataCollecting)
                    {
                        // Terminate collection if necessary
                        isGazeDataCollecting = false;
                        collectGazeDataCount = 0;
                    }
                    else if (e.LeftEyeMovementType == EyeMovementType.Saccade && prevEyeMovementType == EyeMovementType.Fixation && isWaitingForFixationEnded)
                    {
                        // FixationEnded
                        string payloadText = $"e{(int)WSEventID.FixationEnded},t{prevGazeData.time},x{prevGazeData.x},y{prevGazeData.y}";
                        Console.WriteLine($"{Enum.GetName(typeof(WSEventID), WSEventID.FixationEnded)}[{(int)WSEventID.FixationEnded}]: {payloadText}");
                        if (!IsNotWSStarted)
                        {
                            WSBroadCastString(payloadText);
                        }
                        areEventsFired[(int)WSEventID.FixationEnded] = true;
                        isWaitingForFixationEnded = false;
                    }
                }

                prevEyeMovementType = e.LeftEyeMovementType;
                prevGazeData = new SBGazeCollectData(unixTime, xPos, yPos);

                // Show gaze point
                if (previewWindow != null &&
                    (e.LeftEyeMovementType == EyeMovementType.Fixation || e.LeftEyeMovementType == EyeMovementType.PreFixation))
                {
                    previewWindow.ShowGazePoint();
                    previewWindow.PlaceGazePoint(eyeTracker.GetScreenWidthInPixels(), eyeTracker.GetScreenHeightInPixels(), e.LeftX, e.LeftY);
                }
            }

            // Pupil data
            // For LFHFComputed event
            if (IsLFHFComputerEnabled && pupilDataProcessor != null)
            {
                // Create pupil data
                PupilDataForProcess pupilData;
                if (e.IsLeftPDValid)
                {
                    pupilData.Diameter = e.LeftPD;
                    pupilData.IsValid = true;
                }
                else
                {
                    pupilData.Diameter = 0.0f;
                    pupilData.IsValid = false;
                }
                // Add diameter
                if (pupilDataProcessor.UpdateWith(pupilData) == LFHFComputeStatus.Ready)
                {
                    string payloadText = $"e{(int)WSEventID.LFHFComputed},t{unixTime},r{pupilDataProcessor.LatestLFHF:F3}";
                    Console.WriteLine($"{Enum.GetName(typeof(WSEventID), WSEventID.LFHFComputed)}[{(int)WSEventID.LFHFComputed}]: {payloadText}");
                    if (!IsNotWSStarted)
                    {
                        WSBroadCastString(payloadText);
                    }
                    areEventsFired[(int)WSEventID.LFHFComputed] = true;
                }
            }

            // Update the status string in the bottom of preview window
            if (previewWindow != null)
            {
                PreviewData newData;
                newData.isValid = e.IsLeftValid && e.IsLeftPDValid && e.IsRightPDValid;
                newData.eyeMovementType = e.LeftEyeMovementType;
                newData.x = (int)(e.LeftX);
                newData.y = (int)(e.LeftY);
                newData.angularVelocity = (float)(e.LeftGazeAngularVelocity);
                newData.leftPD = e.IsLeftPDValid ? e.LeftPD : 0.0f;
                newData.rightPD = e.IsRightPDValid ? e.RightPD : 0.0f;
                newData.latestLFHF = pupilDataProcessor != null ? pupilDataProcessor.LatestLFHF : 0.0f;
                previewWindow.UpdateStatusStr(newData);
                if (!isNotWSStarted)
                {
                    // And Logging
                    LogPreviewData(unixTime, newData, areEventsFired);
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
            ComputeSpanSec = 1.0f;
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

                DeviceInfoStr = $"{eyeTracker.GetModel()}";
                FrequencyStr = $"{eyeTracker.GetFrequency():F2} Hz";
                ScreenDimensionsStr = $"{eyeTracker.GetScreenWidthInPixels()}x{eyeTracker.GetScreenHeightInPixels()} ({eyeTracker.GetScreenWidthInMillimeters():F2}x{eyeTracker.GetScreenHeightInMillimeters():F2} mm)";
                DeviceStatusStr = "Initialized";
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                Close();
            }
            catch (InvalidOperationException e)
            {
                if (MessageBox.Show(e.Message, "OK", MessageBoxButton.OK, MessageBoxImage.Error) == MessageBoxResult.OK)
                {
                    Close();
                }
            }
        }
        /// <summary>
        /// Initialize the streamwriter for logging csv
        /// </summary>
        /// <returns>[bool] success or not</returns>
        private bool InitializeLogWriter()
        {
            try
            {
                logWriter = new StreamWriter("log.csv");
                logWriter.WriteLine("Timestamp,Validity,EyeMovement,X,Y,Velocity,LeftPD,RightPD,LFHF,Events");
            }
            catch
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Start websocket server
        /// </summary>
        private void StartWSServer()
        {
            webSocketServer = new WebSocketServer($"ws://{GetHostAddress()}:{PortNumber}");
            webSocketServer.AddWebSocketService<ServerBehavior>($"/{ServicePath}");
            webSocketServer.Start();
            Console.WriteLine($"Server was started on {ServerURL}");
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
            Console.WriteLine("Server was stopped");
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
                Console.WriteLine($"Broadcast: {payload}");
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
            string payloadText = $"e{(int)WSEventID.FixationStarted},n{ConsecutiveDataCount}";
            foreach (SBGazeCollectData collectData in collectGazeDataArray)
            {
                payloadText += $",t{collectData.time},x{collectData.x},y{collectData.y}";
            }
            Console.WriteLine($"{Enum.GetName(typeof(WSEventID), WSEventID.FixationStarted)}[{(int)WSEventID.FixationStarted}]: {payloadText}");
            if (!IsNotWSStarted)
            {
                WSBroadCastString(payloadText);
            }
            collectGazeDataCount = 0;
            isWaitingForFixationEnded = true;
        }
        /// <summary>
        /// Log data
        /// </summary>
        /// <param name="time">Unix time in ms</param>
        /// <param name="data">Data for logging (same as previewwindow's status)</param>
        /// <param name="eventsFlag">Each WSEventIDs are fired ot not</param>
        private void LogPreviewData(long time, PreviewData data, bool[] eventsFlag)
        {
            if (logWriter.BaseStream != null)
            {
                string eventsStr = "";
                for (int i = 0; i < 3; i++)
                {
                    if (eventsFlag[i])
                    {
                        eventsStr += $"{Enum.GetName(typeof(WSEventID), (WSEventID)i)} ";
                    }
                }
                logWriter.WriteLine($"{time},{(data.isValid ? "ok" : "no")},{Enum.GetName(typeof(EyeTracking.EyeMovementType), data.eyeMovementType)},{(data.isValid ? data.x : 0)},{(data.isValid ? data.y : 0)},{(data.isValid ? data.angularVelocity : 0)},{(data.isValid ? data.leftPD : 0.0f)},{(data.isValid ? data.rightPD : 0.0f)},{(data.latestLFHF)},{eventsStr}");
            }
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
