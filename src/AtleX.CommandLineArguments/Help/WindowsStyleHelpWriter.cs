namespace AtleX.CommandLineArguments.Help
{
  /// <summary>
  /// Represents a <see cref="HelpWriter"/> for Windows style command line arguments
  /// </summary>
  public class WindowsStyleHelpWriter
    : PrefixedKeyConsoleHelpWriter
  {
    /// <summary>
    /// Initializes a new instance of <see cref="WindowsStyleHelpWriter"/>
    /// </summary>
    public WindowsStyleHelpWriter() 
      : base("/")
    {
    }
  }
}
