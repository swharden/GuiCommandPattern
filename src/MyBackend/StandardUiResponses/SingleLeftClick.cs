using ScottPlot;

namespace MyBackend.StandardUiResponses;

public class SingleLeftClick : IUiResponse
{
    public bool WillExecute(List<UiEvent> uiEvents, ScottPlot.Plot plot, ControlInfo control, AxisLimits originalLimits)
    {
        return (uiEvents.Count == 2) 
            && uiEvents.First().Name == "left button down" 
            && uiEvents.Last().Name == "left button up";
    }

    public void Execute(List<UiEvent> uiEvents, ScottPlot.Plot plot, ControlInfo control, AxisLimits originalLimits)
    {
        plot.Title($"{Random.Shared.NextDouble()}");
        uiEvents.Clear();
    }
}
