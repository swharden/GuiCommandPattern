using ScottPlot;

namespace MyBackend.UiActions;

public class RightClickDragPan : IUiAction
{
    public bool WillExecute(List<UiEvent> uiEvents, ScottPlot.Plot plot, PixelSize controlSize, AxisLimits originalLimits)
    {
        return (uiEvents.Count >= 2)
            && uiEvents[0].Name == "right button down"
            && uiEvents[1].Name == "mouse move";
    }

    public void Execute(List<UiEvent> uiEvents, ScottPlot.Plot plot, PixelSize controlSize, AxisLimits originalLimits)
    {
        double dragX = uiEvents.Last().X - uiEvents.First().X;
        double dragY = uiEvents.Last().X - uiEvents.First().X;

        double deltaPx = Math.Max(dragX, dragY);
        double dataSizePx = dragX > dragY ? controlSize.Width : controlSize.Height;

        double deltaFracX = deltaPx / (Math.Abs(deltaPx) + dataSizePx);
        double frac = Math.Pow(10, deltaFracX);

        plot.Axes.SetLimits(originalLimits);
        plot.Axes.Zoom(frac, frac);

        if (uiEvents.Last().Name == "right button up")
            uiEvents.Clear();
    }
}
