namespace StuffInterfaceLibrary.Events;

public interface IFolderOkEvent : IAggregatedEvent
{
	object? Tag { get; set; }
	string FolderName { get; set; }
}
