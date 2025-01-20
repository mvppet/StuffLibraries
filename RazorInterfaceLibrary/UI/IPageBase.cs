using Microsoft.AspNetCore.Components;

namespace RazorInterfaceLibrary.UI;

public interface IPageBase : IComponent, IHandleEvent, IHandleAfterRender
{
	//[Inject]
	//protected StateService? StateService { get; set; }

	//protected override void OnInitialized()
	//{
	//	base.OnInitialized();
	//}

}