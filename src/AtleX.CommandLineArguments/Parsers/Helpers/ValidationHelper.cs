using System;
using System.Collections.Generic;
using System.Reflection;
using AtleX.CommandLineArguments.Validators;

namespace AtleX.CommandLineArguments.Parsers.Helpers
{
  /// <summary>
  /// Represents a helper for validation of command line arguments
  /// </summary>
  internal sealed class ValidationHelper
  {
    /// <summary>
    /// Gets the <see cref="IEnumerable{T}"/> of <see cref="ArgumentValidator"/> to validate the arguments with
    /// </summary>
    private readonly IEnumerable<ArgumentValidator> argumentValidators;

    /// <summary>
    /// Initializes a new instance of <see cref="ValidationHelper"/> with the
    /// specified <see cref="IEnumerable{T}"/> of <see cref="ArgumentValidator"/>
    /// </summary>
    /// <param name="validatorsToRun">
    /// The <see cref="IEnumerable{T}"/> of <see cref="ArgumentValidator"/> to validate with
    /// </param>
    public ValidationHelper(IEnumerable<ArgumentValidator> validatorsToRun)
    {
      this.argumentValidators = validatorsToRun ?? throw new ArgumentNullException(nameof(validatorsToRun));
    }

    /// <summary>
    /// Validate the argument
    /// </summary>
    /// <param name="parsedPropertyToValidate">
    /// The <see cref="PropertyInfo"/> of the argument to validate
    /// </param>
    /// <param name="isSpecified">
    /// True when the argument was specified on the command line, false otherwise
    /// </param>
    /// <param name="originalValue">
    /// The value as originally specified on the command line, if any
    /// </param>
    /// <returns>
    /// An <see cref="IEnumerable{T}"/> of <see cref="ValidationResult"/> with
    /// all validation results
    /// </returns>
    public IEnumerable<ValidationResult> Validate(PropertyInfo parsedPropertyToValidate, bool isSpecified, string originalValue)
    {
      if (parsedPropertyToValidate == null)
        throw new ArgumentNullException(nameof(parsedPropertyToValidate));

      var result =  new List<ValidationResult>();

      foreach (var currentValidator in this.argumentValidators)
      {
        var validationResult = currentValidator.Validate(parsedPropertyToValidate, isSpecified, originalValue);

        result.Add(validationResult);
      }

      return result;
    }
  }
}
