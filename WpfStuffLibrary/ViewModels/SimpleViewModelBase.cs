using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace WpfStuffLibrary.ViewModels;

public class SimpleViewModelBase : DependencyObject, INotifyPropertyChanged
{
	public SimpleViewModelBase()
	{
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
		=> PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

	protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = "")
	{
		if (EqualityComparer<T>.Default.Equals(storage, value))
		{
			return false;
		}
		storage = value;
		OnPropertyChanged(propertyName);
		return true;
	}

	#endregion
}
