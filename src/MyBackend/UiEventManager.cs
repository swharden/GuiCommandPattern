namespace MyBackend;

public class UiEventManager(Plot plot)
{
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

    public void Add(string name, double x, double y, bool process = true)
    {
        UiEvent uiEvent = new(name, x, y);
        Add(uiEvent, process);
    }

    /// <summary>
    /// Evaluate possible responses in order and apply
    /// them to the plot if they are a match.
    /// </summary>
    private void ProcessEvents()
    {
        foreach (IUiResponse response in Responses)
        {
            if (response.WillExecute(Events, Plot))
                response.Execute(Events, Plot);
        }
    }
}
