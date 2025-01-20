using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using RazorInterfaceLibrary.UI;

namespace RazorClassLibrary.UI;

public class PageBase : ComponentBase, IPageBase, IDisposable
{
	#region State Management

	[Inject]
	private ILocalStorageService? _localStorage { get; set; }

	protected async Task<T?> GetStateValueAsync<T>(string key) where T : class, new()
		=> await _localStorage!.GetItemAsync<T>(key);

	protected async Task<T?> GetStateValueAsync<T>() where T : class, new()
		=> await GetStateValueAsync<T>(typeof(T).FullName!);

	protected async Task SetStateValueAsync<T>(string key, T data)
		=> await _localStorage!.SetItemAsync(key, data);

	protected async Task SetStateValueAsync<T>(T value) where T : class, new()
		=> await SetStateValueAsync(typeof(T).FullName!, value);

	protected async Task RemoveStateValueAsync(string key)
		=> await _localStorage!.RemoveItemAsync(key);

	protected async Task ClearStateValueAsync<T>() where T : class, new()
		=> await RemoveStateValueAsync(typeof(T).FullName!);

	#endregion
	#region IDisposable
	private bool disposedValue;

	protected virtual void PageDisposed() { }

	protected virtual void Dispose(bool disposing)
	{
		if (!disposedValue)
		{
			if (disposing)
			{
				// TODO: dispose managed state (managed objects)
				PageDisposed();
			}

			// TODO: free unmanaged resources (unmanaged objects) and override finalizer
			// TODO: set large fields to null
			disposedValue = true;
		}
	}

	// // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
	// ~PageBase()
	// {
	//     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
	//     Dispose(disposing: false);
	// }

	public void Dispose()
	{
		// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	#endregion
}