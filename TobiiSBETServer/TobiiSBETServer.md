<a name='assembly'></a>
# TobiiSBETServer

## Contents

- [App](#T-TobiiSBETServer-App 'TobiiSBETServer.App')
  - [InitializeComponent()](#M-TobiiSBETServer-App-InitializeComponent 'TobiiSBETServer.App.InitializeComponent')
  - [Main()](#M-TobiiSBETServer-App-Main 'TobiiSBETServer.App.Main')
- [MainWindow](#T-TobiiSBETServer-MainWindow 'TobiiSBETServer.MainWindow')
  - [#ctor()](#M-TobiiSBETServer-MainWindow-#ctor 'TobiiSBETServer.MainWindow.#ctor')
  - [angularVelocityThreshold](#F-TobiiSBETServer-MainWindow-angularVelocityThreshold 'TobiiSBETServer.MainWindow.angularVelocityThreshold')
  - [appStatusStr](#F-TobiiSBETServer-MainWindow-appStatusStr 'TobiiSBETServer.MainWindow.appStatusStr')
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
  - [isLFHFComputerEnabled](#F-TobiiSBETServer-MainWindow-isLFHFComputerEnabled 'TobiiSBETServer.MainWindow.isLFHFComputerEnabled')
  - [isNotETStarted](#F-TobiiSBETServer-MainWindow-isNotETStarted 'TobiiSBETServer.MainWindow.isNotETStarted')
  - [isNotWSStarted](#F-TobiiSBETServer-MainWindow-isNotWSStarted 'TobiiSBETServer.MainWindow.isNotWSStarted')
  - [isShowPreviewButtonEnabled](#F-TobiiSBETServer-MainWindow-isShowPreviewButtonEnabled 'TobiiSBETServer.MainWindow.isShowPreviewButtonEnabled')
  - [isWSStartButtonEnabled](#F-TobiiSBETServer-MainWindow-isWSStartButtonEnabled 'TobiiSBETServer.MainWindow.isWSStartButtonEnabled')
  - [isWSStopButtonEnabled](#F-TobiiSBETServer-MainWindow-isWSStopButtonEnabled 'TobiiSBETServer.MainWindow.isWSStopButtonEnabled')
  - [lfHighFreq](#F-TobiiSBETServer-MainWindow-lfHighFreq 'TobiiSBETServer.MainWindow.lfHighFreq')
  - [lfLowFreq](#F-TobiiSBETServer-MainWindow-lfLowFreq 'TobiiSBETServer.MainWindow.lfLowFreq')
  - [portNumber](#F-TobiiSBETServer-MainWindow-portNumber 'TobiiSBETServer.MainWindow.portNumber')
  - [prevUnixTimeInMs](#F-TobiiSBETServer-MainWindow-prevUnixTimeInMs 'TobiiSBETServer.MainWindow.prevUnixTimeInMs')
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
  - [InitializeComponent()](#M-TobiiSBETServer-MainWindow-InitializeComponent 'TobiiSBETServer.MainWindow.InitializeComponent')
  - [NotifyPropertyChanged(name)](#M-TobiiSBETServer-MainWindow-NotifyPropertyChanged-System-String- 'TobiiSBETServer.MainWindow.NotifyPropertyChanged(System.String)')
  - [OnClosed(sender,e)](#M-TobiiSBETServer-MainWindow-OnClosed-System-Object,System-EventArgs- 'TobiiSBETServer.MainWindow.OnClosed(System.Object,System.EventArgs)')
  - [OnContentRendered(sender,e)](#M-TobiiSBETServer-MainWindow-OnContentRendered-System-Object,System-EventArgs- 'TobiiSBETServer.MainWindow.OnContentRendered(System.Object,System.EventArgs)')

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

<a name='F-TobiiSBETServer-MainWindow-portNumber'></a>
### portNumber `constants`

##### Summary

Internal field for the binding property

<a name='F-TobiiSBETServer-MainWindow-prevUnixTimeInMs'></a>
### prevUnixTimeInMs `constants`

##### Summary

Unix Time in ms when received gaze data last time

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

<a name='M-TobiiSBETServer-MainWindow-InitializeComponent'></a>
### InitializeComponent() `method`

##### Summary

InitializeComponent

##### Parameters

This method has no parameters.

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
