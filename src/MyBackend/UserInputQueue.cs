using ScottPlot;
using System.Diagnostics;

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
        new UserActions.MiddleClickAutoScale(),
    ];

    public void Clear()
    {
        Events.Clear();
    }

    public void Remove<T>()
    {
        IUserAction[] matchingActions = UserActions.Where(x => x is T).ToArray();

        foreach (IUserAction action in matchingActions)
        {
            UserActions.Remove(action);
        }
    }

    public void Add(UserInputEvent uiEvent)
    {
        if (Events.Count == 0)
        {
            MouseStartPixel = new(uiEvent.X, uiEvent.Y);
            OriginalLimits = Plot.Axes.GetLimits();
        }

        Events.Add(uiEvent);
        EventAdded.Invoke(this, uiEvent);
        ProcessEvents();
    }

    public void Add(string name, float x, float y) => Add(new UserInputEvent(name, x, y));
    public void AddLeftDown(float x, float y) => Add("left button down", x, y);
    public void AddLeftUp(float x, float y) => Add("left button up", x, y);
    public void AddRightDown(float x, float y) => Add("right button down", x, y);
    public void AddRightUp(float x, float y) => Add("right button up", x, y);
    public void AddMiddleDown(float x, float y) => Add("middle button down", x, y);
    public void AddMiddleUp(float x, float y) => Add("middle button up", x, y);
    public void AddScrollDown(float x, float y) => Add("scroll wheel down", x, y);
    public void AddScrollUp(float x, float y) => Add("scroll wheel up", x, y);


    private AxisLimits OriginalLimits = AxisLimits.NoLimits;
    private Pixel MouseStartPixel = Pixel.NaN;
    private bool MouseMovementIsTracked => !float.IsNaN(MouseStartPixel.X);

    public void AddMouseMove(float x, float y)
    {
        if (!MouseMovementIsTracked)
            return;

        bool positionUnchangedFromLastEvent = Events.Count > 0
            && Events.Last().X == x
            && Events.Last().Y == y;

        if (positionUnchangedFromLastEvent)
            return;

        Add("mouse move", x, y);
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

            if (result.ActionSkipped)
                continue;

            if (result.ClearEvents)
            {
                Events.Clear();
                MouseStartPixel = Pixel.NaN;
                ActionExecuted.Invoke(this, (action, result));
                return;
            }

            ActionExecuted.Invoke(this, (action, result));
        }
    }
}
