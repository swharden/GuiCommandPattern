namespace MyBackend;

public enum UserActionResult
{
    /// <summary>
    /// The action did not apply so nothing was done
    /// </summary>
    NoAction,

    /// <summary>
    /// The action was engaged and a new render is required
    /// </summary>
    ActionTaken,

    /// <summary>
    /// The action was engaged and a new render is required,
    /// and this action accounts for all previous actions so
    /// after it executes the list of actions can be cleared.
    /// </summary>
    FinalActionTaken
}