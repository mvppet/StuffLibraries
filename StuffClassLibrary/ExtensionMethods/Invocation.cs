using System.ComponentModel;

namespace StuffClassLibrary.ExtensionMethods;
public static class Invocation
{
	public delegate void InvokeIfRequiredDelegate<T>(T obj)
		where T : ISynchronizeInvoke;

	public static void InvokeIfRequired<T>(this T obj, InvokeIfRequiredDelegate<T> action)
		where T : ISynchronizeInvoke
	{
		if (obj.InvokeRequired)
		{
			obj.Invoke(action, [obj]);
		}
		else
		{
			action(obj);
		}
	}

}
