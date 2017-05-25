using System;
using System.Collections.Generic;
using System.Diagnostics;
using AtleX.CommandLineArguments.Validators;

namespace AtleX.CommandLineArguments.Parsers
{
  /// <summary>
  /// Represents the result of parsing the command line arguments
  /// </summary>
  /// <typeparam name="T">
  /// The <see cref="Arguments"/> this <see cref="ParseResult{T}"/> is for
  /// </typeparam>
  [DebuggerDisplay("Is valid: {IsValid}")]
  public sealed class ParseResult<T>
    where T : Arguments, new()
  {
    /// <summary>
    /// Gets the <see cref="Arguments"/> this <see cref="ParseResult{T}"/> is for
    /// </summary>
    public T CommandLineArguments
    {
      get;
    }

    /// <summary>
    /// Gets the <see cref="IEnumerable{T}"/> of <see cref="ValidationResult"/> with all the validation results
    /// </summary>
    public IEnumerable<ValidationResult> ValidationResults
    {
      get;
    }

    /// <summary>
    /// Gets whether the arguments passed validation
    /// </summary>
    public bool IsValid
    {
      get
      {
        var result = true;
        foreach (var currentValidationResult in ValidationResults)
        {
          if (!currentValidationResult.IsValid)
          {
            result = false;
            break;
          }
        }

        return result;
      }
    }

    /// <summary>
    /// Initializes a new instance of <see cref="ParseResult{T}"/> for the
    /// specified arguments object with the specified <see
    /// cref="IEnumerable{T}"/> of <see cref="ValidationResult"/>
    /// </summary>
    /// <param name="commandLineArguments">
    /// The arguments object this <see cref="ParseResult{T}"/> is for
    /// </param>
    /// <param name="validationResults">
    /// The <see cref="IEnumerable{T}"/> of <see cref="ValidationResult"/> with all the validation results
    /// </param>
    public ParseResult(T commandLineArguments, IEnumerable<ValidationResult> validationResults)
    {
      this.CommandLineArguments = commandLineArguments ?? throw new ArgumentNullException(nameof(commandLineArguments));
      this.ValidationResults = validationResults ?? throw new ArgumentNullException(nameof(validationResults));
    }
  }
}
