using System;
using AtleX.CommandLineArguments.Parsers;
using AtleX.CommandLineArguments.Validators;

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

    /// <summary>
    /// Add a <see cref="ArgumentValidator"/> to the <see cref="ConfigurationBuilder"/>
    /// </summary>
    /// <param name="argumentValidator">
    /// The <see cref="ArgumentValidator"/> to add to the <see cref="ConfigurationBuilder"/>
    /// </param>
    /// <returns>
    /// The <see cref="ConfigurationBuilder"/>
    /// </returns>
    public ConfigurationBuilder With(ArgumentValidator argumentValidator)
    {
      if (argumentValidator == null)
        throw new ArgumentNullException(nameof(argumentValidator));

      this.Validators.Add(argumentValidator);

      return this;
    }
  }
}
