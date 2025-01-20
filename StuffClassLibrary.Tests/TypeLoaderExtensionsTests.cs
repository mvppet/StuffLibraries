using System.Reflection;
using FluentAssertions;
using StuffClassLibrary.Attributes;
using StuffClassLibrary.ExtensionMethods;

namespace StuffClassLibrary.Tests;
interface ISelectMe { }

/// <summary>
/// Test class base to check inheritance
/// </summary>
public class TypeLoaderExtensionsTestsBase
{
	[Ordinal(-2)] internal class StuffTestClass8 : ISelectMe { }
}

[Ordinal(4)] class StuffTestClass6 { }
[Ordinal(5)] class StuffTestClass7 : ISelectMe { }

public class TypeLoaderExtensionsTests : TypeLoaderExtensionsTestsBase
{
	[Ordinal(3)] public class StuffTestClass1 : ISelectMe { }
	[Ordinal(2)] class StuffTestClass2 { }
	[Ordinal] class StuffTestClass3 { }
	class StuffTestClass4 : ISelectMe { }
	[Ordinal(-1)] internal class StuffTestClass5 : ISelectMe { }

	[Fact]
	public void Given_ListOfTypes_When_Sorted_Then_InCorrectOrder()
	{
		// arrange
		List<Type> types = [
			typeof(StuffTestClass1),
			typeof(StuffTestClass2),
			typeof(StuffTestClass3),
			typeof(StuffTestClass4)
		];

		// act
		var sorted = types.SortByOrdinal();

		// assert
		sorted.Should().BeEquivalentTo([
			typeof(StuffTestClass4),
			typeof(StuffTestClass3),
			typeof(StuffTestClass2),
			typeof(StuffTestClass1)
		]);
	}

	[Fact]
	public void Given_EnumerableOfTypes_When_Sorted_Then_InCorrectOrder()
	{
		// arrange
		IEnumerable<Type> types = [
			typeof(StuffTestClass1),
			typeof(StuffTestClass2),
			typeof(StuffTestClass4),
			typeof(StuffTestClass4)
		];

		// act
		var sorted = types.SortByOrdinal();

		// assert
		sorted.Should().BeEquivalentTo([
			typeof(StuffTestClass4),
			typeof(StuffTestClass4),
			typeof(StuffTestClass2),
			typeof(StuffTestClass1)
		]);
	}

	[Fact]
	public void Given_CallingAssembly_When_AssemblyQueried_Then_ExpectedAssemblies()
	{
		// arrange
		var thisAssembly = Assembly.GetCallingAssembly()!;

		// act
		var allAssemblies = thisAssembly.GetAllAssemblies().RemoveSystemAssemblies().ToList();

		// assert
		allAssemblies.Select(a => a.GetName().Name)
			.Should().BeEquivalentTo([
				"xunit.execution.dotnet",
				"xunit.abstractions",
				"xunit.core"
			]);
	}


	[Fact]
	public void Given_ExecutingAssembly_When_AssemblyQueried_Then_ExpectedAssemblies()
	{
		// arrange
		var thisAssembly = Assembly.GetExecutingAssembly()!;

		// act
		var allAssemblies = thisAssembly.GetAllAssemblies().RemoveSystemAssemblies().ToList();

		// assert
		allAssemblies.Select(a => a.GetName().Name)
			.Should().BeEquivalentTo([
				"StuffClassLibrary.Tests",
				"FluentAssertions",
				"netstandard",
				"StuffClassLibrary",
				"StuffInterfaceLibrary",
				"xunit.abstractions",
				"xunit.core",
				"NuGet.Frameworks",
			]);
	}


	[Fact]
	public void Given_EntryAssembly_When_AssemblyQueried_And_SystemAssembliesStripped_Then_ExpectedAssemblies()
	{
		// arrange
		var thisAssembly = Assembly.GetEntryAssembly()!;

		// act
		var allAssemblies = thisAssembly.GetAllAssemblies().RemoveSystemAssemblies();

		// assert
		allAssemblies.Select(a => a.GetName().Name)
			.Should().BeEquivalentTo([
				"testhost",
				"netstandard",
				"NuGet.Frameworks",
				"Newtonsoft.Json"
			]);
	}

	[Fact]
	public void Given_CallingAssembly_When_TypesQueried_Then_ExpectedTypes()
	{
		// arrange
		var thisAssembly = Assembly.GetCallingAssembly()!;

		// act
		var types = thisAssembly.GetLoadableTypes();

		// assert
		types.Should().NotBeEmpty();
		types.Select(t => t.Name)
			.Where(name => name.StartsWith("StuffTestClass"))
			.Count().Should().Be(0);
	}

	[Fact]
	public void Given_ExecutingAssembly_When_TypesQueried_Then_ExpectedTypes()
	{
		// arrange
		var thisAssembly = Assembly.GetExecutingAssembly()!;

		// act
		var types = thisAssembly.GetLoadableTypes();

		// assert
		types.Select(t => t.Name)
			.Where(name => name.StartsWith("StuffTestClass"))
			.Count().Should().Be(8);


	}

	[Fact]
	public void Given_EntryAssembly_When_TypesQueried_Then_ExpectedTypes()
	{
		// arrange
		var thisAssembly = Assembly.GetEntryAssembly()!;

		// act
		var types = thisAssembly.GetLoadableTypes();

		// assert
		types.Should().NotBeEmpty();
		types.Select(t => t.Name)
			.Where(name => name.StartsWith("StuffTestClass"))
			.Count().Should().Be(0);
	}

	[Fact]
	public void Given_ExecutingAssembly_When_SearchForInterfaceImplementations_Then_ExpectedTypes()
	{
		// arrange
		var thisAssembly = Assembly.GetExecutingAssembly()!;

		// act
		var types = thisAssembly.GetClassesImplementing<ISelectMe>().SortByOrdinal();

		// assert
		types.Should().BeEquivalentTo([
			typeof(StuffTestClass8),
			typeof(StuffTestClass5),
			typeof(StuffTestClass4),
			typeof(StuffTestClass1),
			typeof(StuffTestClass7)
		]);
	}


	[Fact]
	public void Given_EntryAssembly_When_SearchForInterfaceImplementations_Then_ExpectedTypes()
	{
		// arrange
		var thisAssembly = Assembly.GetEntryAssembly()!;

		// act
		var types = thisAssembly.GetClassesImplementing<ISelectMe>().SortByOrdinal();

		// assert
		types.Should().BeEmpty();
	}

	[Fact]
	public void Given_CallingAssembly_When_SearchForInterfaceImplementations_Then_ExpectedTypes()
	{
		// arrange
		var thisAssembly = Assembly.GetCallingAssembly()!;

		// act
		var types = thisAssembly.GetClassesImplementing<ISelectMe>().SortByOrdinal();

		// assert
		types.Should().BeEmpty();
	}

}
