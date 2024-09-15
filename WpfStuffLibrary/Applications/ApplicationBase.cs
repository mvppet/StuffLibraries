using System.Reflection;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using WpfStuffInterfaceLibrary.Enums;
using WpfStuffInterfaceLibrary.ViewModels;
using WpfStuffInterfaceLibrary.Windows;

namespace WpfStuffLibrary.Applications;

public class ApplicationBase : Application
{
	protected IServiceProvider ServiceProvider { get; }
	protected Assembly Assembly { get; }

	public ApplicationBase(Assembly assembly)
	{
		Assembly = assembly;
		IServiceCollection serviceCollection = new ServiceCollection();

		AddRequiredServices(serviceCollection);
		AddApplicationServices(serviceCollection);

		ServiceProvider = serviceCollection.BuildServiceProvider();
	}

	protected virtual void AddApplicationServices(IServiceCollection services)
	{
	}

	protected override void OnStartup(StartupEventArgs e)
	{
		var vm = GetMainViewModelFromIoC();
		OpenMainWindows(vm);
	}

	private void AddRequiredServices(IServiceCollection services)
	{
	}

	private IMainViewModel? GetMainViewModelFromIoC()
		=> ServiceProvider.GetService<IMainViewModel>();

	private void OpenMainWindows(IMainViewModel? vm)
	{
		// get the IMain windows
		var mainWindowTypes = Assembly.GetTypes()
			.Where(mytype => mytype.GetInterfaces()
				.Contains(typeof(IMainWindow)
			)
		);

		foreach (Type type in mainWindowTypes)
		{
			IMainWindow? window = (IMainWindow?)Activator.CreateInstance(type);
			if (window != null)
			{
				window.ViewModel = vm;
				window.Show(WindowTypes.NonModal);
			}
		}
	}
}
