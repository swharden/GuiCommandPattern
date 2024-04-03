
namespace MyBackend.StandardUiResponses;

public class LeftClickDragPan : IUiResponse
{
    public bool WillExecute(List<UiEvent> uiEvents, Plot plot)
    {
        bool hasMouseDown = uiEvents.First().Name == "left button down";
        bool hasMouseUp = uiEvents.Last().Name == "left button up";
        bool isDragAndDrop = hasMouseDown && hasMouseUp;
        if (!isDragAndDrop)
            return false;

        double dragX = uiEvents.Last().X - uiEvents.First().X;
        double dragY = uiEvents.Last().X - uiEvents.First().X;
        double drag = Math.Sqrt(dragX * dragX + dragY * dragY);
        if (drag == 0)
            return false;

        return true;
    }

    public void Execute(List<UiEvent> uiEvents, Plot plot)
    {
        double dragX = uiEvents.Last().X - uiEvents.First().X;
        double dragY = uiEvents.Last().X - uiEvents.First().X;
        plot.Pan(dragX, dragY);
        uiEvents.Clear();
    }
}
