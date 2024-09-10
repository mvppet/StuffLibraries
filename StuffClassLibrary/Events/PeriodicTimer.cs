using StuffInterfaceLibrary.Enums;
using StuffInterfaceLibrary.Events;

namespace StuffClassLibrary.Events;

public class PeriodicTimer<T> : IPeriodicTimer<T>, IDisposable where T : IAggregatedEvent
{
	private readonly IEventAggregator _eventAggregator;
	private readonly Timer _timer;
	private readonly int _millisecondsPerTick;
	private bool _disposedValue;

	public TimerTypes TimerType { get; } = TimerTypes.Periodic;
	public TimerStates TimerState { get; private set; } = TimerStates.Stopped;

	public PeriodicTimer(IEventAggregator ea, int millisecondsPerTick)
	{
		_eventAggregator = ea;
		_millisecondsPerTick = millisecondsPerTick;
		_timer = new Timer(TimerTick, null, Timeout.Infinite, Timeout.Infinite);
	}

	public IPeriodicTimer<T> Start()
	{
		_timer.Change(0, _millisecondsPerTick);
		TimerState = TimerStates.Started;
		return this;
	}

	public IPeriodicTimer<T> Stop()
	{
		_timer.Change(Timeout.Infinite, Timeout.Infinite);
		TimerState = TimerStates.Stopped;
		return this;
	}

	private void TimerTick(object? state)
	{
		_eventAggregator.Publish<T>();
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!_disposedValue)
		{
			if (disposing)
			{
				_timer.Dispose();
			}
			_disposedValue = true;
		}
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}
}
