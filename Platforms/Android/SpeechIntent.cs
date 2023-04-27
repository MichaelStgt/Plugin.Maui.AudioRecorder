using Android.Content;
using Android.Speech;
using System.Globalization;

namespace Plugin.Maui.AudioRecorder;

internal static class SpeechIntent
{
	public static Intent CreateSpeechIntent(CultureInfo culture)
	{
		var intent = new Intent(RecognizerIntent.ActionRecognizeSpeech);
		intent.PutExtra(RecognizerIntent.ExtraLanguagePreference, Java.Util.Locale.Default);
		var javaLocale = Java.Util.Locale.ForLanguageTag(culture.Name);

		intent.PutExtra(RecognizerIntent.ExtraLanguage, javaLocale);
		intent.PutExtra(RecognizerIntent.ExtraLanguageModel, RecognizerIntent.LanguageModelFreeForm);
		intent.PutExtra(RecognizerIntent.ExtraCallingPackage, Android.App.Application.Context.PackageName);
		intent.PutExtra(RecognizerIntent.ExtraSpeechInputCompleteSilenceLengthMillis, 8000);
		intent.PutExtra(RecognizerIntent.ExtraPartialResults, true);

		return intent;
	}
}
