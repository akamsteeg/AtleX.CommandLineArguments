using System.Reflection;

namespace AtleX.CommandLineArguments.Validators
{
  /// <summary>
  /// Represents a validator for command line arguments
  /// </summary>
  public interface IArgumentValidator
  {
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
    bool TryValidate(PropertyInfo argumentPropertyInfo, bool isSpecified, string originalValue, out ValidationError validationError);
  }
}