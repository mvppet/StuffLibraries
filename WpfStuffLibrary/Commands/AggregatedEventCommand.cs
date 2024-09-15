using System.Windows.Input;
using StuffInterfaceLibrary.Events;

namespace WpfStuffLibrary.Commands;

public class AggregatedEventCommand<T> : ICommand where T : IAggregatedEvent
{
	public event EventHandler? CanExecuteChanged;
	protected IEventAggregator? EventAggregator { get; }

	public AggregatedEventCommand(IEventAggregator eventAggregator)
	{
		EventAggregator = eventAggregator;
	}

	public bool CanExecute(object? parameter)
		=> true;

	public void Execute(object? parameter)
	{
		//var tt = typeof(T).Name;
		EventAggregator?.Publish<T>();
	}
}
