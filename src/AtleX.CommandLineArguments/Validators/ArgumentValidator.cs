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
    /// Try Validating the argument by the specified <see cref="PropertyInfo"/>
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
    /// <param name="validationError">
    /// If the validation fails, this contains the <see cref="ValidationError"/>
    /// or null otherwise
    /// </param>
    /// <returns>
    /// True when the argument is valid, false otherwise
    /// </returns>
    public abstract bool TryValidate(PropertyInfo argumentPropertyInfo, bool isSpecified, string originalValue, out ValidationError validationError);

    /// <summary>
    /// Creates a new <see cref="ValidationError"/> for the specified argument with the specified validation message
    /// </summary>
    /// <param name="argumentName">
    /// The name of the command line argument
    /// </param>
    /// <param name="validationMessage">
    /// The validation result message, if any
    /// </param>
    /// <returns>
    /// A new <see cref="ValidationError"/> with the specified values
    /// </returns>
    protected ValidationError CreateValidationError(string argumentName, string validationMessage)
    {
      var result = new ValidationError(argumentName, this.ValidatorName, validationMessage);
      return result;
    }
  }
}
