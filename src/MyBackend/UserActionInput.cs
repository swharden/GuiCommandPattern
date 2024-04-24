using ScottPlot;

namespace MyBackend;

/// <summary>
/// Information about user control and plot state that 
/// actions evaluate to determine if and how to respond.
/// </summary>
public class UserActionInput
{
    public UserInputEvent[] Events { get; }
    public int EventCount => Events.Length;
    public Plot Plot { get; }
    public PixelSize ControlSize { get; }
    public AxisLimits OriginalLimits { get; }
    public PixelOffset MouseDelta { get; }
    public bool MouseMoved { get; }
    public UserInputEvent FirstEvent => Events[0];
    public UserInputEvent LastEvent => Events[^1];

    public UserActionInput(UserInputEvent[] events, Plot plot, PixelSize size, AxisLimits limits)
    {
        Events = events;
        Plot = plot;
        ControlSize = size;
        OriginalLimits = limits;

        if (Events.Length < 2)
        {
            MouseDelta = PixelOffset.Zero;
        }
        else
        {
            float dx = Events[^1].X - Events[0].X;
            float dy = Events[^1].Y - Events[0].Y;
            MouseDelta = new PixelOffset(-dx, dy);
        }

        MouseMoved = MouseDelta != PixelOffset.Zero;
    }

    public void RestoreOriginalAxisLimits()
    {
        Plot.Axes.SetLimits(OriginalLimits);
    }
}
