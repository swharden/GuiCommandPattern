namespace MyBackend;

/// <summary>
/// Contains logic that responds to UI events by acting on a Plot
/// </summary>
public interface IUiResponse
{
    public bool WillExecute(List<UiEvent> uiEvents, Plot plot, ControlInfo control);
    public void Execute(List<UiEvent> uiEvents, Plot plot, ControlInfo control);
}
