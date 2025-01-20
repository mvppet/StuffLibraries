using System.Reflection;
using StuffClassLibrary.Attributes;

namespace StuffClassLibrary.ExtensionMethods;
public static class TypeLoaderExtensions
{
	public static IEnumerable<Type> GetLoadableTypes(this Assembly assembly)
	{
		ArgumentNullException.ThrowIfNull(assembly);
		try
		{
			return assembly.GetTypes();
		}
		catch (ReflectionTypeLoadException e)
		{
			return e.Types.Where(t => t != null)!;
		}
	}

	public static List<Type> GetTypesWithInterface<T>(this Assembly asm)
		=> asm.GetLoadableTypes()
				.Where(typeof(T).IsAssignableFrom)
				.ToList();
				
	public static IEnumerable<Assembly> GetAllAssemblies(this Assembly entryAssembly)
	{
		var list = new List<string>();
		var stack = new Stack<Assembly>();

		stack.Push(entryAssembly);

		do
		{
			var asm = stack.Pop();

			yield return asm;

			foreach (var reference in asm.GetReferencedAssemblies())
			{
				if (!list.Contains(reference.FullName))
				{
					try
					{
						stack.Push(Assembly.Load(reference));
					}
					catch (FileNotFoundException)
					{
						// ignore. Some system assemblies can't be loaded, for some reason.
					}

					list.Add(reference.FullName);
				}
			}
		}
		while (stack.Count > 0);
	}

	public static IEnumerable<Type> GetClassesImplementing<T>(this Assembly entryAssembly) where T : class
	{
		foreach (var assembly in GetAllAssemblies(entryAssembly))
		{
			foreach (var type in assembly.GetTypesWithInterface<T>())
			{
				if(!type.IsInterface && !type.IsAbstract)
				yield return type;
			}
		}
	}

	/// <summary>
	/// Sort a list of types by the custom Ordinal attribute
	/// </summary>
	/// <param name="types"></param>
	/// <returns></returns>
	public static List<Type> SortByOrdinal(this IEnumerable<Type> types)
		=> types.ToList()
			.Select(
				t => (
					ordinal: t.GetCustomAttribute<OrdinalAttribute>(false)?.Ordinal ?? 0,
					type: t
				)
			)
			.OrderBy(t => t.ordinal)
			.Select(t => t.type)
			.ToList();

	public static List<Assembly> RemoveAssembliesWithPrefix(this IEnumerable<Assembly> assemblies, string prefix)
		=> assemblies.Where(t => !t.FullName!.StartsWith(prefix)).ToList();

	public static List<Assembly> RemoveSystemAssemblies(this IEnumerable<Assembly> assemblies)
		=> assemblies
			.RemoveAssembliesWithPrefix(Constants.SYSTEM_NAMESPACE)
			.RemoveAssembliesWithPrefix(Constants.MICROSOFT_NAMESPACE);

}
