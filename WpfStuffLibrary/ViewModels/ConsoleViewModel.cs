using System.Collections.ObjectModel;
using StuffInterfaceLibrary.Events;
using WpfStuffInterfaceLibrary;
using WpfStuffInterfaceLibrary.Enums;
using WpfStuffInterfaceLibrary.ViewModels;

namespace WpfStuffLibrary.ViewModels;

public class ConsoleViewModel : ViewModelBase, IConsoleViewModel
{
	public ObservableCollection<IConsoleLineViewModel> LogLines { get; } = [];

	public ConsoleViewModel(IEventAggregator eventAggregator, IViewModelFactory viewModelFactory)
		: base(eventAggregator, viewModelFactory)
	{
	}

	// design-time
	public ConsoleViewModel()
	: base()
	{
	}


	public void Add(string text)
	{
		LogLines.Add(new ConsoleLineViewModel(text));
	}
	public void Add(IConsoleLineViewModel logItem)
	{
		LogLines.Add(logItem);
	}

	// TODO : make things coloured depending on meesage type
	public void Add(LogMessageTypes logMessageType, string text)
		=> Add(text);
	public void Add(LogMessageTypes logMessageType, IConsoleLineViewModel logItem)
		=> Add(logItem);
}
