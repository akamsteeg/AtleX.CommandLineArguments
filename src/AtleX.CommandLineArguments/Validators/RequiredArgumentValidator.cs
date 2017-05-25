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
    /// Initializes a new instance of <see cref="RequiredArgumentValidator"/>
    /// </summary>
    public RequiredArgumentValidator()
    {
      this.requiredAttributeType = typeof(RequiredAttribute);
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

      // When the argument is not specified or the original value is empty but the property has a [Required] attribute, fail validation
      if ((!isSpecified || string.IsNullOrWhiteSpace(originalValue)) && TryIsPropertyValueRequired(argumentPropertyInfo, out errorMessage))
      {
        isValid = false;
      }

      var result = this.CreateValidationResult(argumentPropertyInfo.Name, isValid, errorMessage);

      return result;
    }

    /// <summary>
    /// Determines whether the specified <see cref="PropertyInfo"/> has a <see
    /// cref="RequiredAttribute"/> or not
    /// </summary>
    /// <param name="propertyInfo">
    /// The <see cref="PropertyInfo"/> to check for having a <see
    /// cref="RequiredAttribute"/> or not
    /// </param>
    /// <param name="errorMessage">
    /// The error message from the <see cref="RequiredAttribute"/>, if any
    /// </param>
    /// <returns>
    /// True when the specified <see cref="PropertyInfo"/> has a <see
    /// cref="RequiredAttribute"/>, false otherwise
    /// </returns>
    private bool TryIsPropertyValueRequired(PropertyInfo propertyInfo, out string errorMessage)
    {
      var result = false;

      var requiredAttribute = propertyInfo.GetCustomAttribute(this.requiredAttributeType) as RequiredAttribute;

      if (requiredAttribute != null)
      {
        result = true;
        errorMessage = requiredAttribute.ErrorMessage;
      }
      else
      {
        errorMessage = string.Empty;
      }

      return result;
    }
  }
}
