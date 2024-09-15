﻿using System.Windows.Input;

namespace WpfStuffLibrary.Commands;

public class ActionCommand : ICommand
{
	private Action _action;
	public event EventHandler? CanExecuteChanged;

	public ActionCommand(Action action)
	{
		_action = action;
	}

	public bool CanExecute(object? parameter)
		=> true;

	public void Execute(object? parameter)
	{
		_action();
	}
}
