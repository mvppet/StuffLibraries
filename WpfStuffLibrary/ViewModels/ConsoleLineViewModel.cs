using WpfStuffInterfaceLibrary.ViewModels;

namespace WpfStuffLibrary.ViewModels;

public class ConsoleLineViewModel : SimpleViewModelBase, IConsoleLineViewModel
{
	public DateTime Timestamp { get; set; } = DateTime.Now;
	public string Text { get; set; }

	public ConsoleLineViewModel(string text)
	{
		Text = text;
	}

}
