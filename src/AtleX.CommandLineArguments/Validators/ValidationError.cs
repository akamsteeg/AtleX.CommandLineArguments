using System;
using System.Diagnostics;

namespace AtleX.CommandLineArguments.Validators
{
  /// <summary>
  /// Represents a validation error for a single argument and a single <see cref="ArgumentValidator"/>
  /// </summary>
  [DebuggerDisplay("{ValidatorName}, Result: {IsValid}")]
  public sealed class ValidationError
  {
    /// <summary>
    /// Gets the name of the command line argument
    /// </summary>
    public string ArgumentName
    {
      get;
    }

    /// <summary>
    /// Gets the name of the validator this <see cref="ValidationError"/> is from
    /// </summary>
    public string ValidatorName
    {
      get;
    }

    /// <summary>
    /// Gets the validation error message, if any
    /// </summary>
    public string ErrorMessage
    {
      get;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="ValidationError"/> with the
    /// specified argument name, validation result and validation error message
    /// </summary>
    /// <param name="argumentName">
    /// The name of the command line argument
    /// </param>
    /// <param name="validatorName">
    /// The name of the validator this <see cref="ValidationError"/> is from
    /// </param>
    /// <param name="validationErrorMessage">
    /// The validation error message, if any
    /// </param>
    public ValidationError(string argumentName, string validatorName, string validationErrorMessage)
    {
      if (string.IsNullOrWhiteSpace(argumentName))
        throw new ArgumentNullException(nameof(argumentName));
      if (string.IsNullOrWhiteSpace(validatorName))
        throw new ArgumentNullException(nameof(validatorName));

      this.ArgumentName = argumentName;
      this.ValidatorName = validatorName;
      this.ErrorMessage = validationErrorMessage;
    }
  }
}
