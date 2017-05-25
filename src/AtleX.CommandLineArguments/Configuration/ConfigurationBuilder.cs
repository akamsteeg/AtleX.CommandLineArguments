using System;
using AtleX.CommandLineArguments.Parsers;

namespace AtleX.CommandLineArguments.Configuration
{
  /// <summary>
  /// Represents a builder for <see cref="CommandLineArgumentsConfiguration"/>
  /// </summary>
  public class ConfigurationBuilder
    : CommandLineArgumentsConfiguration
  {
    /// <summary>
    /// Create a <see cref="ConfigurationBuilder"/> with the specified <see cref="CommandLineArgumentsParser"/>
    /// </summary>
    /// <param name="parser">
    /// The <see cref="CommandLineArgumentsParser"/> to use
    /// </param>
    /// <returns>
    /// The <see cref="ConfigurationBuilder"/> for the specified <see cref="CommandLineArgumentsParser"/>
    /// </returns>
    public static ConfigurationBuilder For(CommandLineArgumentsParser parser)
    {
      var result = new ConfigurationBuilder(parser);
      return result;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="ConfigurationBuilder"/> with the
    /// specified <see cref="CommandLineArgumentsParser"/>
    /// </summary>
    /// <param name="parser">
    /// The <see cref="CommandLineArgumentsParser"/> to use
    /// </param>
    private ConfigurationBuilder(CommandLineArgumentsParser parser)
      : base(parser)
    {
    }
  }
}
