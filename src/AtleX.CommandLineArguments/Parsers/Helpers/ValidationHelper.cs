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
    /// Try validating the argument with all argument validators
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
    /// <param name="validationErrors">
    /// When validation fails, the value is an <see cref="IEnumerable{T}"/> of
    /// <see cref="ValidationError"/> with all validation errors. Otherwise, the
    /// value is an empty <see cref="IEnumerable{T}"/> of <see cref="ValidationError"/>
    /// </param>
    /// <returns>
    /// True when the argument is valid, false otherwise
    /// </returns>
    public bool TryValidate(PropertyInfo parsedPropertyToValidate, bool isSpecified, string originalValue, out IEnumerable<ValidationError> validationErrors)
    {
      _ = parsedPropertyToValidate ?? throw new ArgumentNullException(nameof(parsedPropertyToValidate));

      var result = true;

      var currentValidationErrors =  new List<ValidationError>();

      foreach (var currentValidator in this.argumentValidators)
      {
        var isValid = currentValidator.TryValidate(parsedPropertyToValidate, isSpecified, originalValue, out ValidationError validationError);

        if (!isValid)
        {
          currentValidationErrors.Add(validationError);
          result = false;
        }
      }

      validationErrors = currentValidationErrors;

      return result;
    }
  }
}
