using StuffInterfaceLibrary.Events;

namespace WpfStuffInterfaceLibrary.ViewModels;

public interface IViewModelBase
{
	IEventAggregator? EventAggregator { get; set; }
	IViewModelFactory? ViewModelFactory { get; set; }
}
