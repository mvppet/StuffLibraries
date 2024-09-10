namespace WpfStuffInterfaceLibrary.ViewModels;

public interface IViewModelFactory
{
	T NewViewModel<T>() where T : class, IViewModelBase, new();
}
