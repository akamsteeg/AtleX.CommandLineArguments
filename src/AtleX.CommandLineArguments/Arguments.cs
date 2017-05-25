namespace AtleX.CommandLineArguments
{
  /// <summary>
  /// Represents the commandline arguments
  /// </summary>
  public abstract class Arguments
  {
    /// <summary>
    /// Gets whether help was requested or not
    /// </summary>
    public bool IsHelpRequested
    {
      get;
      set;
    }
  }
}
