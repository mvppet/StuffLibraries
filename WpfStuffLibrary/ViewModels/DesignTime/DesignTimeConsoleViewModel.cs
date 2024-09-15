namespace WpfStuffLibrary.ViewModels.DesignTime;
internal class DesignTimeConsoleViewModel : ConsoleViewModel
{
	public DesignTimeConsoleViewModel()
		: base(new DesignTimeEventAggregator(), new DesignTimeViewModelFactory())
	{
		Add("Really Really Really Really Really Really Really Really Really Really Really Really Really Really Really Really Really Really Really Really Really Really Really Really Really Really Long Log Line");
		for (int i = 0; i < 30; i++)
		{
			Add($"Message {i}");
		}
	}
}
