using System;

namespace AtleX.CommandLineArguments.Help
{
  /// <summary>
  /// Represents a <see cref="HelpWriter"/> that writes the help to the console
  /// </summary>
  public abstract class ConsoleHelpWriter
    : HelpWriter
  {
    /// <inheritdoc />
    public override void Write<T>(T argumentsToWriteHelpFor)
    {
      _ = argumentsToWriteHelpFor ?? throw new ArgumentNullException(nameof(argumentsToWriteHelpFor));

      var helpDetails = this.GetHelpDetails(argumentsToWriteHelpFor);

      Console.WriteLine("Usage:");
      Console.WriteLine();
      foreach (var currentHelpDetails in helpDetails)
      {
        var requiredIndicator = currentHelpDetails.IsRequired ? "(*)" : string.Empty;

        var helpTextForArgument = $" {currentHelpDetails.Argument}: {currentHelpDetails.Description} {requiredIndicator}";

        Console.WriteLine(helpTextForArgument);
      }

      Console.WriteLine();
      Console.WriteLine("*: Required arguments");
    }
  }
}
