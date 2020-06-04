using AtleX.CommandLineArguments.Configuration;
using System;
using System.Collections.Generic;
using AtleX.CommandLineArguments.Validators;

namespace AtleX.CommandLineArguments
{
  /// <summary>
  /// Represents a parser for commandline arguments
  /// </summary>
  public static class CommandLineArguments
  {
    /// <summary>
    /// The backingfield for the <see cref="Configuration"/> property
    /// </summary>
    private static CommandLineArgumentsConfiguration _configuration;

    /// <summary>
    /// Gets or set the <see cref="CommandLineArgumentsConfiguration"/> to parse with
    /// </summary>
    public static CommandLineArgumentsConfiguration Configuration
    {
      get
      {
        /*
        * We only need to create the AutoDetectConfiguration when no 
        * configuration is supplied yet by the user
        */
        return _configuration ??= new AutoDetectConfiguration();
      }
      set
      {
        ValidateConfiguration(value);

        _configuration = value;
      }
    }

    /// <summary>
    /// Parse the specified arguments to the specified type
    /// </summary>
    /// <typeparam name="T">
    /// The <see cref="Arguments"/> to parse to
    /// </typeparam>
    /// <param name="arguments">
    /// The arguments to parse
    /// </param>
    /// <param name="argumentsObject">
    /// The <see cref="Arguments"/> object to parse to
    /// </param>
    /// <returns>
    /// True when parsing and validation succeeded, false otherwise
    /// </returns>
    public static bool TryParse<T>(string[] arguments, out T argumentsObject)
      where T : Arguments, new()
    {
      var result = TryParseInternal(arguments, out argumentsObject, out _);

      return result;
    }

    /// <summary>
    /// Parse the specified arguments to the specified type
    /// </summary>
    /// <typeparam name="T">
    /// The type of <see cref="Arguments"/> to parse to
    /// </typeparam>
    /// <param name="arguments">
    /// The arguments to parse
    /// </param>
    /// <param name="argumentsObject">
    /// The <see cref="Arguments"/> object to parse to
    /// </param>
    /// <param name="validationResults">
    /// The <see cref="IEnumerable{T}"/> of <see cref="ValidationError"/> as the
    /// result of the validation
    /// </param>
    /// <returns>
    /// True when parsing and validation succeeded, false otherwise
    /// </returns>
    public static bool TryParse<T>(string[] arguments, out T argumentsObject, out IEnumerable<ValidationError> validationResults)
      where T : Arguments, new()
    {
      var result = TryParseInternal(arguments, out argumentsObject, out validationResults);

      return result;
    }

    /// <summary>
    /// Display help for the specified <see cref="Arguments"/> object
    /// </summary>
    /// <typeparam name="T">
    /// The type of <see cref="Arguments"/> to parse to
    /// </typeparam>
    /// <param name="argumentsObject">
    /// The <see cref="Arguments"/> object to display help for
    /// </param>
    public static void DisplayHelp<T>(T argumentsObject)
      where T : Arguments, new()
    {
      _ = argumentsObject ?? throw new ArgumentNullException(nameof(argumentsObject));
      ValidateConfiguration(Configuration);

      Configuration.HelpWriter.Write(argumentsObject);
    }

    /// <summary>
    /// Parse the specified arguments to the specified type
    /// </summary>
    /// <typeparam name="T">
    /// The type of <see cref="Arguments"/> to parse to
    /// </typeparam>
    /// <param name="arguments">
    /// The arguments to parse
    /// </param>
    /// <param name="argumentsObject">
    /// The <see cref="Arguments"/> object to parse to
    /// </param>
    /// <param name="validationResults">
    /// The <see cref="IEnumerable{T}"/> of <see cref="ValidationError"/> as the
    /// result of the validation
    /// </param>
    /// <returns>
    /// True when parsing and validation succeeded, false otherwise
    /// </returns>
    public static bool TryParseInternal<T>(string[] arguments, out T argumentsObject, out IEnumerable<ValidationError> validationResults)
      where T : Arguments, new()
    {
      _ = arguments ?? throw new ArgumentNullException(nameof(arguments));
      ValidateConfiguration(Configuration);

      var parseResult = Configuration.Parser.Parse<T>(arguments, Configuration.Validators, Configuration.TypeParsers);

      var result = parseResult.IsValid;
      argumentsObject = parseResult.CommandLineArguments;
      validationResults = parseResult.ValidationErrors;

      return result;
    }

    /// <summary>
    /// Validate the specified <see cref="CommandLineArgumentsConfiguration"/>
    /// </summary>
    /// <param name="configuration">
    /// The <see cref="CommandLineArgumentsConfiguration"/> to validate
    /// </param>
    private static void ValidateConfiguration(CommandLineArgumentsConfiguration configuration)
    {
      _ = configuration ?? throw new ArgumentNullException(nameof(configuration));
      _ = configuration.Parser ?? throw new InvalidOperationException("Cannot parse without a parser configured in the configuration");
      _ = configuration.HelpWriter ?? throw new InvalidOperationException("Cannot display help without a help writer configured in the configuration");
    }
  }
}
