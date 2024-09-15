namespace WpfStuffInterfaceLibrary.IO;

public interface IOpenFolderDialog
{
	string DefaultDirectory { get; set; }
	string FolderName { get; set; }
	string InitialDirectory { get; set; }
	string RootDirectory { get; set; }
	string Title { get; set; }

	bool ShowDialog();
}