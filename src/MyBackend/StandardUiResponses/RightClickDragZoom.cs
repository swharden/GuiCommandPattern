namespace MyBackend.StandardUiResponses;

public class RightClickDragPan : IUiResponse
{
    public bool WillExecute(List<UiEvent> uiEvents, Plot plot, ControlInfo control)
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

    public void Execute(List<UiEvent> uiEvents, Plot plot, ControlInfo control)
    {
        double dragX = uiEvents.Last().X - uiEvents.First().X;
        double dragY = uiEvents.Last().X - uiEvents.First().X;

        double fracX = Math.Abs(dragX) / control.Width;
        double fracY = Math.Abs(dragY) / control.Height;

        if (fracX < 0)
            fracX = 1.0 / fracX;

        if (fracY < 0)
            fracY = 1.0 / fracY;

        plot.Zoom(fracX, fracY);
        uiEvents.Clear();
    }
}
