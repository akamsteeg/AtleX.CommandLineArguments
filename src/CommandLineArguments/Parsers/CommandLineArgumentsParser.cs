namespace AtleX.CommandLineArguments.Parsers
{
  public abstract class CommandLineArgumentsParser
  {
    /// <summary>
    /// Initializes a new instance of <see cref="CommandLineArgumentsParser"/>
    /// </summary>
    public CommandLineArgumentsParser()
    {

    }

    /// <summary>
    /// Parse the specified arguments to <see cref="{T}"/>
    /// </summary>
    /// <typeparam name="T">
    /// The <see cref="Arguments"/> to parse to
    /// </typeparam>
    /// <param name="arguments">
    /// The arguments to parse
    /// </param>
    /// <returns>
    /// The arguments, parsed to <see cref="{T}"/>
    /// </returns>
    public abstract T Parse<T>(object[] arguments)
      where T : Arguments, new();
  }
}
