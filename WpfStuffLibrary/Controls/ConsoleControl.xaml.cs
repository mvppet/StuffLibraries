using System.Windows.Controls;

namespace WpfStuffLibrary.Controls;

public partial class ConsoleControl : UserControlBase
{
	public ConsoleControl()
	{
		InitializeComponent();
	}

	private void ItemsControl_SizeChanged(object sender, System.Windows.SizeChangedEventArgs e)
	{
		Scrolly.ScrollToBottom();
	}
}
