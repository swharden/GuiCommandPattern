using ScottPlot;

namespace MyBackend.UiActions;

public class SingleLeftClick : IUiAction
{
    public bool WillExecute(List<UiEvent> uiEvents, Plot plot, PixelSize controlSize, AxisLimits originalLimits)
    {
        return (uiEvents.Count == 2)
            && uiEvents.First().Name == "left button down"
            && uiEvents.Last().Name == "left button up";
    }

    public void Execute(List<UiEvent> uiEvents, Plot plot, PixelSize controlSize, AxisLimits originalLimits)
    {
        plot.Title($"{Random.Shared.NextDouble()}");
        uiEvents.Clear();
    }
}
