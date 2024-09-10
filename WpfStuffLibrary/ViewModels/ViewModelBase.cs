using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using StuffInterfaceLibrary.Events;
using WpfStuffInterfaceLibrary.ViewModels;

namespace WpfStuffLibrary.ViewModels;

public class ViewModelBase : DependencyObject, INotifyPropertyChanged
{
	protected IEventAggregator? EventAggregator { get; }
	protected IViewModelFactory? ViewModelFactory { get; }

	public ViewModelBase(IEventAggregator? eventAggregator = null, IViewModelFactory? viewModelFactory = null)
	{
		EventAggregator = eventAggregator;
		ViewModelFactory = viewModelFactory;
	}


	#region  INotifyPropertyChanged

	public event PropertyChangedEventHandler? PropertyChanged;

	//protected void NotifyPropertyChanged<T>(Expression<Func<T>> propertyExpression)
	//	=> NotifyPropertyChanged((propertyExpression.Body as MemberExpression)?.Member?.Name ?? string.Empty);

	//protected void NotifyPropertyChanged(string name)
	//	=> PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

	//protected void NotifyPropertyChanged()
	//	=> PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(string.Empty));

	protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}

	protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = "")
	{
		if (EqualityComparer<T>.Default.Equals(storage, value))
		{
			return false;
		}
		storage = value;
		this.OnPropertyChanged(propertyName);
		return true;
	}

	#endregion
}
