namespace MyBackend.UserActions;

public class MiddleClickAutoScale : IUserAction
{
    public UserActionResult Execute(UserActionInput state)
    {
        bool willExecute = (state.EventCount >= 2)
            && state.FirstEvent.Name == "middle button down"
            && state.LastEvent.Name == "middle button up";

        if (!willExecute)
            return UserActionResult.NoAction;

        state.Plot.Axes.AutoScale();
        return UserActionResult.FinalActionApplied;
    }
}
