namespace AtleX.CommandLineArguments.Parsers
{
  /// <summary>
  /// Represents a commandline arguments parser
  /// </summary>
  public abstract class CommandLineArgumentsParser
  {
    /// <summary>
    /// Initializes a new instance of <see cref="CommandLineArgumentsParser"/>
    /// </summary>
    public CommandLineArgumentsParser()
    {

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
    public abstract T Parse<T>(object[] arguments)
      where T : Arguments, new();
  }
}
