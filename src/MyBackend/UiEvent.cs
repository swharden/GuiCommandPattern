namespace MyBackend;

public readonly struct UiEvent(string name, double x, double y)
{
    public string Name { get; } = name;
    public double X { get; } = x;
    public double Y { get; } = y;
    public override string ToString() => $"{Name} X={X} Y={Y}";
}
