namespace MyBackend.UserActions;

public class SingleLeftClick : IUserAction
{
    public UserActionResult Execute(UserActionInput state)
    {
        bool clickHappened = (state.EventCount == 2)
            && state.FirstEvent.Name == "left button down"
            && state.LastEvent.Name == "left button up";

        if (!clickHappened)
            return UserActionResult.NoAction;

        TimeSpan clickSpan = state.LastEvent.DateTime - state.FirstEvent.DateTime;

        state.Plot.Title($"Clicked for {clickSpan.TotalMilliseconds:N0} milliseconds");
        return UserActionResult.FinalActionApplied;
    }
}
