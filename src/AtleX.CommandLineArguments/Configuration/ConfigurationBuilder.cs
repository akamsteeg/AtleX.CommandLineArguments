using System;
using AtleX.CommandLineArguments.Help;
using AtleX.CommandLineArguments.Parsers;
using AtleX.CommandLineArguments.Parsers.TypeParsers;
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
    /// Create a <see cref="ConfigurationBuilder"/> with the specified <see cref="ICommandLineArgumentsParser"/>
    /// </summary>
    /// <param name="parser">
    /// The <see cref="ICommandLineArgumentsParser"/> to use
    /// </param>
    /// <returns>
    /// The <see cref="ConfigurationBuilder"/> for the specified <see cref="ICommandLineArgumentsParser"/>
    /// </returns>
    public static ConfigurationBuilder For(ICommandLineArgumentsParser parser)
    {
      var result = new ConfigurationBuilder(parser);
      return result;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="ConfigurationBuilder"/> with the
    /// specified <see cref="ICommandLineArgumentsParser"/>
    /// </summary>
    /// <param name="parser">
    /// The <see cref="ICommandLineArgumentsParser"/> to use
    /// </param>
    private ConfigurationBuilder(ICommandLineArgumentsParser parser)
    {
      this.Parser = parser ?? throw new ArgumentNullException(nameof(parser));
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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="typeParser"></param>
    /// <returns></returns>
    public ConfigurationBuilder With(TypeParser typeParser)
    {
      if (typeParser == null)
        throw new ArgumentNullException(nameof(typeParser));

      this.TypeParsers.Add(typeParser);

      return this;
    }

    /// <summary>
    /// Set the <see cref="HelpWriter"/> for the <see cref="ConfigurationBuilder"/>
    /// </summary>
    /// <param name="helpWriter">
    /// The <see cref="HelpWriter"/> to set
    /// </param>
    /// <returns>
    /// The <see cref="ConfigurationBuilder"/>
    /// </returns>
    public ConfigurationBuilder With(HelpWriter helpWriter)
    {
      this.HelpWriter = helpWriter ?? throw new ArgumentNullException(nameof(helpWriter));

      return this;
    }
  }
}
