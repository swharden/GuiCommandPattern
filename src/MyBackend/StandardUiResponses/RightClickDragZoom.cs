namespace MyBackend.StandardUiResponses;

public class RightClickDragPan : IUiResponse
{
    public bool WillExecute(List<UiEvent> uiEvents, ScottPlot.Plot plot, ControlInfo control)
    {
        bool hasMouseDown = uiEvents.First().Name == "right button down";
        bool hasMouseUp = uiEvents.Last().Name == "right button up";
        bool isDragAndDrop = hasMouseDown && hasMouseUp;
        if (!isDragAndDrop)
            return false;

        double dragX = uiEvents.Last().X - uiEvents.First().X;
        double dragY = uiEvents.Last().X - uiEvents.First().X;
        bool moved = dragX != 0 && dragY != 0;
        return moved;
    }

    public void Execute(List<UiEvent> uiEvents, ScottPlot.Plot plot, ControlInfo control)
    {
        double dragX = uiEvents.Last().X - uiEvents.First().X;
        double dragY = uiEvents.Last().X - uiEvents.First().X;

        double deltaPx = Math.Max(dragX, dragY);
        double dataSizePx = dragX > dragY ? control.Width : control.Height;

        double deltaFracX = deltaPx / (Math.Abs(deltaPx) + dataSizePx);
        double frac = Math.Pow(10, deltaFracX);
        plot.Axes.Zoom(frac);

        uiEvents.Clear();
    }
}
