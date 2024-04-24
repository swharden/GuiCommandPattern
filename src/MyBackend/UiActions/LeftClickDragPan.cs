using ScottPlot;

namespace MyBackend.UiActions;

public class LeftClickDragPan : IUiAction
{
    public bool WillExecute(List<UiEvent> uiEvents, ScottPlot.Plot plot, PixelSize controlSize, AxisLimits originalLimits)
    {
        return (uiEvents.Count >= 2) 
            && uiEvents[0].Name == "left button down" 
            && uiEvents[1].Name == "mouse move";
    }

    public void Execute(List<UiEvent> uiEvents, ScottPlot.Plot plot, PixelSize controlSize, AxisLimits originalLimits)
    {
        double dragX = uiEvents.Last().X - uiEvents.First().X;
        double dragY = uiEvents.Last().Y - uiEvents.First().Y;
        ScottPlot.PixelOffset offset = new(-(float)dragX, (float)dragY);

        plot.Axes.SetLimits(originalLimits);
        plot.Axes.Pan(offset);

        if (uiEvents.Last().Name == "left button up")
            uiEvents.Clear();
    }
}
