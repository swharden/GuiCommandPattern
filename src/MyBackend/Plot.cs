namespace MyBackend;

/// <summary>
/// An example object representing a plot with axis limits
/// that can be manipulated by the user.
/// </summary>
public class Plot
{
    public double Left { get; private set; } = -10;
    public double Right { get; private set; } = 10;
    public double Bottom { get; private set; } = -10;
    public double Top { get; private set; } = 10;

    public void Pan(double x, double y)
    {
        Left += x;
        Right += x;
        Bottom += y;
        Top += y;
    }
}
