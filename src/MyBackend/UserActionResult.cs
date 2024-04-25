namespace MyBackend;

public record UserActionResult
{
    public bool ActionSkipped { get; init; }
    public bool ClearEvents { get; init; }

    /// <summary>
    /// The action did not apply so nothing was done
    /// </summary>
    public static UserActionResult NoAction => new() { ActionSkipped = true };

    /// <summary>
    /// The action was engaged and a new render is required
    /// </summary>
    public static UserActionResult ActionApplied => new();

    /// <summary>
    /// The action was engaged and a new render is required,
    /// and this action accounts for all previous actions so
    /// after it executes the list of actions can be cleared.
    /// </summary>
    public static UserActionResult FinalActionApplied => new() { ClearEvents = true };
}