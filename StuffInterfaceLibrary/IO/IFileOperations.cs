namespace StuffInterfaceLibrary.IO;
public interface IFileOperations
{
	IFileDetails ReadFileDetailsWithChecksum(string filename);
	Task<IFileDetails> ReadFileDetailsWithChecksumAsync(string filename);

	long FileSize(string filename);
}
