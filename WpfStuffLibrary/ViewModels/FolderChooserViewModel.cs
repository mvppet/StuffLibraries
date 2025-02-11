﻿using System.Windows.Input;
using WpfStuffInterfaceLibrary.IO;
using WpfStuffInterfaceLibrary.ViewModels;
using WpfStuffLibrary.Commands;

namespace WpfStuffLibrary.ViewModels;

public class FolderChooserViewModel : SimpleViewModelBase, IViewModel
{
	protected IOpenFolderDialog Dialog;
	private string _folderName = string.Empty;
	private string _label = string.Empty;
	public ICommand ButtonClicked { get; }

	public string FolderName
	{
		get => _folderName;
		set => SetProperty(ref _folderName, value);
	}

	public string Label
	{
		get => _label;
		set => SetProperty(ref _label, value);
	}

	public FolderChooserViewModel(IOpenFolderDialog dialog)
	{
		Dialog = dialog;
		ButtonClicked = new ActionCommand(ShowFolderDialog);
	}

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
	// design-time
	public FolderChooserViewModel()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
	{
	}


	private void ShowFolderDialog()
	{
		if (ShowDialog())
		{
			FolderName = Dialog.FolderName;
		}
	}

	public bool ShowDialog() => Dialog.ShowDialog();
}
