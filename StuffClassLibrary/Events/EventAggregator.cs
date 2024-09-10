using StuffInterfaceLibrary.Events;

namespace StuffClassLibrary.Events;

public class EventAggregator : IEventAggregator
{
	private readonly Dictionary<Type, List<Action<object>>> _subscribersWithState = [];
	private readonly Dictionary<Type, List<Action>> _subscribers = [];

	public void Subscribe<T>(Action<T> callback) where T : IAggregatedEvent
	{
		var eventType = typeof(T);
		if (!_subscribersWithState.ContainsKey(eventType))
		{
			_subscribersWithState[eventType] = [];
		}
		_subscribersWithState[eventType].Add(x => callback((T)x));
	}

	public void Subscribe<T>(Action callback) where T : IAggregatedEvent
	{
		var eventType = typeof(T);
		if (!_subscribers.ContainsKey(eventType))
		{
			_subscribers[eventType] = [];
		}
		_subscribers[eventType].Add(callback);
	}

	public void Publish<T>(T eventItem) where T : IAggregatedEvent
	{
		var eventType = typeof(T);
		if (_subscribersWithState.TryGetValue(eventType, out var subscribers))
		{
			foreach (var subscriber in subscribers)
			{
				subscriber(eventItem);
			}
		}
	}

	public void Publish<T>() where T : IAggregatedEvent
	{
		var eventType = typeof(T);
		if (_subscribers.TryGetValue(eventType, out var subscribers))
		{
			foreach (var subscriber in subscribers)
			{
				subscriber();
			}
		}
	}
}