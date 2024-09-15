using System.Windows.Input;
using WpfStuffInterfaceLibrary.ViewModels;
using WpfStuffInterfaceLibrary.ViewModels.InputStuff;

namespace WpfStuffLibrary.ViewModels.DesignTime;
internal class DesignTimeViewModelFactory : IViewModelFactory
{
	ICommand IViewModelFactory.NewAggregatedEventCommand<T>()
		=> new DesignTimeCommandImplementation();

	IEventButtonViewModel<DesignTimeAggregatedEvent> IViewModelFactory.NewEventButtonViewModel<DesignTimeAggregatedEvent>()
		=> new DesignTimeEventButtonViewModel<DesignTimeAggregatedEvent>();

	T IViewModelFactory.NewSimpleViewModel<T>()
		=> new();

	T IViewModelFactory.NewViewModel<T>()
		=> new();
}
