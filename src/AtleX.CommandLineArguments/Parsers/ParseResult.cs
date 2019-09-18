using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
    /// Gets the <see cref="IEnumerable{T}"/> of <see cref="ValidationError"/> with all the validation errors
    /// </summary>
    public IEnumerable<ValidationError> ValidationErrors
    {
      get;
    }

    /// <summary>
    /// Gets whether the arguments passed validation
    /// </summary>
    public bool IsValid
    {
      get;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="ParseResult{T}"/> for the
    /// specified arguments object with the specified <see
    /// cref="IEnumerable{T}"/> of <see cref="ValidationError"/>
    /// </summary>
    /// <param name="commandLineArguments">
    /// The arguments object this <see cref="ParseResult{T}"/> is for
    /// </param>
    /// <param name="validationErrors">
    /// The <see cref="IEnumerable{T}"/> of <see cref="ValidationError"/> with all the validation errors
    /// </param>
    public ParseResult(T commandLineArguments, IEnumerable<ValidationError> validationErrors)
    {
      this.CommandLineArguments = commandLineArguments ?? throw new ArgumentNullException(nameof(commandLineArguments));
      this.ValidationErrors = validationErrors ?? throw new ArgumentNullException(nameof(validationErrors));
      this.IsValid = !validationErrors.Any();
    }
  }
}
