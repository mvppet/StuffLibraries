using System.Security.Cryptography;
using StuffInterfaceLibrary.IO;

namespace StuffClassLibrary.IO;
public class FileOperations : IFileOperations
{
	public IFileDetails ReadFileDetails(string filename)
		=> new FileDetails(
				filename,
				FileSize(filename)
			);

	public long FileSize(string filename)
		=> new FileInfo(filename).Length;

	public string GetChecksum(string filename)
	{
		using var md5 = MD5.Create();
		using var stream = File.OpenRead(filename);
		var hash = md5.ComputeHash(stream);
		return BitConverter.ToString(hash).Replace("-", string.Empty).ToLower();
	}
}
