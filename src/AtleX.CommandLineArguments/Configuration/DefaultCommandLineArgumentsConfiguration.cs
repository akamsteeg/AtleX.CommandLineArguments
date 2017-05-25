using AtleX.CommandLineArguments.Parsers;

namespace AtleX.CommandLineArguments.Configuration
{
  /// <summary>
  /// Represents the default <see cref="CommandLineArgumentsConfiguration"/>
  /// </summary>
  public sealed class DefaultCommandLineArgumentsConfiguration
    : CommandLineArgumentsConfiguration
  {
    /// <summary>
    /// Initializes a new <see cref="DefaultCommandLineArgumentsConfiguration"/>
    /// </summary>
    public DefaultCommandLineArgumentsConfiguration()
      : base(new WindowsStyleCommandLineArgumentsParser())
    {
    }
  }
}
