<a name='assembly'></a>
# TobiiSBETServer

## Contents

- [App](#T-TobiiSBETServer-App 'TobiiSBETServer.App')
  - [InitializeComponent()](#M-TobiiSBETServer-App-InitializeComponent 'TobiiSBETServer.App.InitializeComponent')
  - [Main()](#M-TobiiSBETServer-App-Main 'TobiiSBETServer.App.Main')
- [MainWindow](#T-TobiiSBETServer-MainWindow 'TobiiSBETServer.MainWindow')
  - [#ctor()](#M-TobiiSBETServer-MainWindow-#ctor 'TobiiSBETServer.MainWindow.#ctor')
  - [deviceInfoStr](#F-TobiiSBETServer-MainWindow-deviceInfoStr 'TobiiSBETServer.MainWindow.deviceInfoStr')
  - [eyeTracker](#F-TobiiSBETServer-MainWindow-eyeTracker 'TobiiSBETServer.MainWindow.eyeTracker')
  - [pupilDataProcessor](#F-TobiiSBETServer-MainWindow-pupilDataProcessor 'TobiiSBETServer.MainWindow.pupilDataProcessor')
  - [statusStr](#F-TobiiSBETServer-MainWindow-statusStr 'TobiiSBETServer.MainWindow.statusStr')
  - [DeviceInfoStr](#P-TobiiSBETServer-MainWindow-DeviceInfoStr 'TobiiSBETServer.MainWindow.DeviceInfoStr')
  - [StatusStr](#P-TobiiSBETServer-MainWindow-StatusStr 'TobiiSBETServer.MainWindow.StatusStr')
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

<a name='F-TobiiSBETServer-MainWindow-deviceInfoStr'></a>
### deviceInfoStr `constants`

##### Summary

Internal field for the binding property DeviceInfoStr

<a name='F-TobiiSBETServer-MainWindow-eyeTracker'></a>
### eyeTracker `constants`

##### Summary

An instance from EyeTracking.TobiiSBETDriver

<a name='F-TobiiSBETServer-MainWindow-pupilDataProcessor'></a>
### pupilDataProcessor `constants`

##### Summary

An instance from EyeTracking.PupilDataProcessor

<a name='F-TobiiSBETServer-MainWindow-statusStr'></a>
### statusStr `constants`

##### Summary

Internal field for the binding property StatusStr

<a name='P-TobiiSBETServer-MainWindow-DeviceInfoStr'></a>
### DeviceInfoStr `property`

##### Summary

A XAML binding property

<a name='P-TobiiSBETServer-MainWindow-StatusStr'></a>
### StatusStr `property`

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
