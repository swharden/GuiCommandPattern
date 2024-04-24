using ScottPlot;

namespace MyBackend;

public class UiEventManager(Plot plot, float controlWidth, float controlHeight)
{
    public float ControlWidth { get; set; } = controlWidth;
    public float ControlHeight { get; set; } = controlHeight;

    /// <summary>
    /// A growing list of UI inputs.
    /// The list is cleared when action is taken.
    /// </summary>
    public List<UiEvent> Events { get; } = [];
    public int UnprocessedEventCount => Events.Count;

    public EventHandler<UiEvent> EventAdded { get; set; } = delegate { };
    public EventHandler<IUiAction> ActionExecuted { get; set; } = delegate { };

    /// <summary>
    /// The plot which will be modified by responses
    /// </summary>
    private Plot Plot { get; } = plot;

    /// <summary>
    /// Rules for how to respond to UI events in the order they will be applied.
    /// </summary>
    public List<IUiAction> UiActions { get; } =
    [
        new UiActions.LeftClickDragPan(),
        new UiActions.RightClickDragPan(),
        new UiActions.ScrollWheelZoom(),
        new UiActions.SingleLeftClick(),
    ];

    public void Add(UiEvent uiEvent)
    {
        Events.Add(uiEvent);
        EventAdded.Invoke(this, uiEvent);
        ProcessEvents();
    }

    public void AddCustom(string name, double x, double y)
    {
        UiEvent uiEvent = new(name, x, y);
        Add(uiEvent);
    }

    public void AddLeftDown(double x, double y)
    {
        AddCustom("left button down", x, y);
        WatchMouseMoves = true;
        LastMouseX = x;
        LastMouseY = y;
        OriginalLimits = Plot.Axes.GetLimits();
    }

    public void AddRightDown(double x, double y)
    {
        AddCustom("right button down", x, y);
        WatchMouseMoves = true;
        LastMouseX = x;
        LastMouseY = y;
        OriginalLimits = Plot.Axes.GetLimits();
    }

    public void AddLeftUp(double x, double y)
    {
        AddCustom("left button up", x, y);
        WatchMouseMoves = false;
    }

    public void AddRightUp(double x, double y)
    {
        AddCustom("right button up", x, y);
        WatchMouseMoves = false;
    }

    public void AddScrollUp(double x, double y)
    {
        AddCustom("scroll wheel up", x, y);
    }

    public void AddScrollDown(double x, double y)
    {
        AddCustom("scroll wheel down", x, y);
    }

    private AxisLimits OriginalLimits;
    private double LastMouseX = double.NaN;
    private double LastMouseY = double.NaN;
    private bool WatchMouseMoves = false;

    public void AddMouseMove(double x, double y)
    {
        if (!WatchMouseMoves)
            return;

        if (x == LastMouseX && y == LastMouseY)
            return;

        AddCustom("mouse move", x, y);
        LastMouseX = x;
        LastMouseY = y;
    }

    /// <summary>
    /// Evaluate possible responses in order and apply
    /// them to the plot if they are a match.
    /// </summary>
    private void ProcessEvents()
    {
        PixelSize controlSize = new(ControlWidth, ControlHeight);
        foreach (IUiAction response in UiActions)
        {
            if (response.WillExecute(Events, Plot, controlSize, OriginalLimits))
            {
                response.Execute(Events, Plot, controlSize, OriginalLimits);
                ActionExecuted.Invoke(this, response);
                if (Events.Count == 0)
                    return;
            }
        }
    }
}
