namespace StuffClassLibrary.Attributes;

public class OrdinalAttribute : Attribute
{
	public int Ordinal { get; } = 0;

	public OrdinalAttribute() { }
	public OrdinalAttribute(int ordinal)
	{
		Ordinal = ordinal;
	}
}
