using System.Windows.Controls;
using StuffInterfaceLibrary.Events;
using WpfStuffInterfaceLibrary.ViewModels;

namespace WpfStuffLibrary.Controls;
public class UserControlBase : UserControl
{
	protected IEventAggregator? EventAggregator { get; }
	protected IViewModelBase? ViewModelBase { get; }


}
