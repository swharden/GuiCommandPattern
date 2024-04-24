namespace MyBackend.UserActions;

public class RightClickDragZoom : IUserAction
{
    public UserActionResult Execute(UserActionInput state)
    {
        bool willExecute = (state.Events.Length >= 2)
            && state.FirstEvent.Name == "right button down"
            && state.MouseMoved;

        if (!willExecute)
            return UserActionResult.NoAction;

        float dataSizePx = state.MouseDelta.X > state.MouseDelta.Y 
            ? state.ControlSize.Width 
            : state.ControlSize.Height;

        float maxDelta = Math.Max(state.MouseDelta.X, state.MouseDelta.Y);
        double deltaFracX = maxDelta / (Math.Abs(maxDelta) + dataSizePx);
        double frac = Math.Pow(10, deltaFracX);

        state.RestoreOriginalAxisLimits();
        state.Plot.Axes.Zoom(frac, frac);

        bool dragFinished = state.LastEvent.Name == "right button up";
        return dragFinished
            ? UserActionResult.FinalActionTaken
            : UserActionResult.ActionTaken;
    }
}
