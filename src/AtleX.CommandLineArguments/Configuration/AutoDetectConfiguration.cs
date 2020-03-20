using System;
using AtleX.CommandLineArguments.Help;
using AtleX.CommandLineArguments.Parsers;

namespace AtleX.CommandLineArguments.Configuration
{
  /// <summary>
  /// Represents a <see cref="CommandLineArgumentsConfiguration"/> that
  /// autodetects the runtime platform (Windows or Unix) and configures a <see
  /// cref="CommandLineArgumentsParser"/> and <see cref="HelpWriter"/> accordingly
  /// </summary>
  public class AutoDetectConfiguration
    : CommandLineArgumentsConfiguration
  {
    /// <summary>
    /// Initializes a new instance of <see cref="AutoDetectConfiguration"/>
    /// </summary>
    public AutoDetectConfiguration()
    {
      var currentPlatform = Environment.OSVersion.Platform;

      if (currentPlatform != PlatformID.Unix && currentPlatform != PlatformID.MacOSX)
      {
        this.Parser = new WindowsStyleParser();
        this.HelpWriter = new WindowsStyleHelpWriter();
      }
      else
      {
        this.Parser = new LinuxStyleParser();
        this.HelpWriter = new LinuxStyleHelpWriter();
      }
    }
  }
}
