namespace MyBackend;

public readonly struct UserInputEvent(string name, float x, float y)
{
    public DateTime DateTime { get; } = DateTime.Now;
    public string Name { get; } = name;
    public float X { get; } = x;
    public float Y { get; } = y;
    public override string ToString() => $"{Name} X={X} Y={Y}";
}
