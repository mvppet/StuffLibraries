using System.Windows.Input;
using StuffInterfaceLibrary.Events;
using WpfStuffInterfaceLibrary.ViewModels.InputStuff;

namespace WpfStuffInterfaceLibrary.ViewModels;

public interface IViewModelFactory
{
	ICommand NewAggregatedEventCommand<T>() where T : class, IAggregatedEvent, new();

	IEventButtonViewModel<T> NewEventButtonViewModel<T>() where T : class, IAggregatedEvent, new();

	T NewSimpleViewModel<T>() where T : class, ISimpleViewModelBase, new();
	T NewViewModel<T>() where T : class, IViewModelBase, new();
}
