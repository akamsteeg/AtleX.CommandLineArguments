namespace AtleX.CommandLineArguments.Help
{
  /// <summary>
  /// Represents a <see cref="HelpWriter"/> for Linux style command line arguments
  /// </summary>
  public sealed class LinuxStyleHelpWriter
    : PrefixedKeyConsoleHelpWriter
  {
    /// <summary>
    /// Initializes a new instance of <see cref="LinuxStyleHelpWriter"/>
    /// </summary>
    public LinuxStyleHelpWriter() 
      : base("--")
    {
    }
  }
}
