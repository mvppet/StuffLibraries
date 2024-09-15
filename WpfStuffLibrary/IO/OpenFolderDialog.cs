using StuffInterfaceLibrary.Events;
using WpfStuffInterfaceLibrary.IO;

namespace WpfStuffLibrary.IO;

public class OpenFolderDialog : IOpenFolderDialog
{
	protected Microsoft.Win32.OpenFolderDialog FolderDialog = new();

	public string DefaultDirectory
	{
		get => FolderDialog.DefaultDirectory;
		set => FolderDialog.DefaultDirectory = value;
	}

	public string FolderName
	{
		get => FolderDialog.FolderName;
		set => FolderDialog.FolderName = value;
	}

	public string InitialDirectory
	{
		get => FolderDialog.InitialDirectory;
		set => FolderDialog.InitialDirectory = value;
	}

	public string RootDirectory
	{
		get => FolderDialog.RootDirectory;
		set => FolderDialog.RootDirectory = value;
	}

	public string Title
	{
		get => FolderDialog.Title;
		set => FolderDialog.Title = value;
	}

	public bool ShowDialog() => FolderDialog.ShowDialog() ?? false;
}

public class OpenFolderDialog<T> : OpenFolderDialog where T : class, IFolderOkEvent, new()
{
	private IEventAggregator _eventAggregator;
	private object? _tag;

	public OpenFolderDialog(IEventAggregator eventAggregator, object? tag = null)
		: base()
	{
		ArgumentNullException.ThrowIfNull(nameof(eventAggregator));
		_eventAggregator = eventAggregator;
		_tag = tag;
		FolderDialog.FolderOk += FolderDialog_FolderOk;
	}

	private void FolderDialog_FolderOk(object? sender, System.ComponentModel.CancelEventArgs e)
	{
		T payload = new()
		{
			Tag = _tag,
			FolderName = FolderDialog.FolderName
		};
		_eventAggregator.Publish(payload);
	}
}