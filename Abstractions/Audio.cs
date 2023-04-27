namespace Plugin.Maui.AudioRecorder.Abstractions;

public class Audio : IDisposable
{
	private string _filePath;

	public Audio(string filePath)
	{
		_filePath = filePath;
	}

	public bool HasRecording => File.Exists(_filePath);

	public string GetFilePath()
	{
		return _filePath;
	}

	public Stream GetAudioStream()
	{
		if (File.Exists(_filePath))
			return new FileStream(_filePath, FileMode.Open, FileAccess.Read);

		return null;
	}

	void DeleteFile()
	{
		if (File.Exists(_filePath))
			File.Delete(_filePath);

		_filePath = string.Empty;
	}

	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (disposing)
		{
			DeleteFile();
		}
	}
}
