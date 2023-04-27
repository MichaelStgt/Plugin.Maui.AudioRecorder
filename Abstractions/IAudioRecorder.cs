using System.Globalization;

namespace Plugin.Maui.AudioRecorder.Abstractions;

/// <summary>
/// Interface to help you record quality audios
/// </summary>
public interface IAudioRecorder
{
    ///<Summary>
    /// Check if the executing device is capable of recording audio
    ///</Summary>
    bool CanRecordAudio { get; }

    ///<Summary>
    /// Check if the executing device is capable of recording audio
    ///</Summary>
    bool IsRecording { get; }

    ///<Summary>
    /// Path where the file was save
    ///</Summary>
    string FilePath { get; set; }

    /// <summary>
    /// Starts a new recording, only record!
    /// </summary>
    Task StartRecordAsync();

    /// <summary>
    /// Starts a new recording, and fills the recognitionResult with a text transcribed.
    /// </summary>
    Task StartRecordAsync(CultureInfo culture,
        IProgress<string> recognitionResult,
        CancellationToken cancellationToken);

    /// <summary>
    /// Stops the current recording, returning a Audio instance
    /// </summary>
    Task<Audio> StopRecordAsync();

    void Dispose();
}
