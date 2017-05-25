namespace AtleX.CommandLineArguments.Help
{
  /// <summary>
  /// Represents a <see cref="HelpWriter"/> for Windows style command line arguments
  /// </summary>
  public sealed class WindowsStyleHelpWriter
    : ConsoleHelpWriter
  {
    /// <summary>
    /// The character indicating a key
    /// </summary>
    private const string keyIndicatorCharacter = "/";

    /// <summary>
    /// Gets the exact name of an argument how it should be used on the command
    /// line, including prefixes
    /// </summary>
    /// <param name="argumentName">
    /// The name of the argument to get the exact commandline usage for
    /// </param>
    /// <returns>
    /// The exact name of an argument how it should be used on the command line,
    /// including prefixes
    /// </returns>
    protected override string GetExactCommandlineNameOfArgument(string argumentName)
    {
      var result = keyIndicatorCharacter + argumentName;
      return result;
    }
  }
}
