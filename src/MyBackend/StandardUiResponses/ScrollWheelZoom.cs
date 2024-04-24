namespace MyBackend.StandardUiResponses;

public class ScrollWheelZoom : IUiResponse
{
    public bool WillExecute(List<UiEvent> uiEvents, ScottPlot.Plot plot, ControlInfo control)
    {
        return uiEvents.Last().Name.StartsWith("scroll wheel");
    }

    public void Execute(List<UiEvent> uiEvents, ScottPlot.Plot plot, ControlInfo control)
    {
        double frac = 0.2;

        if (uiEvents.Last().Name == "scroll wheel up")
        {
            plot.Axes.Zoom(1 + frac, 1 + frac);
        }
        else if (uiEvents.Last().Name == "scroll wheel down")
        {
            plot.Axes.Zoom(1 - frac, 1 - frac);
        }

        uiEvents.Clear();
    }
}
