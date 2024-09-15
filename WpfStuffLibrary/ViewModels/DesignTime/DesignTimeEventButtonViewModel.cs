using StuffInterfaceLibrary.Events;
using WpfStuffInterfaceLibrary.ViewModels;
using WpfStuffInterfaceLibrary.ViewModels.InputStuff;

namespace WpfStuffLibrary.ViewModels.DesignTime;
internal class DesignTimeEventButtonViewModel<T> : IEventButtonViewModel<T> where T : class, IAggregatedEvent
{
	public IEventAggregator? EventAggregator { get; set; }
	public IViewModelFactory? ViewModelFactory { get; set; }
}
