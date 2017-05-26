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
    /// Gets or sets the <see cref="CommandLineArgumentsConfiguration"/> foor this <see cref="CommandLineArguments"/>
    /// </summary>
    public static CommandLineArgumentsConfiguration Configuration
    {
      get;
      set;
    } = CommandLineArgumentsConfiguration.Default;

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
      return TryParse(arguments, out argumentsObject, out IEnumerable<ValidationError> ignoredValidationResults);
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
      if (arguments == null)
        throw new ArgumentNullException(nameof(arguments));
      if (Configuration == null)
        throw new InvalidOperationException("Cannot parse without a configuration");
      if (Configuration.Parser == null)
        throw new InvalidOperationException("Cannot parse without a parser configured");

      var parseResult = Configuration.Parser.Parse<T>(arguments, Configuration.Validators);

      var result = parseResult.IsValid;
      argumentsObject = parseResult.CommandLineArguments as T;
      validationResults = parseResult.ValidationErrors;

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
      if (Configuration == null)
        throw new InvalidOperationException("Cannot display help without a configuration");
      if (Configuration.HelpWriter == null)
        throw new InvalidOperationException("Cannot display help without a help writer configured");

      Configuration.HelpWriter.Write(argumentsObject);
    }
  }
}
