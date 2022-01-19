<a name='assembly'></a>
# TobiiSBETServer

## Contents

- [App](#T-TobiiSBETServer-App 'TobiiSBETServer.App')
  - [InitializeComponent()](#M-TobiiSBETServer-App-InitializeComponent 'TobiiSBETServer.App.InitializeComponent')
  - [Main()](#M-TobiiSBETServer-App-Main 'TobiiSBETServer.App.Main')
- [AppState](#T-TobiiSBETServer-AppState 'TobiiSBETServer.AppState')
  - [WSStarted](#F-TobiiSBETServer-AppState-WSStarted 'TobiiSBETServer.AppState.WSStarted')
  - [WaitForETStart](#F-TobiiSBETServer-AppState-WaitForETStart 'TobiiSBETServer.AppState.WaitForETStart')
  - [WaitForWSStart](#F-TobiiSBETServer-AppState-WaitForWSStart 'TobiiSBETServer.AppState.WaitForWSStart')
- [MainWindow](#T-TobiiSBETServer-MainWindow 'TobiiSBETServer.MainWindow')
  - [#ctor()](#M-TobiiSBETServer-MainWindow-#ctor 'TobiiSBETServer.MainWindow.#ctor')
  - [angularVelocityThreshold](#F-TobiiSBETServer-MainWindow-angularVelocityThreshold 'TobiiSBETServer.MainWindow.angularVelocityThreshold')
  - [appStatusStr](#F-TobiiSBETServer-MainWindow-appStatusStr 'TobiiSBETServer.MainWindow.appStatusStr')
  - [collectGazeDataArray](#F-TobiiSBETServer-MainWindow-collectGazeDataArray 'TobiiSBETServer.MainWindow.collectGazeDataArray')
  - [collectGazeDataCount](#F-TobiiSBETServer-MainWindow-collectGazeDataCount 'TobiiSBETServer.MainWindow.collectGazeDataCount')
  - [computeSpanSec](#F-TobiiSBETServer-MainWindow-computeSpanSec 'TobiiSBETServer.MainWindow.computeSpanSec')
  - [consecutiveDataCount](#F-TobiiSBETServer-MainWindow-consecutiveDataCount 'TobiiSBETServer.MainWindow.consecutiveDataCount')
  - [debounceTemp](#F-TobiiSBETServer-MainWindow-debounceTemp 'TobiiSBETServer.MainWindow.debounceTemp')
  - [debounceTime](#F-TobiiSBETServer-MainWindow-debounceTime 'TobiiSBETServer.MainWindow.debounceTime')
  - [deviceInfoStr](#F-TobiiSBETServer-MainWindow-deviceInfoStr 'TobiiSBETServer.MainWindow.deviceInfoStr')
  - [deviceStatusStr](#F-TobiiSBETServer-MainWindow-deviceStatusStr 'TobiiSBETServer.MainWindow.deviceStatusStr')
  - [durationThreshold](#F-TobiiSBETServer-MainWindow-durationThreshold 'TobiiSBETServer.MainWindow.durationThreshold')
  - [eyeTracker](#F-TobiiSBETServer-MainWindow-eyeTracker 'TobiiSBETServer.MainWindow.eyeTracker')
  - [frequencyStr](#F-TobiiSBETServer-MainWindow-frequencyStr 'TobiiSBETServer.MainWindow.frequencyStr')
  - [hfHighFreq](#F-TobiiSBETServer-MainWindow-hfHighFreq 'TobiiSBETServer.MainWindow.hfHighFreq')
  - [hfLowFreq](#F-TobiiSBETServer-MainWindow-hfLowFreq 'TobiiSBETServer.MainWindow.hfLowFreq')
  - [idealFreqResolution](#F-TobiiSBETServer-MainWindow-idealFreqResolution 'TobiiSBETServer.MainWindow.idealFreqResolution')
  - [isDebouncingEnabled](#F-TobiiSBETServer-MainWindow-isDebouncingEnabled 'TobiiSBETServer.MainWindow.isDebouncingEnabled')
  - [isETStartButtonEnabled](#F-TobiiSBETServer-MainWindow-isETStartButtonEnabled 'TobiiSBETServer.MainWindow.isETStartButtonEnabled')
  - [isETStopButtonEnabled](#F-TobiiSBETServer-MainWindow-isETStopButtonEnabled 'TobiiSBETServer.MainWindow.isETStopButtonEnabled')
  - [isFixationFilterEnabled](#F-TobiiSBETServer-MainWindow-isFixationFilterEnabled 'TobiiSBETServer.MainWindow.isFixationFilterEnabled')
  - [isGazeDataCollecting](#F-TobiiSBETServer-MainWindow-isGazeDataCollecting 'TobiiSBETServer.MainWindow.isGazeDataCollecting')
  - [isLFHFComputerEnabled](#F-TobiiSBETServer-MainWindow-isLFHFComputerEnabled 'TobiiSBETServer.MainWindow.isLFHFComputerEnabled')
  - [isNotETStarted](#F-TobiiSBETServer-MainWindow-isNotETStarted 'TobiiSBETServer.MainWindow.isNotETStarted')
  - [isNotWSStarted](#F-TobiiSBETServer-MainWindow-isNotWSStarted 'TobiiSBETServer.MainWindow.isNotWSStarted')
  - [isShowPreviewButtonEnabled](#F-TobiiSBETServer-MainWindow-isShowPreviewButtonEnabled 'TobiiSBETServer.MainWindow.isShowPreviewButtonEnabled')
  - [isWSStartButtonEnabled](#F-TobiiSBETServer-MainWindow-isWSStartButtonEnabled 'TobiiSBETServer.MainWindow.isWSStartButtonEnabled')
  - [isWSStopButtonEnabled](#F-TobiiSBETServer-MainWindow-isWSStopButtonEnabled 'TobiiSBETServer.MainWindow.isWSStopButtonEnabled')
  - [lfHighFreq](#F-TobiiSBETServer-MainWindow-lfHighFreq 'TobiiSBETServer.MainWindow.lfHighFreq')
  - [lfLowFreq](#F-TobiiSBETServer-MainWindow-lfLowFreq 'TobiiSBETServer.MainWindow.lfLowFreq')
  - [logWriter](#F-TobiiSBETServer-MainWindow-logWriter 'TobiiSBETServer.MainWindow.logWriter')
  - [portNumber](#F-TobiiSBETServer-MainWindow-portNumber 'TobiiSBETServer.MainWindow.portNumber')
  - [prevEyeMovementType](#F-TobiiSBETServer-MainWindow-prevEyeMovementType 'TobiiSBETServer.MainWindow.prevEyeMovementType')
  - [prevGazeData](#F-TobiiSBETServer-MainWindow-prevGazeData 'TobiiSBETServer.MainWindow.prevGazeData')
  - [prevUnixTimeInMs](#F-TobiiSBETServer-MainWindow-prevUnixTimeInMs 'TobiiSBETServer.MainWindow.prevUnixTimeInMs')
  - [previewWindow](#F-TobiiSBETServer-MainWindow-previewWindow 'TobiiSBETServer.MainWindow.previewWindow')
  - [pupilDataProcessor](#F-TobiiSBETServer-MainWindow-pupilDataProcessor 'TobiiSBETServer.MainWindow.pupilDataProcessor')
  - [screenDimensionsStr](#F-TobiiSBETServer-MainWindow-screenDimensionsStr 'TobiiSBETServer.MainWindow.screenDimensionsStr')
  - [screenHeightInPixels](#F-TobiiSBETServer-MainWindow-screenHeightInPixels 'TobiiSBETServer.MainWindow.screenHeightInPixels')
  - [screenWidthInPixels](#F-TobiiSBETServer-MainWindow-screenWidthInPixels 'TobiiSBETServer.MainWindow.screenWidthInPixels')
  - [serverURL](#F-TobiiSBETServer-MainWindow-serverURL 'TobiiSBETServer.MainWindow.serverURL')
  - [servicePath](#F-TobiiSBETServer-MainWindow-servicePath 'TobiiSBETServer.MainWindow.servicePath')
  - [webSocketServer](#F-TobiiSBETServer-MainWindow-webSocketServer 'TobiiSBETServer.MainWindow.webSocketServer')
  - [AngularVelocityThreshold](#P-TobiiSBETServer-MainWindow-AngularVelocityThreshold 'TobiiSBETServer.MainWindow.AngularVelocityThreshold')
  - [AppStatusStr](#P-TobiiSBETServer-MainWindow-AppStatusStr 'TobiiSBETServer.MainWindow.AppStatusStr')
  - [ComputeSpanSec](#P-TobiiSBETServer-MainWindow-ComputeSpanSec 'TobiiSBETServer.MainWindow.ComputeSpanSec')
  - [ConsecutiveDataCount](#P-TobiiSBETServer-MainWindow-ConsecutiveDataCount 'TobiiSBETServer.MainWindow.ConsecutiveDataCount')
  - [DebounceTime](#P-TobiiSBETServer-MainWindow-DebounceTime 'TobiiSBETServer.MainWindow.DebounceTime')
  - [DeviceInfoStr](#P-TobiiSBETServer-MainWindow-DeviceInfoStr 'TobiiSBETServer.MainWindow.DeviceInfoStr')
  - [DeviceStatusStr](#P-TobiiSBETServer-MainWindow-DeviceStatusStr 'TobiiSBETServer.MainWindow.DeviceStatusStr')
  - [DurationThreshold](#P-TobiiSBETServer-MainWindow-DurationThreshold 'TobiiSBETServer.MainWindow.DurationThreshold')
  - [FrequencyStr](#P-TobiiSBETServer-MainWindow-FrequencyStr 'TobiiSBETServer.MainWindow.FrequencyStr')
  - [HFHighFreq](#P-TobiiSBETServer-MainWindow-HFHighFreq 'TobiiSBETServer.MainWindow.HFHighFreq')
  - [HFLowFreq](#P-TobiiSBETServer-MainWindow-HFLowFreq 'TobiiSBETServer.MainWindow.HFLowFreq')
  - [IdealFreqResolution](#P-TobiiSBETServer-MainWindow-IdealFreqResolution 'TobiiSBETServer.MainWindow.IdealFreqResolution')
  - [IsDebouncingEnabled](#P-TobiiSBETServer-MainWindow-IsDebouncingEnabled 'TobiiSBETServer.MainWindow.IsDebouncingEnabled')
  - [IsETStartButtonEnabled](#P-TobiiSBETServer-MainWindow-IsETStartButtonEnabled 'TobiiSBETServer.MainWindow.IsETStartButtonEnabled')
  - [IsETStopButtonEnabled](#P-TobiiSBETServer-MainWindow-IsETStopButtonEnabled 'TobiiSBETServer.MainWindow.IsETStopButtonEnabled')
  - [IsFixationFilterEnabled](#P-TobiiSBETServer-MainWindow-IsFixationFilterEnabled 'TobiiSBETServer.MainWindow.IsFixationFilterEnabled')
  - [IsLFHFComputerEnabled](#P-TobiiSBETServer-MainWindow-IsLFHFComputerEnabled 'TobiiSBETServer.MainWindow.IsLFHFComputerEnabled')
  - [IsNotETStarted](#P-TobiiSBETServer-MainWindow-IsNotETStarted 'TobiiSBETServer.MainWindow.IsNotETStarted')
  - [IsNotWSStarted](#P-TobiiSBETServer-MainWindow-IsNotWSStarted 'TobiiSBETServer.MainWindow.IsNotWSStarted')
  - [IsShowPreviewButtonEnabled](#P-TobiiSBETServer-MainWindow-IsShowPreviewButtonEnabled 'TobiiSBETServer.MainWindow.IsShowPreviewButtonEnabled')
  - [IsWSStartButtonEnabled](#P-TobiiSBETServer-MainWindow-IsWSStartButtonEnabled 'TobiiSBETServer.MainWindow.IsWSStartButtonEnabled')
  - [IsWSStopButtonEnabled](#P-TobiiSBETServer-MainWindow-IsWSStopButtonEnabled 'TobiiSBETServer.MainWindow.IsWSStopButtonEnabled')
  - [LFHighFreq](#P-TobiiSBETServer-MainWindow-LFHighFreq 'TobiiSBETServer.MainWindow.LFHighFreq')
  - [LFLowFreq](#P-TobiiSBETServer-MainWindow-LFLowFreq 'TobiiSBETServer.MainWindow.LFLowFreq')
  - [PortNumber](#P-TobiiSBETServer-MainWindow-PortNumber 'TobiiSBETServer.MainWindow.PortNumber')
  - [ScreenDimensionsStr](#P-TobiiSBETServer-MainWindow-ScreenDimensionsStr 'TobiiSBETServer.MainWindow.ScreenDimensionsStr')
  - [ServerURL](#P-TobiiSBETServer-MainWindow-ServerURL 'TobiiSBETServer.MainWindow.ServerURL')
  - [ServicePath](#P-TobiiSBETServer-MainWindow-ServicePath 'TobiiSBETServer.MainWindow.ServicePath')
  - [AppCloseEvent(sender,e)](#M-TobiiSBETServer-MainWindow-AppCloseEvent-System-Object,System-Windows-Input-ExecutedRoutedEventArgs- 'TobiiSBETServer.MainWindow.AppCloseEvent(System.Object,System.Windows.Input.ExecutedRoutedEventArgs)')
  - [AppendSBGazeDataToCollection(time,x,y)](#M-TobiiSBETServer-MainWindow-AppendSBGazeDataToCollection-System-Int64,System-Int32,System-Int32- 'TobiiSBETServer.MainWindow.AppendSBGazeDataToCollection(System.Int64,System.Int32,System.Int32)')
  - [ETStartButtonClicked(sender,e)](#M-TobiiSBETServer-MainWindow-ETStartButtonClicked-System-Object,System-Windows-RoutedEventArgs- 'TobiiSBETServer.MainWindow.ETStartButtonClicked(System.Object,System.Windows.RoutedEventArgs)')
  - [ETStopButtonClicked(sender,e)](#M-TobiiSBETServer-MainWindow-ETStopButtonClicked-System-Object,System-Windows-RoutedEventArgs- 'TobiiSBETServer.MainWindow.ETStopButtonClicked(System.Object,System.Windows.RoutedEventArgs)')
  - [GetHostAddress()](#M-TobiiSBETServer-MainWindow-GetHostAddress 'TobiiSBETServer.MainWindow.GetHostAddress')
  - [GetUnixTimeInMs()](#M-TobiiSBETServer-MainWindow-GetUnixTimeInMs 'TobiiSBETServer.MainWindow.GetUnixTimeInMs')
  - [InitializeComponent()](#M-TobiiSBETServer-MainWindow-InitializeComponent 'TobiiSBETServer.MainWindow.InitializeComponent')
  - [InitializeEyeTracker()](#M-TobiiSBETServer-MainWindow-InitializeEyeTracker 'TobiiSBETServer.MainWindow.InitializeEyeTracker')
  - [InitializeLogWriter()](#M-TobiiSBETServer-MainWindow-InitializeLogWriter 'TobiiSBETServer.MainWindow.InitializeLogWriter')
  - [InitializeParameters()](#M-TobiiSBETServer-MainWindow-InitializeParameters 'TobiiSBETServer.MainWindow.InitializeParameters')
  - [LogPreviewData(time,data)](#M-TobiiSBETServer-MainWindow-LogPreviewData-System-Int64,TobiiSBETServer-PreviewData- 'TobiiSBETServer.MainWindow.LogPreviewData(System.Int64,TobiiSBETServer.PreviewData)')
  - [NotifyPropertyChanged(name)](#M-TobiiSBETServer-MainWindow-NotifyPropertyChanged-System-String- 'TobiiSBETServer.MainWindow.NotifyPropertyChanged(System.String)')
  - [OnClosed(sender,e)](#M-TobiiSBETServer-MainWindow-OnClosed-System-Object,System-EventArgs- 'TobiiSBETServer.MainWindow.OnClosed(System.Object,System.EventArgs)')
  - [OnContentRendered(sender,e)](#M-TobiiSBETServer-MainWindow-OnContentRendered-System-Object,System-EventArgs- 'TobiiSBETServer.MainWindow.OnContentRendered(System.Object,System.EventArgs)')
  - [OnGazeData(sender,e)](#M-TobiiSBETServer-MainWindow-OnGazeData-System-Object,EyeTracking-OnGazeDataEventArgs- 'TobiiSBETServer.MainWindow.OnGazeData(System.Object,EyeTracking.OnGazeDataEventArgs)')
  - [SendSBGazeDataCollection()](#M-TobiiSBETServer-MainWindow-SendSBGazeDataCollection 'TobiiSBETServer.MainWindow.SendSBGazeDataCollection')
  - [ShowPreviewButtonClicked(sender,e)](#M-TobiiSBETServer-MainWindow-ShowPreviewButtonClicked-System-Object,System-Windows-RoutedEventArgs- 'TobiiSBETServer.MainWindow.ShowPreviewButtonClicked(System.Object,System.Windows.RoutedEventArgs)')
  - [StartWSServer()](#M-TobiiSBETServer-MainWindow-StartWSServer 'TobiiSBETServer.MainWindow.StartWSServer')
  - [StopWSServer()](#M-TobiiSBETServer-MainWindow-StopWSServer 'TobiiSBETServer.MainWindow.StopWSServer')
  - [UpdateAppState(state)](#M-TobiiSBETServer-MainWindow-UpdateAppState-TobiiSBETServer-AppState- 'TobiiSBETServer.MainWindow.UpdateAppState(TobiiSBETServer.AppState)')
  - [WSBroadCastString(payload)](#M-TobiiSBETServer-MainWindow-WSBroadCastString-System-String- 'TobiiSBETServer.MainWindow.WSBroadCastString(System.String)')
  - [WSStartButtonClicked(sender,e)](#M-TobiiSBETServer-MainWindow-WSStartButtonClicked-System-Object,System-Windows-RoutedEventArgs- 'TobiiSBETServer.MainWindow.WSStartButtonClicked(System.Object,System.Windows.RoutedEventArgs)')
  - [WSStopButtonClicked(sender,e)](#M-TobiiSBETServer-MainWindow-WSStopButtonClicked-System-Object,System-Windows-RoutedEventArgs- 'TobiiSBETServer.MainWindow.WSStopButtonClicked(System.Object,System.Windows.RoutedEventArgs)')
- [PreviewData](#T-TobiiSBETServer-PreviewData 'TobiiSBETServer.PreviewData')
  - [angularVelocity](#F-TobiiSBETServer-PreviewData-angularVelocity 'TobiiSBETServer.PreviewData.angularVelocity')
  - [eyeMovementType](#F-TobiiSBETServer-PreviewData-eyeMovementType 'TobiiSBETServer.PreviewData.eyeMovementType')
  - [isValid](#F-TobiiSBETServer-PreviewData-isValid 'TobiiSBETServer.PreviewData.isValid')
  - [latestLFHF](#F-TobiiSBETServer-PreviewData-latestLFHF 'TobiiSBETServer.PreviewData.latestLFHF')
  - [leftPD](#F-TobiiSBETServer-PreviewData-leftPD 'TobiiSBETServer.PreviewData.leftPD')
  - [rightPD](#F-TobiiSBETServer-PreviewData-rightPD 'TobiiSBETServer.PreviewData.rightPD')
  - [x](#F-TobiiSBETServer-PreviewData-x 'TobiiSBETServer.PreviewData.x')
  - [y](#F-TobiiSBETServer-PreviewData-y 'TobiiSBETServer.PreviewData.y')
- [PreviewWindow](#T-TobiiSBETServer-PreviewWindow 'TobiiSBETServer.PreviewWindow')
  - [#ctor(pointRadius)](#M-TobiiSBETServer-PreviewWindow-#ctor-System-Double- 'TobiiSBETServer.PreviewWindow.#ctor(System.Double)')
  - [gazePoint](#F-TobiiSBETServer-PreviewWindow-gazePoint 'TobiiSBETServer.PreviewWindow.gazePoint')
  - [pointDiameter](#F-TobiiSBETServer-PreviewWindow-pointDiameter 'TobiiSBETServer.PreviewWindow.pointDiameter')
  - [previewStatusStr](#F-TobiiSBETServer-PreviewWindow-previewStatusStr 'TobiiSBETServer.PreviewWindow.previewStatusStr')
  - [PreviewStatusStr](#P-TobiiSBETServer-PreviewWindow-PreviewStatusStr 'TobiiSBETServer.PreviewWindow.PreviewStatusStr')
  - [HideGazePoint()](#M-TobiiSBETServer-PreviewWindow-HideGazePoint 'TobiiSBETServer.PreviewWindow.HideGazePoint')
  - [InitializeComponent()](#M-TobiiSBETServer-PreviewWindow-InitializeComponent 'TobiiSBETServer.PreviewWindow.InitializeComponent')
  - [NotifyPropertyChanged(name)](#M-TobiiSBETServer-PreviewWindow-NotifyPropertyChanged-System-String- 'TobiiSBETServer.PreviewWindow.NotifyPropertyChanged(System.String)')
  - [PlaceGazePoint(screenWidth,screenHeight,x,y)](#M-TobiiSBETServer-PreviewWindow-PlaceGazePoint-System-Double,System-Double,System-Double,System-Double- 'TobiiSBETServer.PreviewWindow.PlaceGazePoint(System.Double,System.Double,System.Double,System.Double)')
  - [ShowGazePoint()](#M-TobiiSBETServer-PreviewWindow-ShowGazePoint 'TobiiSBETServer.PreviewWindow.ShowGazePoint')
  - [UpdateStatusStr(data)](#M-TobiiSBETServer-PreviewWindow-UpdateStatusStr-TobiiSBETServer-PreviewData- 'TobiiSBETServer.PreviewWindow.UpdateStatusStr(TobiiSBETServer.PreviewData)')
  - [Window_Closing(sender,e)](#M-TobiiSBETServer-PreviewWindow-Window_Closing-System-Object,System-ComponentModel-CancelEventArgs- 'TobiiSBETServer.PreviewWindow.Window_Closing(System.Object,System.ComponentModel.CancelEventArgs)')
- [SBGazeCollectData](#T-TobiiSBETServer-SBGazeCollectData 'TobiiSBETServer.SBGazeCollectData')
  - [#ctor(t,x,y)](#M-TobiiSBETServer-SBGazeCollectData-#ctor-System-Int64,System-Int32,System-Int32- 'TobiiSBETServer.SBGazeCollectData.#ctor(System.Int64,System.Int32,System.Int32)')
  - [time](#F-TobiiSBETServer-SBGazeCollectData-time 'TobiiSBETServer.SBGazeCollectData.time')
  - [x](#F-TobiiSBETServer-SBGazeCollectData-x 'TobiiSBETServer.SBGazeCollectData.x')
  - [y](#F-TobiiSBETServer-SBGazeCollectData-y 'TobiiSBETServer.SBGazeCollectData.y')
- [ServerBehavior](#T-TobiiSBETServer-ServerBehavior 'TobiiSBETServer.ServerBehavior')
  - [OnMessage(e)](#M-TobiiSBETServer-ServerBehavior-OnMessage-WebSocketSharp-MessageEventArgs- 'TobiiSBETServer.ServerBehavior.OnMessage(WebSocketSharp.MessageEventArgs)')
  - [OnOpen()](#M-TobiiSBETServer-ServerBehavior-OnOpen 'TobiiSBETServer.ServerBehavior.OnOpen')
- [WSEventID](#T-TobiiSBETServer-WSEventID 'TobiiSBETServer.WSEventID')
  - [FixationEnded](#F-TobiiSBETServer-WSEventID-FixationEnded 'TobiiSBETServer.WSEventID.FixationEnded')
  - [FixationStarted](#F-TobiiSBETServer-WSEventID-FixationStarted 'TobiiSBETServer.WSEventID.FixationStarted')
  - [LFHFComputed](#F-TobiiSBETServer-WSEventID-LFHFComputed 'TobiiSBETServer.WSEventID.LFHFComputed')

<a name='T-TobiiSBETServer-App'></a>
## App `type`

##### Namespace

TobiiSBETServer

##### Summary

Interaction logic for App.xaml

<a name='M-TobiiSBETServer-App-InitializeComponent'></a>
### InitializeComponent() `method`

##### Summary

InitializeComponent

##### Parameters

This method has no parameters.

<a name='M-TobiiSBETServer-App-Main'></a>
### Main() `method`

##### Summary

Application Entry Point.

##### Parameters

This method has no parameters.

<a name='T-TobiiSBETServer-AppState'></a>
## AppState `type`

##### Namespace

TobiiSBETServer

##### Summary

Application State for ui management and status bar

<a name='F-TobiiSBETServer-AppState-WSStarted'></a>
### WSStarted `constants`

##### Summary

Websocket server is started

<a name='F-TobiiSBETServer-AppState-WaitForETStart'></a>
### WaitForETStart `constants`

##### Summary

Waiting for starting the eye tracker

<a name='F-TobiiSBETServer-AppState-WaitForWSStart'></a>
### WaitForWSStart `constants`

##### Summary

Waiting for starting the websocket server

<a name='T-TobiiSBETServer-MainWindow'></a>
## MainWindow `type`

##### Namespace

TobiiSBETServer

##### Summary

Interaction logic for MainWindow.xaml

<a name='M-TobiiSBETServer-MainWindow-#ctor'></a>
### #ctor() `constructor`

##### Summary

Constructor

##### Parameters

This constructor has no parameters.

<a name='F-TobiiSBETServer-MainWindow-angularVelocityThreshold'></a>
### angularVelocityThreshold `constants`

##### Summary

Internal field for the binding property

<a name='F-TobiiSBETServer-MainWindow-appStatusStr'></a>
### appStatusStr `constants`

##### Summary

Internal field for the binding property

<a name='F-TobiiSBETServer-MainWindow-collectGazeDataArray'></a>
### collectGazeDataArray `constants`

##### Summary

Array of gaze data to collect

<a name='F-TobiiSBETServer-MainWindow-collectGazeDataCount'></a>
### collectGazeDataCount `constants`

##### Summary

Number of gaze data to collect

<a name='F-TobiiSBETServer-MainWindow-computeSpanSec'></a>
### computeSpanSec `constants`

##### Summary

Internal field for the binding property

<a name='F-TobiiSBETServer-MainWindow-consecutiveDataCount'></a>
### consecutiveDataCount `constants`

##### Summary

Internal field for the binding property

<a name='F-TobiiSBETServer-MainWindow-debounceTemp'></a>
### debounceTemp `constants`

##### Summary

Count time for debounce

<a name='F-TobiiSBETServer-MainWindow-debounceTime'></a>
### debounceTime `constants`

##### Summary

Internal field for the binding property

<a name='F-TobiiSBETServer-MainWindow-deviceInfoStr'></a>
### deviceInfoStr `constants`

##### Summary

Internal field for the binding property

<a name='F-TobiiSBETServer-MainWindow-deviceStatusStr'></a>
### deviceStatusStr `constants`

##### Summary

Internal field for the binding property

<a name='F-TobiiSBETServer-MainWindow-durationThreshold'></a>
### durationThreshold `constants`

##### Summary

Internal field for the binding property

<a name='F-TobiiSBETServer-MainWindow-eyeTracker'></a>
### eyeTracker `constants`

##### Summary

An instance from EyeTracking.TobiiSBETDriver

<a name='F-TobiiSBETServer-MainWindow-frequencyStr'></a>
### frequencyStr `constants`

##### Summary

Internal field for the binding property

<a name='F-TobiiSBETServer-MainWindow-hfHighFreq'></a>
### hfHighFreq `constants`

##### Summary

Internal field for the binding property

<a name='F-TobiiSBETServer-MainWindow-hfLowFreq'></a>
### hfLowFreq `constants`

##### Summary

Internal field for the binding property

<a name='F-TobiiSBETServer-MainWindow-idealFreqResolution'></a>
### idealFreqResolution `constants`

##### Summary

Internal field for the binding property

<a name='F-TobiiSBETServer-MainWindow-isDebouncingEnabled'></a>
### isDebouncingEnabled `constants`

##### Summary

Internal field for the binding property

<a name='F-TobiiSBETServer-MainWindow-isETStartButtonEnabled'></a>
### isETStartButtonEnabled `constants`

##### Summary

Internal field for the binding property

<a name='F-TobiiSBETServer-MainWindow-isETStopButtonEnabled'></a>
### isETStopButtonEnabled `constants`

##### Summary

Internal field for the binding property

<a name='F-TobiiSBETServer-MainWindow-isFixationFilterEnabled'></a>
### isFixationFilterEnabled `constants`

##### Summary

Internal field for the binding property

<a name='F-TobiiSBETServer-MainWindow-isGazeDataCollecting'></a>
### isGazeDataCollecting `constants`

##### Summary

If collecting gaze data, become true

<a name='F-TobiiSBETServer-MainWindow-isLFHFComputerEnabled'></a>
### isLFHFComputerEnabled `constants`

##### Summary

Internal field for the binding property

<a name='F-TobiiSBETServer-MainWindow-isNotETStarted'></a>
### isNotETStarted `constants`

##### Summary

Internal field for the binding property

<a name='F-TobiiSBETServer-MainWindow-isNotWSStarted'></a>
### isNotWSStarted `constants`

##### Summary

Internal field for the binding property

<a name='F-TobiiSBETServer-MainWindow-isShowPreviewButtonEnabled'></a>
### isShowPreviewButtonEnabled `constants`

##### Summary

Internal field for the binding property

<a name='F-TobiiSBETServer-MainWindow-isWSStartButtonEnabled'></a>
### isWSStartButtonEnabled `constants`

##### Summary

Internal field for the binding property

<a name='F-TobiiSBETServer-MainWindow-isWSStopButtonEnabled'></a>
### isWSStopButtonEnabled `constants`

##### Summary

Internal field for the binding property

<a name='F-TobiiSBETServer-MainWindow-lfHighFreq'></a>
### lfHighFreq `constants`

##### Summary

Internal field for the binding property

<a name='F-TobiiSBETServer-MainWindow-lfLowFreq'></a>
### lfLowFreq `constants`

##### Summary

Internal field for the binding property

<a name='F-TobiiSBETServer-MainWindow-logWriter'></a>
### logWriter `constants`

##### Summary

StreamWriter for log output

<a name='F-TobiiSBETServer-MainWindow-portNumber'></a>
### portNumber `constants`

##### Summary

Internal field for the binding property

<a name='F-TobiiSBETServer-MainWindow-prevEyeMovementType'></a>
### prevEyeMovementType `constants`

##### Summary

Previous eye movement type when received gaze data last time

<a name='F-TobiiSBETServer-MainWindow-prevGazeData'></a>
### prevGazeData `constants`

##### Summary

Previous gaze data

<a name='F-TobiiSBETServer-MainWindow-prevUnixTimeInMs'></a>
### prevUnixTimeInMs `constants`

##### Summary

Previous unix time in ms when received gaze data last time

<a name='F-TobiiSBETServer-MainWindow-previewWindow'></a>
### previewWindow `constants`

##### Summary

Preview window

<a name='F-TobiiSBETServer-MainWindow-pupilDataProcessor'></a>
### pupilDataProcessor `constants`

##### Summary

An instance from EyeTracking.PupilDataProcessor

<a name='F-TobiiSBETServer-MainWindow-screenDimensionsStr'></a>
### screenDimensionsStr `constants`

##### Summary

Internal field for the binding property

<a name='F-TobiiSBETServer-MainWindow-screenHeightInPixels'></a>
### screenHeightInPixels `constants`

##### Summary

Primary screen height in DIP

<a name='F-TobiiSBETServer-MainWindow-screenWidthInPixels'></a>
### screenWidthInPixels `constants`

##### Summary

Primary screen width in DIP

<a name='F-TobiiSBETServer-MainWindow-serverURL'></a>
### serverURL `constants`

##### Summary

Internal field for the binding property

<a name='F-TobiiSBETServer-MainWindow-servicePath'></a>
### servicePath `constants`

##### Summary

Internal field for the binding property

<a name='F-TobiiSBETServer-MainWindow-webSocketServer'></a>
### webSocketServer `constants`

##### Summary

WebSocket Server

<a name='P-TobiiSBETServer-MainWindow-AngularVelocityThreshold'></a>
### AngularVelocityThreshold `property`

##### Summary

A XAML binding property

<a name='P-TobiiSBETServer-MainWindow-AppStatusStr'></a>
### AppStatusStr `property`

##### Summary

A XAML binding property

<a name='P-TobiiSBETServer-MainWindow-ComputeSpanSec'></a>
### ComputeSpanSec `property`

##### Summary

A XAML binding property

<a name='P-TobiiSBETServer-MainWindow-ConsecutiveDataCount'></a>
### ConsecutiveDataCount `property`

##### Summary

A XAML binding property

<a name='P-TobiiSBETServer-MainWindow-DebounceTime'></a>
### DebounceTime `property`

##### Summary

A XAML binding property

<a name='P-TobiiSBETServer-MainWindow-DeviceInfoStr'></a>
### DeviceInfoStr `property`

##### Summary

A XAML binding property

<a name='P-TobiiSBETServer-MainWindow-DeviceStatusStr'></a>
### DeviceStatusStr `property`

##### Summary

A XAML binding property

<a name='P-TobiiSBETServer-MainWindow-DurationThreshold'></a>
### DurationThreshold `property`

##### Summary

A XAML binding property

<a name='P-TobiiSBETServer-MainWindow-FrequencyStr'></a>
### FrequencyStr `property`

##### Summary

A XAML binding property

<a name='P-TobiiSBETServer-MainWindow-HFHighFreq'></a>
### HFHighFreq `property`

##### Summary

A XAML binding property

<a name='P-TobiiSBETServer-MainWindow-HFLowFreq'></a>
### HFLowFreq `property`

##### Summary

A XAML binding property

<a name='P-TobiiSBETServer-MainWindow-IdealFreqResolution'></a>
### IdealFreqResolution `property`

##### Summary

A XAML binding property

<a name='P-TobiiSBETServer-MainWindow-IsDebouncingEnabled'></a>
### IsDebouncingEnabled `property`

##### Summary

A XAML binding property

<a name='P-TobiiSBETServer-MainWindow-IsETStartButtonEnabled'></a>
### IsETStartButtonEnabled `property`

##### Summary

A XAML binding property

<a name='P-TobiiSBETServer-MainWindow-IsETStopButtonEnabled'></a>
### IsETStopButtonEnabled `property`

##### Summary

A XAML binding property

<a name='P-TobiiSBETServer-MainWindow-IsFixationFilterEnabled'></a>
### IsFixationFilterEnabled `property`

##### Summary

A XAML binding property

<a name='P-TobiiSBETServer-MainWindow-IsLFHFComputerEnabled'></a>
### IsLFHFComputerEnabled `property`

##### Summary

A XAML binding property

<a name='P-TobiiSBETServer-MainWindow-IsNotETStarted'></a>
### IsNotETStarted `property`

##### Summary

A XAML binding property

<a name='P-TobiiSBETServer-MainWindow-IsNotWSStarted'></a>
### IsNotWSStarted `property`

##### Summary

A XAML binding property

<a name='P-TobiiSBETServer-MainWindow-IsShowPreviewButtonEnabled'></a>
### IsShowPreviewButtonEnabled `property`

##### Summary

A XAML binding property

<a name='P-TobiiSBETServer-MainWindow-IsWSStartButtonEnabled'></a>
### IsWSStartButtonEnabled `property`

##### Summary

A XAML binding property

<a name='P-TobiiSBETServer-MainWindow-IsWSStopButtonEnabled'></a>
### IsWSStopButtonEnabled `property`

##### Summary

A XAML binding property

<a name='P-TobiiSBETServer-MainWindow-LFHighFreq'></a>
### LFHighFreq `property`

##### Summary

A XAML binding property

<a name='P-TobiiSBETServer-MainWindow-LFLowFreq'></a>
### LFLowFreq `property`

##### Summary

A XAML binding property

<a name='P-TobiiSBETServer-MainWindow-PortNumber'></a>
### PortNumber `property`

##### Summary

A XAML binding property

<a name='P-TobiiSBETServer-MainWindow-ScreenDimensionsStr'></a>
### ScreenDimensionsStr `property`

##### Summary

A XAML binding property

<a name='P-TobiiSBETServer-MainWindow-ServerURL'></a>
### ServerURL `property`

##### Summary

A XAML binding property

<a name='P-TobiiSBETServer-MainWindow-ServicePath'></a>
### ServicePath `property`

##### Summary

A XAML binding property

<a name='M-TobiiSBETServer-MainWindow-AppCloseEvent-System-Object,System-Windows-Input-ExecutedRoutedEventArgs-'></a>
### AppCloseEvent(sender,e) `method`

##### Summary

Ask user to close or not when the Esc key was pressed

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | Sender |
| e | [System.Windows.Input.ExecutedRoutedEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Windows.Input.ExecutedRoutedEventArgs 'System.Windows.Input.ExecutedRoutedEventArgs') | Args |

<a name='M-TobiiSBETServer-MainWindow-AppendSBGazeDataToCollection-System-Int64,System-Int32,System-Int32-'></a>
### AppendSBGazeDataToCollection(time,x,y) `method`

##### Summary

Append gaze data to the collection. When the collection is full, send it with SendSBGazeDataCollection().

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| time | [System.Int64](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int64 'System.Int64') | Unix time |
| x | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | X coordinate |
| y | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Y coordinate |

<a name='M-TobiiSBETServer-MainWindow-ETStartButtonClicked-System-Object,System-Windows-RoutedEventArgs-'></a>
### ETStartButtonClicked(sender,e) `method`

##### Summary

Click event handler for the start eye tracking button

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | Sender |
| e | [System.Windows.RoutedEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Windows.RoutedEventArgs 'System.Windows.RoutedEventArgs') | Args |

<a name='M-TobiiSBETServer-MainWindow-ETStopButtonClicked-System-Object,System-Windows-RoutedEventArgs-'></a>
### ETStopButtonClicked(sender,e) `method`

##### Summary

Click event handler for the stop eye tracker button

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | Sender |
| e | [System.Windows.RoutedEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Windows.RoutedEventArgs 'System.Windows.RoutedEventArgs') | Args |

<a name='M-TobiiSBETServer-MainWindow-GetHostAddress'></a>
### GetHostAddress() `method`

##### Summary

Get host ipv4 address

##### Returns

[string] IPv4 address

##### Parameters

This method has no parameters.

<a name='M-TobiiSBETServer-MainWindow-GetUnixTimeInMs'></a>
### GetUnixTimeInMs() `method`

##### Summary

Get current unix time in ms

##### Returns

[long] Unix time

##### Parameters

This method has no parameters.

<a name='M-TobiiSBETServer-MainWindow-InitializeComponent'></a>
### InitializeComponent() `method`

##### Summary

InitializeComponent

##### Parameters

This method has no parameters.

<a name='M-TobiiSBETServer-MainWindow-InitializeEyeTracker'></a>
### InitializeEyeTracker() `method`

##### Summary

Initialzie a eye tracker

##### Parameters

This method has no parameters.

<a name='M-TobiiSBETServer-MainWindow-InitializeLogWriter'></a>
### InitializeLogWriter() `method`

##### Summary

Initialize the streamwriter for logging csv

##### Returns

[bool] success or not

##### Parameters

This method has no parameters.

<a name='M-TobiiSBETServer-MainWindow-InitializeParameters'></a>
### InitializeParameters() `method`

##### Summary

Initialize XAML binding parameters

##### Parameters

This method has no parameters.

<a name='M-TobiiSBETServer-MainWindow-LogPreviewData-System-Int64,TobiiSBETServer-PreviewData-'></a>
### LogPreviewData(time,data) `method`

##### Summary

Log data

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| time | [System.Int64](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int64 'System.Int64') | Unix time in ms |
| data | [TobiiSBETServer.PreviewData](#T-TobiiSBETServer-PreviewData 'TobiiSBETServer.PreviewData') | Data for logging (same as previewwindow's status) |

<a name='M-TobiiSBETServer-MainWindow-NotifyPropertyChanged-System-String-'></a>
### NotifyPropertyChanged(name) `method`

##### Summary

Notifier for xaml binding properties

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Name of the property |

##### Example

```
private string _HogeStr;
public string HogeStr
{
    get { return _HogeStr; }
    set
    {
        _HogeStr = value;
        NotifyPropertyChanged(nameof(HogeStr));
    }
}
```

<a name='M-TobiiSBETServer-MainWindow-OnClosed-System-Object,System-EventArgs-'></a>
### OnClosed(sender,e) `method`

##### Summary

Called when app was closed.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | Sender |
| e | [System.EventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.EventArgs 'System.EventArgs') | Args |

<a name='M-TobiiSBETServer-MainWindow-OnContentRendered-System-Object,System-EventArgs-'></a>
### OnContentRendered(sender,e) `method`

##### Summary

Called when all content was loaded.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | Sender |
| e | [System.EventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.EventArgs 'System.EventArgs') | Args |

<a name='M-TobiiSBETServer-MainWindow-OnGazeData-System-Object,EyeTracking-OnGazeDataEventArgs-'></a>
### OnGazeData(sender,e) `method`

##### Summary

OnGazeData event handler. Receives gaze data from the eye tracker

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | Sender |
| e | [EyeTracking.OnGazeDataEventArgs](#T-EyeTracking-OnGazeDataEventArgs 'EyeTracking.OnGazeDataEventArgs') | Args |

<a name='M-TobiiSBETServer-MainWindow-SendSBGazeDataCollection'></a>
### SendSBGazeDataCollection() `method`

##### Summary

Send collected gaze data over the websocket connection

##### Parameters

This method has no parameters.

<a name='M-TobiiSBETServer-MainWindow-ShowPreviewButtonClicked-System-Object,System-Windows-RoutedEventArgs-'></a>
### ShowPreviewButtonClicked(sender,e) `method`

##### Summary

Click event handler for the show preview window button

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | Sender |
| e | [System.Windows.RoutedEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Windows.RoutedEventArgs 'System.Windows.RoutedEventArgs') | Args |

<a name='M-TobiiSBETServer-MainWindow-StartWSServer'></a>
### StartWSServer() `method`

##### Summary

Start websocket server

##### Parameters

This method has no parameters.

<a name='M-TobiiSBETServer-MainWindow-StopWSServer'></a>
### StopWSServer() `method`

##### Summary

Stop websocket server

##### Parameters

This method has no parameters.

<a name='M-TobiiSBETServer-MainWindow-UpdateAppState-TobiiSBETServer-AppState-'></a>
### UpdateAppState(state) `method`

##### Summary

Update app state with a given state

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| state | [TobiiSBETServer.AppState](#T-TobiiSBETServer-AppState 'TobiiSBETServer.AppState') | State for updating |

<a name='M-TobiiSBETServer-MainWindow-WSBroadCastString-System-String-'></a>
### WSBroadCastString(payload) `method`

##### Summary

Broadcast a given string from the running websocket server

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| payload | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | A payload string to broadcast over the websocket connection |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.InvalidOperationException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.InvalidOperationException 'System.InvalidOperationException') | "Websocket server is not running. Cannot broadcast." |

<a name='M-TobiiSBETServer-MainWindow-WSStartButtonClicked-System-Object,System-Windows-RoutedEventArgs-'></a>
### WSStartButtonClicked(sender,e) `method`

##### Summary

Click event handler for the start websocket server button

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | Sender |
| e | [System.Windows.RoutedEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Windows.RoutedEventArgs 'System.Windows.RoutedEventArgs') | Args |

<a name='M-TobiiSBETServer-MainWindow-WSStopButtonClicked-System-Object,System-Windows-RoutedEventArgs-'></a>
### WSStopButtonClicked(sender,e) `method`

##### Summary

Click event handler for the stop websocket server button

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | Sender |
| e | [System.Windows.RoutedEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Windows.RoutedEventArgs 'System.Windows.RoutedEventArgs') | Args |

<a name='T-TobiiSBETServer-PreviewData'></a>
## PreviewData `type`

##### Namespace

TobiiSBETServer

##### Summary

Data for the status bar in the preview window

<a name='F-TobiiSBETServer-PreviewData-angularVelocity'></a>
### angularVelocity `constants`

##### Summary

Angular velocity [deg/s]

<a name='F-TobiiSBETServer-PreviewData-eyeMovementType'></a>
### eyeMovementType `constants`

##### Summary

Eye movement

<a name='F-TobiiSBETServer-PreviewData-isValid'></a>
### isValid `constants`

##### Summary

Validity

<a name='F-TobiiSBETServer-PreviewData-latestLFHF'></a>
### latestLFHF `constants`

##### Summary

Latest LF/HF ratio

<a name='F-TobiiSBETServer-PreviewData-leftPD'></a>
### leftPD `constants`

##### Summary

Pupil diameter of left eye [mm]

<a name='F-TobiiSBETServer-PreviewData-rightPD'></a>
### rightPD `constants`

##### Summary

Pupil diameter of right eye [mm]

<a name='F-TobiiSBETServer-PreviewData-x'></a>
### x `constants`

##### Summary

X coordinate

<a name='F-TobiiSBETServer-PreviewData-y'></a>
### y `constants`

##### Summary

Y coordinate

<a name='T-TobiiSBETServer-PreviewWindow'></a>
## PreviewWindow `type`

##### Namespace

TobiiSBETServer

##### Summary

Interaction logic for PreviewWindow.xaml

<a name='M-TobiiSBETServer-PreviewWindow-#ctor-System-Double-'></a>
### #ctor(pointRadius) `constructor`

##### Summary

Constructor.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| pointRadius | [System.Double](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Double 'System.Double') | Gaze point radius |

<a name='F-TobiiSBETServer-PreviewWindow-gazePoint'></a>
### gazePoint `constants`

##### Summary

Gaze point for preview

<a name='F-TobiiSBETServer-PreviewWindow-pointDiameter'></a>
### pointDiameter `constants`

##### Summary

Diameter in pixels for the gaze point

<a name='F-TobiiSBETServer-PreviewWindow-previewStatusStr'></a>
### previewStatusStr `constants`

##### Summary

Internal field for the binding property

<a name='P-TobiiSBETServer-PreviewWindow-PreviewStatusStr'></a>
### PreviewStatusStr `property`

##### Summary

A XAML binding property

<a name='M-TobiiSBETServer-PreviewWindow-HideGazePoint'></a>
### HideGazePoint() `method`

##### Summary

Hide gaze point in the preview window

##### Parameters

This method has no parameters.

<a name='M-TobiiSBETServer-PreviewWindow-InitializeComponent'></a>
### InitializeComponent() `method`

##### Summary

InitializeComponent

##### Parameters

This method has no parameters.

<a name='M-TobiiSBETServer-PreviewWindow-NotifyPropertyChanged-System-String-'></a>
### NotifyPropertyChanged(name) `method`

##### Summary

Notifier for xaml binding properties

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Name of the property |

##### Example

```
private string _HogeStr;
public string HogeStr
{
    get { return _HogeStr; }
    set
    {
        _HogeStr = value;
        NotifyPropertyChanged(nameof(HogeStr));
    }
}
```

<a name='M-TobiiSBETServer-PreviewWindow-PlaceGazePoint-System-Double,System-Double,System-Double,System-Double-'></a>
### PlaceGazePoint(screenWidth,screenHeight,x,y) `method`

##### Summary

Place gaze point int the preview window

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| screenWidth | [System.Double](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Double 'System.Double') | Screen width |
| screenHeight | [System.Double](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Double 'System.Double') | Screen height |
| x | [System.Double](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Double 'System.Double') | X coordinate |
| y | [System.Double](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Double 'System.Double') | Y coordinate |

<a name='M-TobiiSBETServer-PreviewWindow-ShowGazePoint'></a>
### ShowGazePoint() `method`

##### Summary

Show gaze point in the preview window

##### Parameters

This method has no parameters.

<a name='M-TobiiSBETServer-PreviewWindow-UpdateStatusStr-TobiiSBETServer-PreviewData-'></a>
### UpdateStatusStr(data) `method`

##### Summary

Update status string in the bottom status bar

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| data | [TobiiSBETServer.PreviewData](#T-TobiiSBETServer-PreviewData 'TobiiSBETServer.PreviewData') | Data to update |

<a name='M-TobiiSBETServer-PreviewWindow-Window_Closing-System-Object,System-ComponentModel-CancelEventArgs-'></a>
### Window_Closing(sender,e) `method`

##### Summary

Closing event handler

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | Sender |
| e | [System.ComponentModel.CancelEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.CancelEventArgs 'System.ComponentModel.CancelEventArgs') | Args |

<a name='T-TobiiSBETServer-SBGazeCollectData'></a>
## SBGazeCollectData `type`

##### Namespace

TobiiSBETServer

##### Summary

Gaze data to collect from screen-based eye tracker

<a name='M-TobiiSBETServer-SBGazeCollectData-#ctor-System-Int64,System-Int32,System-Int32-'></a>
### #ctor(t,x,y) `constructor`

##### Summary

Initialzer for SBGazeCollectData

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| t | [System.Int64](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int64 'System.Int64') | Unix time in ms |
| x | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | X |
| y | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Y |

<a name='F-TobiiSBETServer-SBGazeCollectData-time'></a>
### time `constants`

##### Summary

Unix time in ms

<a name='F-TobiiSBETServer-SBGazeCollectData-x'></a>
### x `constants`

##### Summary

X coordinate

<a name='F-TobiiSBETServer-SBGazeCollectData-y'></a>
### y `constants`

##### Summary

Y coordinate

<a name='T-TobiiSBETServer-ServerBehavior'></a>
## ServerBehavior `type`

##### Namespace

TobiiSBETServer

##### Summary

Server behavior class for WebSocket

<a name='M-TobiiSBETServer-ServerBehavior-OnMessage-WebSocketSharp-MessageEventArgs-'></a>
### OnMessage(e) `method`

##### Summary

When a message was arrived

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| e | [WebSocketSharp.MessageEventArgs](#T-WebSocketSharp-MessageEventArgs 'WebSocketSharp.MessageEventArgs') | Args |

<a name='M-TobiiSBETServer-ServerBehavior-OnOpen'></a>
### OnOpen() `method`

##### Summary

When the connection is opened

##### Parameters

This method has no parameters.

<a name='T-TobiiSBETServer-WSEventID'></a>
## WSEventID `type`

##### Namespace

TobiiSBETServer

##### Summary

Event ID for websocket packets

<a name='F-TobiiSBETServer-WSEventID-FixationEnded'></a>
### FixationEnded `constants`

##### Summary

Detected a fixation is ending

<a name='F-TobiiSBETServer-WSEventID-FixationStarted'></a>
### FixationStarted `constants`

##### Summary

Detected a fixation is starting

<a name='F-TobiiSBETServer-WSEventID-LFHFComputed'></a>
### LFHFComputed `constants`

##### Summary

Latest LF/HF ratio is computed
