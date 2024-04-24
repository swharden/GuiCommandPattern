namespace MyBackend;

public readonly struct ControlInfo(float width, float height)
{
    public float Width { get; } = width;
    public float Height { get; } = height;
}
