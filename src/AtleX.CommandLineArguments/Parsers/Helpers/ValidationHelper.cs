using System;
using System.Collections.Generic;
using System.Reflection;
using AtleX.CommandLineArguments.Validators;

namespace AtleX.CommandLineArguments.Parsers.Helpers
{
  /// <summary>
  /// 
  /// </summary>
  internal sealed class ValidationHelper
  {
    /// <summary>
    /// Gets the <see cref="IEnumerable{T}"/> of <see cref="ArgumentValidator"/> to validate the arguments with
    /// </summary>
    private readonly IEnumerable<ArgumentValidator> argumentValidators;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="validatorsToRun"></param>
    public ValidationHelper(IEnumerable<ArgumentValidator> validatorsToRun)
    {
      this.argumentValidators = validatorsToRun ?? throw new ArgumentNullException(nameof(validatorsToRun));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="parsedPropertyToValidate"></param>
    /// <param name="isSpecified"></param>
    /// <param name="originalValue"></param>
    /// <returns></returns>
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
