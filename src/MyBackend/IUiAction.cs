using ScottPlot;

namespace MyBackend;

/// <summary>
/// Contains logic that responds to UI events by acting on a Plot
/// </summary>
public interface IUiAction
{
    public bool WillExecute(List<UiEvent> uiEvents, Plot plot, PixelSize controlSize, AxisLimits originalLimits);
    public void Execute(List<UiEvent> uiEvents, Plot plot, PixelSize controlSize, AxisLimits originalLimits);
}
