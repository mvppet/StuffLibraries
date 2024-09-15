using System.Collections.ObjectModel;
using WpfStuffInterfaceLibrary.Enums;
using WpfStuffInterfaceLibrary.ViewModels;

namespace WpfStuffInterfaceLibrary;

public interface IConsoleViewModel : IViewModelBase
{
	ObservableCollection<IConsoleLineViewModel> LogLines { get; }

	void Add(string text);
	void Add(IConsoleLineViewModel logItem);

	void Add(LogMessageTypes logMessageType, string text);
	void Add(LogMessageTypes logMessageType, IConsoleLineViewModel logItem);
}
