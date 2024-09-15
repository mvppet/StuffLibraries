using System.Windows;
using StuffInterfaceLibrary.Events;
using WpfStuffInterfaceLibrary.Enums;
using WpfStuffInterfaceLibrary.ViewModels;
using WpfStuffInterfaceLibrary.Windows;

namespace WpfStuffLibrary.Windows;
public class WindowBase : Window, IWindow
{
	public IViewModel? ViewModel
	{
		get => (IViewModel)DataContext;
		set => DataContext = value;
	}

	protected IEventAggregator? EventAggregator { get; }

	public WindowBase(IEventAggregator eventAggregator)
	{
		EventAggregator = eventAggregator;
	}

	public WindowBase()
	{
		Closing += WindowBase_Closing;
		Closed += WindowBase_Closed;
	}

	public void Show(WindowTypes windowType = WindowTypes.Modal)
	{
		switch (windowType)
		{
			case WindowTypes.Modal:
				base.ShowDialog();
				break;
			case WindowTypes.NonModal:
				base.Show();
				break;
		}
	}

	public virtual void Close<T>() where T : IAggregatedEvent
	{
		ArgumentNullException.ThrowIfNull(EventAggregator);
		Close();
		EventAggregator.Publish<T>();
	}

	public void Close(Action callback)
	{
		Close();
		callback();
	}

	private void WindowBase_Closed(object? sender, EventArgs e)
	{
		WindowClosed();
	}

	private void WindowBase_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
	{
		WindowClosing();
	}

	protected virtual void WindowClosing()
	{
	}

	protected virtual void WindowClosed()
	{
	}

}
