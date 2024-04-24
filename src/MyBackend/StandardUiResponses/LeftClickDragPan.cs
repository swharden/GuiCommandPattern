namespace MyBackend.StandardUiResponses;

public class LeftClickDragPan : IUiResponse
{
    public bool WillExecute(List<UiEvent> uiEvents, ScottPlot.Plot plot, ControlInfo control)
    {
        bool hasMouseDown = uiEvents.First().Name == "left button down";
        bool hasMouseUp = uiEvents.Last().Name == "left button up";
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
        double dragY = uiEvents.Last().Y - uiEvents.First().Y;

        ScottPlot.PixelOffset offset = new(-(float)dragX, (float)dragY);
        plot.Axes.Pan(offset);

        uiEvents.Clear();
    }
}
