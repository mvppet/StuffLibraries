using StuffInterfaceLibrary.IO;

namespace StuffClassLibrary.IO;

public class FileDetails : IFileDetails
{
	public string Filename { get; }
	public string Checksum { get; }
	public long FileSize { get; }

	public FileDetails(string filename, string checksum, long fileSize)
	{
		Filename = filename;
		Checksum = checksum;
		FileSize = fileSize;
	}
}