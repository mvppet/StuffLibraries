namespace WpfStuffLibrary.ViewModels.DesignTime;

internal class DesignTimeFolderChooserViewModel : FolderChooserViewModel
{
	public DesignTimeFolderChooserViewModel()
		: base(new DesignTimeOpenFolderDialog())
	{
		FolderName = Dialog.FolderName;
		Label = "Folder Chooser Label";
	}
}
