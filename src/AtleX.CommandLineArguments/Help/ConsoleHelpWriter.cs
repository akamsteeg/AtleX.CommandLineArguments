using System;

namespace AtleX.CommandLineArguments.Help
{
  /// <summary>
  /// Represents a <see cref="HelpWriter"/> that writes the help to the console
  /// </summary>
  public abstract class ConsoleHelpWriter
    : HelpWriter
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
