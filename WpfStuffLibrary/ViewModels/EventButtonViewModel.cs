using System.Windows.Input;
using StuffInterfaceLibrary.Events;
using WpfStuffInterfaceLibrary.ViewModels;
using WpfStuffInterfaceLibrary.ViewModels.InputStuff;

namespace WpfStuffLibrary.ViewModels;

public class EventButtonViewModel<T>
	: ViewModelBase, IEventButtonViewModel<T> where T : class, IAggregatedEvent, new()
{
	public ICommand ButtonClicked { get; }

	public EventButtonViewModel(IEventAggregator eventAggregator, IViewModelFactory viewModelFactory)
		: base(eventAggregator, viewModelFactory)
	{
		ButtonClicked = viewModelFactory.NewAggregatedEventCommand<T>();
	}
}
