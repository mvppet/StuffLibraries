namespace StuffInterfaceLibrary.IO;
public interface IFileDetails
{
	public string Filename { get; }
	public string Checksum { get; }
	public long FileSize { get; }
}
