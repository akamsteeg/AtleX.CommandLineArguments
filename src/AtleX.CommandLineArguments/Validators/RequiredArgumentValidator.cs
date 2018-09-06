using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace AtleX.CommandLineArguments.Validators
{
  /// <summary>
  /// Represents a <see cref="ArgumentValidator"/> for required command line arguments
  /// </summary>
  internal sealed class RequiredArgumentValidator
  : ArgumentValidator
  {
    /// <summary>
    /// Initializes a new instance of <see cref="RequiredArgumentValidator"/>
    /// </summary>
    public RequiredArgumentValidator()
    {
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
    public override bool TryValidate(PropertyInfo argumentPropertyInfo, bool isSpecified, string originalValue, out ValidationError validationError)
    {
      validationError = null;

      var result = true;

      var requiredAttribute = argumentPropertyInfo.GetCustomAttribute<RequiredAttribute>(inherit: false);

      if (requiredAttribute != null)
      {
        if ((!isSpecified) // The argument is required but it isn't specified
          || (isSpecified && !requiredAttribute.AllowEmptyStrings && string.IsNullOrWhiteSpace(originalValue)) // The argument is required and specified, but not allowed to be empty
          )
        {
          var errorMessage = requiredAttribute.ErrorMessage;

          validationError = this.CreateValidationError(argumentPropertyInfo.Name, errorMessage);
          result = false;
        }
      }

      return result;
    }
  }
}
