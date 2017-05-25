using System;

namespace AtleX.CommandLineArguments.Help
{
  /// <summary>
  /// Represents <see cref="HelpWriter"/> for key/value ("key1=value1 key2=value2 toggle") style command line arguments
  /// </summary>
  public class KeyValueStyleHelpWriter
    : ConsoleHelpWriter
  {
    /// <summary>
    /// Write the help for the specified <see cref="Arguments"/> object
    /// </summary>
    /// <typeparam name="T">
    /// The type of the <see cref="Arguments"/> to write the help for
    /// </typeparam>
    /// <param name="argumentsToWriteHelpFor">
    /// The <see cref="Arguments"/> object to write the help for
    /// </param>
    public override void Write<T>(T argumentsToWriteHelpFor)
    {
      if (argumentsToWriteHelpFor == null)
        throw new ArgumentNullException(nameof(argumentsToWriteHelpFor));

      var helpDetails = this.GetHelpDetails(argumentsToWriteHelpFor);

      Console.WriteLine("Usage:");
      Console.WriteLine();
      foreach (var currentHelpDetails in helpDetails)
      {
        var requiredIndicator = currentHelpDetails.IsRequired ? "*" : string.Empty;

        var helpTextForArgument = $" {currentHelpDetails.Argument}=<value>: {currentHelpDetails.Description} ({requiredIndicator})";

        Console.WriteLine(helpTextForArgument);
      }

      Console.WriteLine();
      Console.WriteLine("*: Required arguments");
    }

    /// <summary>
    /// Gets the exact name of an argument how it should be used on the command
    /// line, including prefixes
    /// </summary>
    /// <param name="argumentName">
    /// The name of the argument to get the exact commandline usage for
    /// </param>
    /// <returns>
    /// The exact name of an argument how it should be used on the command line,
    /// including prefixes
    /// </returns>
    protected override string GetExactCommandlineNameOfArgument(string argumentName)
    {
      return argumentName;
    }
  }
}
