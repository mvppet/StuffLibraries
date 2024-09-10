using System.Reflection;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using WpfStuffInterfaceLibrary.Enums;
using WpfStuffInterfaceLibrary.Windows;

namespace WpfStuffLibrary.Applications;

public class ApplicationBase : Application
{
	protected IServiceProvider ServiceProvider { get; }

	public ApplicationBase()
	{
		IServiceCollection serviceCollection = new ServiceCollection();

		AddRequiredServices(serviceCollection);
		AddApplicationServices(serviceCollection);

		ServiceProvider = serviceCollection.BuildServiceProvider();
	}

	protected virtual void AddApplicationServices(IServiceCollection services)
	{
	}

	protected void OpenMainWindows(Assembly assembly)
	{
		// get the IMain windows
		var mainWindowTypes = assembly.GetTypes()
			.Where(mytype => mytype.GetInterfaces()
				.Contains(typeof(IMainWindow)
			)
		);

		foreach (Type type in mainWindowTypes)
		{
			IMainWindow? window = (IMainWindow?)Activator.CreateInstance(type);
			window?.Show(WindowTypes.NonModal);
		}
	}

	private void AddRequiredServices(IServiceCollection services)
	{
	}
}
