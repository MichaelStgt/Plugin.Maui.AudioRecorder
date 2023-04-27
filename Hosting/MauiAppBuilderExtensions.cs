using Plugin.Maui.AudioRecorder.Abstractions;

[assembly: XmlnsDefinition("https://schemas.math3ussdl.com/dotnet/2023/maui", "Plugin.Maui.AudioRecorder")]
namespace Plugin.Maui.AudioRecorder.Hosting;

public static class MauiAppBuilderExtensions
{
    public static MauiAppBuilder UseAudioRecorder(this MauiAppBuilder builder)
    {
#if ANDROID
        builder.Services.AddSingleton<IAudioRecorder, AudioRecorderAndroidImpl>();
#endif

        return builder;
    }
}
