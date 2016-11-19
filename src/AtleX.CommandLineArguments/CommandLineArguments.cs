using AtleX.CommandLineArguments.Configuration;
using System;

namespace AtleX.CommandLineArguments
{
  /// <summary>
  /// Represents a parser for commandline arguments
  /// </summary>
  public static class CommandLineArguments
  {
    /// <summary>
    /// Gets or sets the <see cref="CommandLineArgumentsConfiguration"/> foor this <see cref="CommandLineArguments"/>
    /// </summary>
    public static CommandLineArgumentsConfiguration Configuration
    {
      get;
      set;
    }

    /// <summary>
    /// Initializes <see cref="CommandLineArguments"/>
    /// </summary>
    static CommandLineArguments()
    {
      Configuration = new DefaultCommandLineArgumentsConfiguration();
    }

    /// <summary>
    /// Parse the specified arguments to the specified type
    /// </summary>
    /// <typeparam name="T">
    /// The <see cref="Arguments"/> to parse to
    /// </typeparam>
    /// <param name="arguments">
    /// The arguments to parse
    /// </param>
    /// <returns>
    /// The arguments, parsed to the specified type
    /// </returns>
    public static T Parse<T>(object[] arguments)
      where T : Arguments, new()
    {
      if (arguments == null)
        throw new ArgumentNullException(nameof(arguments));
      if (Configuration == null)
        throw new InvalidOperationException("Cannot parse without a configuration");
      if (Configuration.Parser == null)
        throw new InvalidOperationException("Cannot parse without a parser");

      var result = Configuration.Parser.Parse<T>(arguments);

      return result;
    }
  }
}
