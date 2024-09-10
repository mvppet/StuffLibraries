namespace StuffInterfaceLibrary.Events;

public interface IEventAggregator
{
	void Publish<T>(T eventItem) where T : IAggregatedEvent;
	void Publish<T>() where T : IAggregatedEvent;

	void Subscribe<T>(Action<T> callback) where T : IAggregatedEvent;
	void Subscribe<T>(Action callback) where T : IAggregatedEvent;
}