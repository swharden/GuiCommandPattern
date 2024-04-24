namespace MyBackend;

public class UiEventManager(ScottPlot.Plot plot, float controlWidth, float controlHeight)
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
    public EventHandler<IUiResponse> ActionExecuted { get; set; } = delegate { };

    /// <summary>
    /// A list of rules for how to respond to UI events,
    /// in the order they will be applied.
    /// </summary>
    public List<IUiResponse> Responses { get; } =
    [
        new StandardUiResponses.LeftClickDragPan(),
        new StandardUiResponses.RightClickDragPan(),
        new StandardUiResponses.ScrollWheelZoom(),
        new StandardUiResponses.SingleLeftClick(),
    ];

    /// <summary>
    /// The plot which will be modified by responses
    /// </summary>
    private ScottPlot.Plot Plot { get; } = plot;

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
    }

    public void AddRightDown(double x, double y)
    {
        AddCustom("right button down", x, y);
        WatchMouseMoves = true;
        LastMouseX = x;
        LastMouseY = y;
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
        ControlInfo info = new(ControlWidth, ControlHeight);
        foreach (IUiResponse response in Responses)
        {
            if (response.WillExecute(Events, Plot, info))
            {
                response.Execute(Events, Plot, info);
                ActionExecuted.Invoke(this, response);
                if (Events.Count == 0)
                    return;
            }
        }
    }
}
