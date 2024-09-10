using StuffInterfaceLibrary.Events;
using WpfStuffInterfaceLibrary.Enums;

namespace WpfStuffInterfaceLibrary.Windows;

public interface IWindow
{
	string Title { get; }

	void Show(WindowTypes windowType = WindowTypes.Modal);
	void Close();
	void Close<T>() where T: IAggregatedEvent;

	void Close(Action callback);

}
