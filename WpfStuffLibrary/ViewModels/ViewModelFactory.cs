using StuffInterfaceLibrary.Events;
using System.Windows.Input;
using WpfStuffInterfaceLibrary.ViewModels.InputStuff;
using WpfStuffInterfaceLibrary.ViewModels;
using WpfStuffLibrary.Commands;

namespace WpfStuffLibrary.ViewModels;
public class ViewModelFactory : IViewModelFactory
{
	public IEventAggregator? EventAggregator { get; }

	public ViewModelFactory(IEventAggregator eventAggregator)
	{
		EventAggregator = eventAggregator;
	}

	public T NewSimpleViewModel<T>() where T : class, ISimpleViewModelBase, new()
		=> new();

	public T NewViewModel<T>() where T : class, IViewModelBase, new()
		=> new()
		{
			EventAggregator = EventAggregator,
			ViewModelFactory = this
		};

	public ICommand NewAggregatedEventCommand<T>() where T : class, IAggregatedEvent, new()
		=> new AggregatedEventCommand<T>(EventAggregator!);

	public IEventButtonViewModel<T> NewEventButtonViewModel<T>() where T : class, IAggregatedEvent, new()
		=> new EventButtonViewModel<T>(EventAggregator!, this);
}
