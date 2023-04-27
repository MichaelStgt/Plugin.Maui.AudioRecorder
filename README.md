# Plugin.Maui.AudioRecorder

## Overview
This plugin provides functionality to record audio and transcribe spoken text into written format in real-time, while saving the audio file. It is designed for use with .NET Multi-platform App UI (MAUI) framework.

## Features
* Record audio from device microphone
* Real-time transcription of spoken text to written format
* Ability to save the audio file with transcription

## Installation
1 - Install the NuGet package ```Plugin.Maui.AudioRecorder``` <br/>
2 - In your .NET MAUI project, add the following using statement to ```MauiProgram.cs``` file to use this plugin: <br />
```csharp
using Plugin.Maui.AudioRecorder;
```
3 - Add this plugin to the ```MauiApp``` pipeline: <br />
```csharp
builder
  // ...
  .UseAudioRecorder()
  // ...
```
4 - Enjoy it!

## Usage
## Inject the Audio service
First of all, you must inject the ```IAudioRecorder``` service, remembering that in this example we will consider a class that uses MVVM with the CommunityToolkit.Mvvm module.
```csharp
using CommunityToolkit.Mvvm.ComponentModel;
using Plugin.Maui.AudioRecorder;

namespace MyAwesomeProject.ViewModels;

[ObservableObject]
public partial class RecordingPageViewModel
{
  private readonly IAudioRecorder _audioRecorderService;

  public RecordingPageViewModel(IAudioRecorder audioRecorderService)
  {
    _audioRecorderService = audioRecorderService;
  }

  [ObservableProperty]
  private bool isRecording;

  // ...
}
```
If you prefer, you can call the instance as follows:
```csharp
var audioRecorderService = Services.GetService(typeof(IAudioRecorder)) as IAudioRecorder;

// ...
```

### Start Recording
To start the recording we offer the ```StartRecordAsync``` method, which can be called in two ways:

* <strong>Without parameters</strong>: In this way we only save the audio in the chosen path, i.e. we do not transcribe the audio for you.
```csharp
[RelayCommand]
private async void HandleRecord()
{
  // Setting the path of the file
  _audioRecorderService.FilePath = Path.Combine("/storage/emulated/0/Download", fileName);

  await audioService.StartRecordAsync();
}
```

* <strong>With parameters</strong>: If you want us to return to you, in addition to saving the audio, the transcribed text, you will need to pass three arguments to this method: An ```CultureInfo``` instance so we know what language your input audio will be, an ```IProgress``` instance, so you decide how the text will be processed, and a ```CancellationToken```, standard for asynchronous methods.
```csharp
[RelayCommand]
private async void HandleRecord()
{
  // Setting the path of the file
  _audioRecorderService.FilePath = Path.Combine("/storage/emulated/0/Download", fileName);

  await _audioService.StartRecordAsync(
    CultureInfo.GetCultureInfo("en-us"),
    new Progress<string>(partialText =>
    {
      // ...
    }),
    CancellationToken.None,
  );
}
```

### Stop Recording
To stop the recording we offer the ```StopRecordAsync``` method:
```csharp
[RelayCommand]
private async void HandleStopRecord()
{
  // will returns a Audio instance!
  var audio = await _audioService.StopRecordAsync();
}
```

## Limitations
* Transcription accuracy may vary depending on factors such as background noise, speaker accent, and speech speed.

## License
This plugin is released under the GNU AFFERO GENERAL PUBLIC License. See the LICENSE file for details.
