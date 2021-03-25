using System;
using System.Collections.Generic;
using System.Reflection;
using AtleX.CommandLineArguments.Parsers.Helpers;
using AtleX.CommandLineArguments.Parsers.TypeParsers;
using AtleX.CommandLineArguments.Validators;

namespace AtleX.CommandLineArguments.Parsers
{
  /// <summary>
  /// Represents a base commandline arguments parser with reflection
  /// </summary>
  public abstract class CommandLineArgumentsParser
    : ICommandLineArgumentsParser
  {
    /// <summary>
    /// Initializes a new instance of <see cref="CommandLineArgumentsParser"/>
    /// </summary>
    public CommandLineArgumentsParser()
    {

    }

    /// <inheritdoc />
    public virtual ParseResult<T> Parse<T>(string[] arguments, IEnumerable<IArgumentValidator> validators, IEnumerable<ITypeParser> typeParsers)
      where T : Arguments, new()
    {
      _ = arguments ?? throw new ArgumentNullException(nameof(arguments));
      _ = validators ?? throw new ArgumentNullException(nameof(validators));
      _ = typeParsers ?? throw new ArgumentNullException(nameof(typeParsers));

      var argumentsObject = new T();
      var allValidationErrors = new List<ValidationError>();

      var properties = typeof(T).GetTypeInfo().GetRuntimeProperties();

      foreach (var currentProperty in properties)
      {
        var argumentIsSpecified = this.TryFindRawArgumentValue(arguments, currentProperty.Name, out var argumentValue);

        if (argumentIsSpecified)
        {
          ArgumentPropertiesHelper.FillProperty(argumentsObject, currentProperty, argumentValue, typeParsers);
        }

        var isValid = ValidationHelper.TryValidate(
          validators,
          currentProperty,
          argumentIsSpecified,
          argumentValue,
          out var validationErrors);

        if (!isValid)
        {
          allValidationErrors.AddRange(validationErrors);
        }
      }

      argumentsObject.IsHelpRequested = this.ContainsHelpArgument(arguments);

      var result = new ParseResult<T>(argumentsObject, allValidationErrors);
      return result;
    }

    /// <summary>
    /// Try to find an argument with the specified name in the specified
    /// collection of all command line arguments
    /// </summary>
    /// <param name="allCommandLineArguments">
    /// The collection of all command line arguments
    /// </param>
    /// <param name="argumentToFind">
    /// The name of the argument to find
    /// </param>
    /// <param name="value">
    /// The value of the argument, if found
    /// </param>
    /// <returns>
    /// True when the argument with the specified name to find is found, false otherwise
    /// </returns>
    protected abstract bool TryFindRawArgumentValue(string[] allCommandLineArguments, string argumentToFind, out string value);

    /// <summary>
    /// Gets whether the specified command line arguments contain a Help argument or not
    /// </summary>
    /// <param name="allCommandLineArguments">
    /// The collection of all command line arguments
    /// </param>
    /// <returns>
    /// True when the collection of command line arguments contains a Help argument, false otherwise
    /// </returns>
    protected abstract bool ContainsHelpArgument(string[] allCommandLineArguments);
  }
}
