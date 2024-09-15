using System.Windows.Input;

namespace WpfStuffLibrary.ViewModels.DesignTime;
internal class DesignTimeCommandImplementation : ICommand
{
	public event EventHandler? CanExecuteChanged;

	public bool CanExecute(object? parameter)
		=> true;

	public void Execute(object? parameter)
	{
	}
}
