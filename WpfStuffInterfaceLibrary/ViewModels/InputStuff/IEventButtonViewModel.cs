using StuffInterfaceLibrary.Events;

namespace WpfStuffInterfaceLibrary.ViewModels.InputStuff;

public interface IEventButtonViewModel<T> where T : IAggregatedEvent
{
	IEventAggregator? EventAggregator { get; set; }
	IViewModelFactory? ViewModelFactory { get; set; }
}
