using Android.OS;
using Android.Runtime;
using Android.Speech;

namespace Plugin.Maui.AudioRecorder;

public class SpeechRecognitionListener : Java.Lang.Object, IRecognitionListener
{
	public Action<SpeechRecognizerError> Error { get; set; }
	public Action<string> PartialResults { get; set; }
	public Action<string> Results { get; set; }

	public void OnBeginningOfSpeech()
	{
	}

	public void OnBufferReceived(byte[] buffer)
	{
	}

	public void OnEndOfSpeech()
	{
	}

	public void OnError([GeneratedEnum] SpeechRecognizerError error)
	{
		Error.Invoke(error);
	}

	public void OnEvent(int eventType, Bundle @params)
	{
	}

	public void OnPartialResults(Bundle partialResults)
	{
		SendResults(partialResults, PartialResults);
	}

	public void OnReadyForSpeech(Bundle @params)
	{
	}

	public void OnResults(Bundle results)
	{
		SendResults(results, Results);
	}

	public void OnRmsChanged(float rmsdB)
	{
	}

	static void SendResults(Bundle bundle, Action<string> action)
	{
		var matches = bundle.GetStringArrayList(SpeechRecognizer.ResultsRecognition);
		if (matches is null || matches.Count is 0)
		{
			return;
		}

		action.Invoke(matches.First());
	}
}
