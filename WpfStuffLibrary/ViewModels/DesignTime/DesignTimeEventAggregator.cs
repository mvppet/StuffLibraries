using StuffInterfaceLibrary.Events;

namespace WpfStuffLibrary.ViewModels.DesignTime;

internal class DesignTimeEventAggregator : IEventAggregator
{
    public void Publish<T>(T eventItem) where T : IAggregatedEvent
    {
    }

    public void Publish<T>() where T : IAggregatedEvent
    {
    }

    public void Subscribe<T>(Action<T> callback) where T : IAggregatedEvent
    {
    }

    public void Subscribe<T>(Action callback) where T : IAggregatedEvent
    {
    }
}
