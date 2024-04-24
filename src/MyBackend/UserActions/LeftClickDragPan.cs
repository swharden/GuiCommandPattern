namespace MyBackend.UserActions;

public class LeftClickDragPan : IUserAction
{
    public UserActionResult Execute(UserActionInput state)
    {
        bool willExecute = (state.Events.Length >= 2)
            && state.FirstEvent.Name == "left button down"
            && state.MouseMoved;

        if (!willExecute)
            return UserActionResult.NoAction;

        state.RestoreOriginalAxisLimits();
        state.Plot.Axes.Pan(state.MouseDelta);

        bool dragFinished = state.LastEvent.Name == "left button up";
        return dragFinished
            ? UserActionResult.FinalActionTaken
            : UserActionResult.ActionTaken;
    }
}
