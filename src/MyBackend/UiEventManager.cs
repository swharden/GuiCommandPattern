namespace MyBackend;

public class UiEventManager(Plot plot)
{
    public ControlInfo ControlInfo { get; set; } = new(600, 400);

    /// <summary>
    /// A growing list of UI inputs.
    /// The list is cleared when action is taken.
    /// </summary>
    public List<UiEvent> Events { get; } = [];

    /// <summary>
    /// A list of rules for how to respond to UI events,
    /// in the order they will be applied.
    /// </summary>
    public List<IUiResponse> Responses { get; } =
    [
        new StandardUiResponses.LeftClickDragPan(),
        new StandardUiResponses.RightClickDragPan(),
    ];

    /// <summary>
    /// The plot which will be modified by responses
    /// </summary>
    private Plot Plot { get; } = plot;

    public void Add(UiEvent uiEvent, bool process = true)
    {
        Events.Add(uiEvent);

        if (process)
            ProcessEvents();
    }

    public void AddCustom(string name, double x, double y, bool process = true)
    {
        UiEvent uiEvent = new(name, x, y);
        Add(uiEvent, process);
    }

    public void AddLeftDown(double x, double y)
    {
        AddCustom("left button down", x, y);
    }

    public void AddRightDown(double x, double y)
    {
        AddCustom("right button down", x, y);
    }

    public void AddLeftUp(double x, double y)
    {
        AddCustom("left button up", x, y);
    }

    public void AddRightUp(double x, double y)
    {
        AddCustom("right button up", x, y);
    }

    public void AddMouseMove(double x, double y)
    {
        AddCustom("mouse move", x, y);
    }

    /// <summary>
    /// Evaluate possible responses in order and apply
    /// them to the plot if they are a match.
    /// </summary>
    private void ProcessEvents()
    {
        foreach (IUiResponse response in Responses)
        {
            if (response.WillExecute(Events, Plot, ControlInfo))
                response.Execute(Events, Plot, ControlInfo);
        }
    }
}
