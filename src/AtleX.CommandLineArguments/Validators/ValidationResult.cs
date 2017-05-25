using System;
using System.Diagnostics;

namespace AtleX.CommandLineArguments.Validators
{
  /// <summary>
  /// Represents a validation result for a single argument
  /// </summary>
  [DebuggerDisplay("Is valid: {IsValid}")]
  public sealed class ValidationResult
  {
    /// <summary>
    /// Gets the name of the command line argument
    /// </summary>
    public string ArgumentName
    {
      get;
    }

    /// <summary>
    /// Gets whether validation succeeded
    /// </summary>
    public bool IsValid
    {
      get;
    }

    /// <summary>
    /// Gets the name of the validator this <see cref="ValidationResult"/> is from
    /// </summary>
    public string ValidatorName
    {
      get;
    }

    /// <summary>
    /// Gets the validation message, if any
    /// </summary>
    public string ValidationMessage
    {
      get;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="ValidationResult"/> with the
    /// specified argument name, validation result and validation message
    /// </summary>
    /// <param name="argumentName">
    /// The name of the command line argument
    /// </param>
    /// <param name="isValid">
    /// True when the value of the argument is valid, false otherwise
    /// </param>
    /// <param name="validatorName">
    /// The name of the validator this <see cref="ValidationResult"/> is from
    /// </param>
    /// <param name="validationMessage">
    /// The validation result message, if any
    /// </param>
    public ValidationResult(string argumentName, bool isValid, string validatorName, string validationMessage)
    {
      if (string.IsNullOrWhiteSpace(argumentName))
        throw new ArgumentNullException(nameof(argumentName));
      if (string.IsNullOrWhiteSpace(validatorName))
        throw new ArgumentNullException(nameof(validatorName));

      this.ArgumentName = argumentName;
      this.IsValid = isValid;
      this.ValidatorName = validatorName;
      this.ValidationMessage = validationMessage;
    }
  }
}
