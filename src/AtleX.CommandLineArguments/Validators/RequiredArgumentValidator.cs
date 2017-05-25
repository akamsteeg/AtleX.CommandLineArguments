using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace AtleX.CommandLineArguments.Validators
{
  /// <summary>
  /// Represents a <see cref="ArgumentValidator"/> for required command line arguments
  /// </summary>
  public class RequiredArgumentValidator
  : ArgumentValidator
  {
    /// <summary>
    /// Gets the cached <see cref="Type"/> of <see cref="RequiredAttribute"/>
    /// </summary>
    private readonly Type requiredAttributeType;

    /// <summary>
    /// Gets the cached <see cref="Type"/> of <see cref="bool"/>
    /// </summary>
    private readonly Type booleanType;

    /// <summary>
    /// Initializes a new instance of <see cref="RequiredArgumentValidator"/>
    /// </summary>
    public RequiredArgumentValidator()
    {
      this.requiredAttributeType = typeof(RequiredAttribute);
      this.booleanType = typeof(bool);
    }

    /// <summary>
    /// Validates the argument by the specified <see cref="PropertyInfo"/>
    /// </summary>
    /// <param name="argumentPropertyInfo">
    /// The <see cref="PropertyInfo"/> of the command line argument to validate
    /// </param>
    /// <param name="isSpecified">
    /// Whether the argument is specified on the command line or not
    /// </param>    /// 
    /// <param name="originalValue">
    /// The original value, as specified on the command line
    /// </param>
    /// <returns>
    /// The <see cref="ValidationResult"/> of the validation
    /// </returns>
    public override ValidationResult Validate(PropertyInfo argumentPropertyInfo, bool isSpecified, string originalValue)
    {
      var isValid = true;
      var errorMessage = string.Empty;

      var hasRequiredAttribute = TryGetRequiredAttribute(argumentPropertyInfo, out RequiredAttribute requiredAttribute);


      if ((hasRequiredAttribute && !isSpecified) // The argument is required but it isn't specified
        || (hasRequiredAttribute && isSpecified && !requiredAttribute.AllowEmptyStrings && string.IsNullOrWhiteSpace(originalValue)) // The argument is required and specified, but not allowed to be empty
        )
      {
        errorMessage = requiredAttribute.ErrorMessage;
        isValid = false;
      }

      var result = this.CreateValidationResult(argumentPropertyInfo.Name, isValid, errorMessage);

      return result;
    }

    /// <summary>
    /// Try getting the <see cref="RequiredAttribute"/>, if any, from the
    /// specified <see cref="PropertyInfo"/>
    /// </summary>
    /// <param name="propertyInfo">
    /// The <see cref="PropertyInfo"/> to check for having a <see
    /// cref="RequiredAttribute"/> or not
    /// </param>
    /// <param name="attribute">
    /// When a <see cref="RequiredAttribute"/> is found, this contains the
    /// attribute. Null otherwise
    /// </param>
    /// <returns>
    /// True when the specified <see cref="PropertyInfo"/> has a <see
    /// cref="RequiredAttribute"/>, false otherwise
    /// </returns>
    private bool TryGetRequiredAttribute(PropertyInfo propertyInfo, out RequiredAttribute attribute)
    {
      var result = false;

      var requiredAttribute = propertyInfo.GetCustomAttribute(this.requiredAttributeType) as RequiredAttribute;

      if (requiredAttribute != null)
      {
        result = true;
        attribute = requiredAttribute;
      }
      else
      {
        attribute = null;
      }

      return result;
    }
  }
}
