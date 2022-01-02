<a name='assembly'></a>
# TobiiSBETServer

## Contents

- [App](#T-TobiiSBETServer-App 'TobiiSBETServer.App')
  - [InitializeComponent()](#M-TobiiSBETServer-App-InitializeComponent 'TobiiSBETServer.App.InitializeComponent')
  - [Main()](#M-TobiiSBETServer-App-Main 'TobiiSBETServer.App.Main')
- [MainWindow](#T-TobiiSBETServer-MainWindow 'TobiiSBETServer.MainWindow')
  - [#ctor()](#M-TobiiSBETServer-MainWindow-#ctor 'TobiiSBETServer.MainWindow.#ctor')
  - [eyeTracker](#F-TobiiSBETServer-MainWindow-eyeTracker 'TobiiSBETServer.MainWindow.eyeTracker')
  - [pupilDataProcessor](#F-TobiiSBETServer-MainWindow-pupilDataProcessor 'TobiiSBETServer.MainWindow.pupilDataProcessor')
  - [AppCloseEvent(sender,e)](#M-TobiiSBETServer-MainWindow-AppCloseEvent-System-Object,System-Windows-Input-ExecutedRoutedEventArgs- 'TobiiSBETServer.MainWindow.AppCloseEvent(System.Object,System.Windows.Input.ExecutedRoutedEventArgs)')
  - [InitializeComponent()](#M-TobiiSBETServer-MainWindow-InitializeComponent 'TobiiSBETServer.MainWindow.InitializeComponent')
  - [MainWindowContentRendered(sender,e)](#M-TobiiSBETServer-MainWindow-MainWindowContentRendered-System-Object,System-EventArgs- 'TobiiSBETServer.MainWindow.MainWindowContentRendered(System.Object,System.EventArgs)')
  - [OnClosed(sender,e)](#M-TobiiSBETServer-MainWindow-OnClosed-System-Object,System-EventArgs- 'TobiiSBETServer.MainWindow.OnClosed(System.Object,System.EventArgs)')

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

<a name='F-TobiiSBETServer-MainWindow-eyeTracker'></a>
### eyeTracker `constants`

##### Summary

An instance from EyeTracking.TobiiSBETDriver

<a name='F-TobiiSBETServer-MainWindow-pupilDataProcessor'></a>
### pupilDataProcessor `constants`

##### Summary

An instance from EyeTracking.PupilDataProcessor

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

<a name='M-TobiiSBETServer-MainWindow-MainWindowContentRendered-System-Object,System-EventArgs-'></a>
### MainWindowContentRendered(sender,e) `method`

##### Summary

Called when all content was loaded.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | Sender |
| e | [System.EventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.EventArgs 'System.EventArgs') | Args |

<a name='M-TobiiSBETServer-MainWindow-OnClosed-System-Object,System-EventArgs-'></a>
### OnClosed(sender,e) `method`

##### Summary

Called when app was closed.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | Sender |
| e | [System.EventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.EventArgs 'System.EventArgs') | Args |
