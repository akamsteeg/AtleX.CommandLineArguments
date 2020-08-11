using System;

namespace AtleX.CommandLineArguments.Help
{
  /// <summary>
  /// Represents <see cref="HelpWriter"/> for key/value ("key1=value1 key2=value2 toggle") style command line arguments
  /// </summary>
  public class KeyValueStyleHelpWriter
    : ConsoleHelpWriter
  {
    /// <inheritdoc />
    public override void Write<T>(T argumentsToWriteHelpFor)
    {
      _= argumentsToWriteHelpFor ?? throw new ArgumentNullException(nameof(argumentsToWriteHelpFor));

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

    /// <inheritdoc />
    protected override string GetExactCommandlineNameOfArgument(string argumentName)
    {
      return argumentName;
    }
  }
}
