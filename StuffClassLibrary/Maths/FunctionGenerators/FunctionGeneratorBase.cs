using StuffInterfaceLibrary.Maths;

namespace StuffClassLibrary.Maths.FunctionGenerators;
public class FunctionGeneratorBase : IFunctionGenerator
{
	public double Value { get; protected set; }
}
