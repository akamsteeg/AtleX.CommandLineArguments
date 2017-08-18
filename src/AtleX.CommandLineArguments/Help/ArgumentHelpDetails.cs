using System;
using System.Collections.Generic;
using System.Text;

namespace AtleX.CommandLineArguments.Help
{
  /// <summary>
  /// Represents the help details for an command line argument
  /// </summary>
  public class ArgumentHelpDetails
  {
    /// <summary>
    /// Gets the name of the argument as it should be used on the command line
    /// </summary>
    public string Argument
    {
      get;
    }

    /// <summary>
    /// Gets the description text of the argument
    /// </summary>
    public string Description
    {
      get;
    }

    /// <summary>
    /// Gets whether the argument is required or not
    /// </summary>
    public bool IsRequired
    {
      get;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="ArgumentHelpDetails"/> with the
    /// specified argument name, description and whether the argument is required
    /// or not
    /// </summary>
    /// <param name="argumentName">
    /// The name of the argument as it should be used on the command line
    /// </param>
    /// <param name="description">
    /// The description text of the argument
    /// </param>
    /// <param name="isRequired">
    /// True when the argument is required, false otherwise
    /// </param>
    public ArgumentHelpDetails(string argumentName, string description, bool isRequired)
    {
      if (string.IsNullOrWhiteSpace(argumentName))
        throw new ArgumentNullException(nameof(argumentName));

      this.Argument = argumentName;
      this.Description = description ?? throw new ArgumentNullException(nameof(description));
      this.IsRequired = isRequired;
    }
  }
}
