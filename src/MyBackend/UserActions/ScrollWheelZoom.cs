namespace MyBackend.UserActions;

public class ScrollWheelZoom : IUserAction
{
    public UserActionResult Execute(UserActionInput state)
    {
        if (!state.LastEvent.Name.StartsWith("scroll wheel"))
            return UserActionResult.NoAction;

        double frac = 0.2;

        if (state.LastEvent.Name == "scroll wheel up")
        {
            state.Plot.Axes.Zoom(1 + frac, 1 + frac);
        }
        else if (state.LastEvent.Name == "scroll wheel down")
        {
            state.Plot.Axes.Zoom(1 - frac, 1 - frac);
        }

        return UserActionResult.FinalActionApplied;
    }
}
