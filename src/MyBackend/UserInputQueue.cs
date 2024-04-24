using ScottPlot;

namespace MyBackend;

public class UserInputQueue(Plot plot, float controlWidth, float controlHeight)
{
    public float ControlWidth { get; set; } = controlWidth;
    public float ControlHeight { get; set; } = controlHeight;
    PixelSize ControlSize => new(ControlWidth, ControlHeight);

    /// <summary>
    /// A growing list of UI inputs.
    /// The list is cleared when action is taken.
    /// </summary>
    public List<UserInputEvent> Events { get; } = [];
    public int UnprocessedEventCount => Events.Count;

    public EventHandler<UserInputEvent> EventAdded { get; set; } = delegate { };
    public EventHandler<(IUserAction action, UserActionResult result)> ActionExecuted { get; set; } = delegate { };

    /// <summary>
    /// The plot which will be modified by responses
    /// </summary>
    private Plot Plot { get; } = plot;

    /// <summary>
    /// Rules for how to respond to UI events in the order they will be applied.
    /// </summary>
    public List<IUserAction> UserActions { get; } =
    [
        new UserActions.LeftClickDragPan(),
        new UserActions.RightClickDragZoom(),
        new UserActions.ScrollWheelZoom(),
        new UserActions.SingleLeftClick(),
    ];

    public void Add(UserInputEvent uiEvent)
    {
        Events.Add(uiEvent);
        EventAdded.Invoke(this, uiEvent);
        ProcessEvents();
    }

    public void AddCustom(string name, float x, float y)
    {
        UserInputEvent uiEvent = new(name, x, y);
        Add(uiEvent);
    }

    public void AddLeftDown(float x, float y)
    {
        AddCustom("left button down", x, y);
        WatchMouseMoves = true;
        LastMouseX = x;
        LastMouseY = y;
        OriginalLimits = Plot.Axes.GetLimits();
    }

    public void AddRightDown(float x, float y)
    {
        AddCustom("right button down", x, y);
        WatchMouseMoves = true;
        LastMouseX = x;
        LastMouseY = y;
        OriginalLimits = Plot.Axes.GetLimits();
    }

    public void AddLeftUp(float x, float y)
    {
        AddCustom("left button up", x, y);
        WatchMouseMoves = false;
    }

    public void AddRightUp(float x, float y)
    {
        AddCustom("right button up", x, y);
        WatchMouseMoves = false;
    }

    public void AddScrollUp(float x, float y)
    {
        AddCustom("scroll wheel up", x, y);
    }

    public void AddScrollDown(float x, float y)
    {
        AddCustom("scroll wheel down", x, y);
    }

    private AxisLimits OriginalLimits;
    private double LastMouseX = double.NaN;
    private double LastMouseY = double.NaN;
    private bool WatchMouseMoves = false;

    public void AddMouseMove(float x, float y)
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
        UserActionInput input = new([.. Events], Plot, ControlSize, OriginalLimits);

        foreach (IUserAction action in UserActions)
        {
            UserActionResult result = action.Execute(input);

            if (result == UserActionResult.NoAction)
            {
                continue;
            }
            else if (result == UserActionResult.ActionTaken)
            {
                ActionExecuted.Invoke(this, (action, result));
            }
            else if (result == UserActionResult.FinalActionTaken)
            {
                Events.Clear();
                ActionExecuted.Invoke(this, (action, result));
                return;
            }
        }
    }
}
