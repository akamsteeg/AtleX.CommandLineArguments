using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AtleX.CommandLineArguments.Validators;

namespace AtleX.CommandLineArguments.Parsers.Helpers
{
  /// <summary>
  /// Represents a helper for validation of command line arguments
  /// </summary>
  internal static class ValidationHelper
  {
    /// <summary>
    /// Try validating the argument with all argument validators
    /// </summary>
    /// <param name="argumentValidators">
    /// The <see cref="IEnumerable{T}"/> of <see cref="IArgumentValidator"/> to
    /// validate with
    /// </param>
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
    public static bool TryValidate(IEnumerable<IArgumentValidator> argumentValidators,
      PropertyInfo parsedPropertyToValidate,
      bool isSpecified,
      string originalValue,
      out IEnumerable<ValidationError> validationErrors)
    {
      _ = argumentValidators ?? throw new ArgumentNullException(nameof(argumentValidators));
      _ = parsedPropertyToValidate ?? throw new ArgumentNullException(nameof(parsedPropertyToValidate));

      var result = true;

      List<ValidationError> currentValidationErrors =  null; // PERF Only set the collection of validation errors when there's actually one or more

      foreach (var currentValidator in argumentValidators)
      {
        var isValid = currentValidator.TryValidate(parsedPropertyToValidate, isSpecified, originalValue, out var validationError);

        if (!isValid)
        {
          if (currentValidationErrors == null)
          {
            currentValidationErrors = new List<ValidationError>();
          }

          currentValidationErrors.Add(validationError);
          result = false;
        }
      }

      // Never return a null IEnumerable<T> because people want to use LINQ stuff on it
      validationErrors = currentValidationErrors as IEnumerable<ValidationError> ?? Enumerable.Empty<ValidationError>();

      return result;
    }
  }
}
