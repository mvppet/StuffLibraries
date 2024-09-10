using StuffInterfaceLibrary.Maths;

namespace StuffClassLibrary.Maths.FunctionGenerators;

public abstract class XYFunctionGeneratorBase : FunctionGeneratorBase, IXYFunctionGenerator
{
	public abstract IXYFunctionGenerator Calculate(double x);
}
