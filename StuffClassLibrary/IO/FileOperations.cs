using System.Security.Cryptography;
using StuffInterfaceLibrary.IO;

namespace StuffClassLibrary.IO;
public class FileOperations : IFileOperations
{
	public async Task<IFileDetails> ReadFileDetailsWithChecksumAsync(string filename)
	{
		using var md5 = MD5.Create();
		using var stream = File.OpenRead(filename);

		var hash = await md5.ComputeHashAsync(stream);

		return new FileDetails(
			filename,
			BitConverter.ToString(hash).Replace("-", string.Empty).ToLower(),
			FileSize(filename)
		);
	}

	public IFileDetails ReadFileDetailsWithChecksum(string filename)
	{
		using var md5 = MD5.Create();
		using var stream = File.OpenRead(filename);

		var hash = md5.ComputeHash(stream);

		return new FileDetails(
			filename,
			BitConverter.ToString(hash).Replace("-", string.Empty).ToLower(),
			FileSize(filename)
		);
	}

	public long FileSize(string filename)
		=> new FileInfo(filename).Length;
}
