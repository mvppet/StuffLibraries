using WpfStuffInterfaceLibrary.IO;

namespace WpfStuffLibrary.ViewModels.DesignTime;
internal class DesignTimeOpenFolderDialog : IOpenFolderDialog
{
	public string DefaultDirectory { get; set; } = @"c:\Default\Folder";
	public string FolderName { get; set; } = @"d:\Selected\Folder";
	public string InitialDirectory { get; set; } = @"e:\Initial\Folder";
	public string RootDirectory { get; set; } = @"f:\Root\Folder";
	public string Title { get; set; } = @"Select Something";

	public bool ShowDialog()
		=> true;
	
}
