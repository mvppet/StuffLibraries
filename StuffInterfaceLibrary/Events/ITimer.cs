using StuffInterfaceLibrary.Enums;

namespace StuffInterfaceLibrary.Events;

public interface IPeriodicTimer<TEvent> where TEvent : IAggregatedEvent
{
	TimerStates TimerState { get; }
	TimerTypes TimerType { get; }
	IPeriodicTimer<TEvent> Start();
	IPeriodicTimer<TEvent> Stop();
}