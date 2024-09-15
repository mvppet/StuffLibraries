using StuffInterfaceLibrary.IO;

namespace StuffClassLibrary.IO;
public class FolderOperations : IFolderOperations
{
	public List<string> GetFiles(string folder)
		=> Directory.GetFiles(folder).ToList();

	public List<string> GetFolders(string folder)
		=> Directory.GetDirectories(folder).ToList();

}
