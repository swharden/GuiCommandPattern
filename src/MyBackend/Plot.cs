using System.Diagnostics.Contracts;

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

    public double CenterX => (Left + Right) / 2;
    public double CenterY => (Bottom + Top) / 2;
    public double Width => Right - Left;
    public double Height => Top - Bottom;

    public override string ToString() => $"X=[{Left}, {Right}] Y=[{Bottom}, {Top}]";

    public void Pan(double x, double y)
    {
        Left += x;
        Right += x;
        Bottom += y;
        Top += y;
    }

    public void Zoom(double xFrac, double yFrac)
    {
        double centerX = CenterX;
        double halfWidth = Width / 2;
        Left = centerX - halfWidth * xFrac;
        Right = centerX + halfWidth * xFrac;

        double centerY = CenterY;
        double halfHeight = Height / 2;
        Bottom = centerY - halfHeight * yFrac;
        Top = centerY + halfHeight * yFrac;
    }

    public Plot Clone()
    {
        return new Plot()
        {
            Left = Left,
            Right = Right,
            Bottom = Bottom,
            Top = Top,
        };
    }
}
