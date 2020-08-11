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

    /// <inheritdoc />
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
