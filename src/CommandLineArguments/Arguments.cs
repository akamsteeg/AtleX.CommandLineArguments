namespace AtleX.CommandLineArguments
{
  public abstract class Arguments
  {
    /// <summary>
    /// Gets whether the arguments are valid or not
    /// </summary>
    public abstract bool AreValid
    {
      get;
      protected set;
    }
  }
}
