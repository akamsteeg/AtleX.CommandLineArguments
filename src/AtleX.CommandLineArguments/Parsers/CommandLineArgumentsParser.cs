using System;
using System.Collections.Generic;
using AtleX.CommandLineArguments.Parsers.Helpers;
using AtleX.CommandLineArguments.Validators;

namespace AtleX.CommandLineArguments.Parsers
{
  /// <summary>
  /// Represents a commandline arguments parser
  /// </summary>
  public abstract class CommandLineArgumentsParser
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
    /// <returns>
    /// The <see cref="ParseResult{T}"/>
    /// </returns>
    public ParseResult<T> Parse<T>(string[] arguments, IEnumerable<ArgumentValidator> validators)
      where T : Arguments, new()
    {
      if (arguments == null)
        throw new ArgumentNullException(nameof(arguments));
      if (validators == null)
        throw new ArgumentNullException(nameof(validators));

      var argumentsObject = new T();
      var allValidationResults = new List<ValidationResult>();

      var argumentPropertiesHelper = new ArgumentPropertiesHelper<T>();
      var validationHelper = new ValidationHelper(validators);

      foreach (var currentProperty in argumentPropertiesHelper.GetProperties())
      {
        var argumentIsSpecified = this.TryFindRawArgumentValue(arguments, currentProperty.Name, out string argumentValue);

        if (argumentIsSpecified)
        {
          argumentPropertiesHelper.FillProperty(argumentsObject, currentProperty.Name, argumentValue);
        }

        var currentValidationResults = validationHelper.Validate(currentProperty, argumentIsSpecified, argumentValue);

        allValidationResults.AddRange(currentValidationResults);
      }

      var result = new ParseResult<T>(argumentsObject, allValidationResults);
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
  }
}
