namespace StuffInterfaceLibrary.IO;

public interface IFolderOperations
{
	List<string> GetFiles(string folder); 
	List<string> GetFolders(string folder);
}
