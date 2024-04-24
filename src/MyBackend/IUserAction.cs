namespace MyBackend;

/// <summary>
/// Actions contains logic that determines when and how to perform an action
/// </summary>
public interface IUserAction
{
    public UserActionResult Execute(UserActionInput state);
}
