using System;
using System.Reflection;

namespace AtleX.CommandLineArguments.Validators
{
  /// <summary>
  /// Represents a validator for command line arguments
  /// </summary>
  public abstract class ArgumentValidator
  {
    /// <summary>
    /// Gets the name of the current <see cref="ArgumentValidator"/>
    /// </summary>
    protected string ValidatorName
    {
      get;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="ArgumentValidator"/>
    /// </summary>
    public ArgumentValidator()
    {
      this.ValidatorName = this.GetType().Name;
    }

    /// <summary>
    /// Validates the argument by the specified <see cref="PropertyInfo"/>
    /// </summary>
    /// <param name="argumentPropertyInfo">
    /// The <see cref="PropertyInfo"/> of the command line argument to validate
    /// </param>
    /// <param name="isSpecified">
    /// Whether the argument is specified on the command line or not
    /// </param>
    /// <param name="originalValue">
    /// The original value, as specified on the command line
    /// </param>
    /// <returns>
    /// The <see cref="ValidationResult"/> of the validation
    /// </returns>
    public abstract ValidationResult Validate(PropertyInfo argumentPropertyInfo, bool isSpecified, string originalValue);

    /// <summary>
    /// Creates a new <see cref="ValidationResult"/> for the specified argument with the specified validity and the specified validation message
    /// </summary>
    /// <param name="argumentName">
    /// The name of the command line argument
    /// </param>
    /// <param name="isValid">
    /// True when the value of the argument is valid, false otherwise
    /// </param>
    /// <param name="validationMessage">
    /// The validation result message, if any
    /// </param>
    /// <returns>
    /// A new <see cref="ValidationResult"/> with the specified values
    /// </returns>
    protected ValidationResult CreateValidationResult(string argumentName, bool isValid, string validationMessage)
    {
      var result = new ValidationResult(argumentName, isValid, this.ValidatorName, validationMessage);
      return result;
    }
  }
}
