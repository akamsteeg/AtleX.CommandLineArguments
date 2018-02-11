using System;
using System.Collections.Generic;
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

    /// <summary>
    /// Parse the specified arguments to the specified type
    /// </summary>
    /// <typeparam name="T">
    /// The <see cref="Arguments"/> to parse to
    /// </typeparam>
    /// <param name="arguments">
    /// The arguments to parse
    /// </param>
    /// <param name="validators">
    /// The <see cref="IEnumerable{T}"/> of <see cref="ArgumentValidator"/> to validate the arguments with
    /// </param>
    /// <param name="typeParsers">
    /// The <see cref="IEnumerable{T}"/> of <see cref="TypeParser"/> to parse the argument values with
    /// </param>
    /// <returns>
    /// The <see cref="ParseResult{T}"/>
    /// </returns>
    public ParseResult<T> Parse<T>(string[] arguments, IEnumerable<ArgumentValidator> validators, IEnumerable<TypeParser> typeParsers)
      where T : Arguments, new()
    {
      if (arguments == null)
        throw new ArgumentNullException(nameof(arguments));
      if (validators == null)
        throw new ArgumentNullException(nameof(validators));
      if (typeParsers == null)
        throw new ArgumentNullException(nameof(typeParsers));

      var argumentsObject = new T();
      var allValidationErrors = new List<ValidationError>();

      var argumentPropertiesHelper = new ArgumentPropertiesHelper<T>(typeParsers);
      var validationHelper = new ValidationHelper(validators);

      foreach (var currentProperty in argumentPropertiesHelper.GetProperties())
      {
        var argumentIsSpecified = this.TryFindRawArgumentValue(arguments, currentProperty.Name, out string argumentValue);

        if (argumentIsSpecified)
        {
          argumentPropertiesHelper.FillProperty(argumentsObject, currentProperty.Name, argumentValue);
        }

        var isValid = validationHelper.TryValidate(currentProperty, argumentIsSpecified, argumentValue, out IEnumerable<ValidationError> validationErrors);

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
