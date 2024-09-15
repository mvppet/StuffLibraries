using StuffInterfaceLibrary.Events;
using WpfStuffInterfaceLibrary.Enums;
using WpfStuffInterfaceLibrary.ViewModels;

namespace WpfStuffInterfaceLibrary.Windows;

public interface IWindow
{
	IViewModel? ViewModel { get; set; }
	string Title { get; }

	void Show(WindowTypes windowType = WindowTypes.Modal);
	void Close();
	void Close<T>() where T: IAggregatedEvent;
	void Close(Action callback);

}
