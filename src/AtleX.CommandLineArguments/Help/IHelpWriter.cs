namespace AtleX.CommandLineArguments.Help
{
  /// <summary>
  /// Represents a help writer to display help
  /// </summary>
  public interface IHelpWriter
  {
    /// <summary>
    /// Write the help for the specified <see cref="Arguments"/> object
    /// </summary>
    /// <typeparam name="T">
    /// The type of the <see cref="Arguments"/> to write the help for
    /// </typeparam>
    /// <param name="argumentsToWriteHelpFor">
    /// The <see cref="Arguments"/> object to write the help for
    /// </param>
    void Write<T>(T argumentsToWriteHelpFor)
        where T : Arguments, new();
  }
}
