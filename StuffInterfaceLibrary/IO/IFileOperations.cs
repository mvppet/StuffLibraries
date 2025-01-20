namespace StuffInterfaceLibrary.IO;
public interface IFileOperations
{
	IFileDetails ReadFileDetails(string filename);
	long FileSize(string filename);
	string GetChecksum(string filename);
}
