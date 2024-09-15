using StuffInterfaceLibrary.Events;

namespace StuffClassLibrary.Events;

public class FolderOkEvent : IFolderOkEvent
{
	public object? Tag { get; set; }
	public string FolderName { get; set; } = string.Empty;

}
