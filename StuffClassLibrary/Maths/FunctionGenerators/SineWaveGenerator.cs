//using StuffClassLibrary.Events;
//using StuffClassLibrary.Events.Interfaces;
using StuffInterfaceLibrary.Maths;

namespace StuffClassLibrary.Maths.FunctionGenerators;

public class SineWaveGenerator : XYFunctionGeneratorBase
{
	//private readonly IPeriodicTimer<TimerTickEvent>? _timer;
	//public SineWaveGenerator(IPeriodicTimer<TimerTickEvent> timer)
	//{
	//	_timer = timer;
	//	if (_timer.TimerState == Enums.TimerStates.Stopped)
	//	{
	//		_timer.Start();
	//	}
	//}

	public double Amplitude { get; set; }
	public double Frequency { get; set; }

	public SineWaveGenerator(double amplitude, double frequency)
	{
		Amplitude = amplitude;
		Frequency = frequency;
	}

	public override IXYFunctionGenerator Calculate(double x)
	{
		Value = Amplitude * Math.Sin(x);
		return this;
	}
}
