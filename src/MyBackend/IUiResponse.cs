﻿using ScottPlot;

namespace MyBackend;

/// <summary>
/// Contains logic that responds to UI events by acting on a Plot
/// </summary>
public interface IUiResponse
{
    public bool WillExecute(List<UiEvent> uiEvents, ScottPlot.Plot plot, ControlInfo control, AxisLimits originalLimits);
    public void Execute(List<UiEvent> uiEvents, ScottPlot.Plot plot, ControlInfo control, AxisLimits originalLimits);
}
