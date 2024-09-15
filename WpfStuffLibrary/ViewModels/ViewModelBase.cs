using StuffInterfaceLibrary.Events;
using WpfStuffInterfaceLibrary.ViewModels;

namespace WpfStuffLibrary.ViewModels;

public class ViewModelBase : SimpleViewModelBase
{
	public IEventAggregator? EventAggregator { get; set; }
	public IViewModelFactory? ViewModelFactory { get; set; }

	public ViewModelBase(IEventAggregator eventAggregator, IViewModelFactory viewModelFactory)
	{
		EventAggregator = eventAggregator;
		ViewModelFactory = viewModelFactory;
	}

	public ViewModelBase(IEventAggregator eventAggregator)
	{
		EventAggregator = eventAggregator;
	}

	public ViewModelBase(IViewModelFactory viewModelFactory)
	{
		ViewModelFactory = viewModelFactory;
	}

	public ViewModelBase()
		: base()
	{
	}
}
