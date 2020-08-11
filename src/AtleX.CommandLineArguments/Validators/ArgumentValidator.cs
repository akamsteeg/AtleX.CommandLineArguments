using System;
using System.Reflection;

namespace AtleX.CommandLineArguments.Validators
{
  /// <summary>
  /// Represents a validator for command line arguments
  /// </summary>
  public abstract class ArgumentValidator
    : IArgumentValidator
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

    /// <inheritdoc />
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
