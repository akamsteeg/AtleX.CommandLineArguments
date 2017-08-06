namespace AtleX.CommandLineArguments.Parsers.TypeParsers
{
  /// <summary>
  /// Represents a type parser for custom types
  /// </summary>
  /// <typeparam name="T">The type this <see cref="TypeParser{T}"/> handles</typeparam>
  public abstract class TypeParser<T>
    : TypeParser
  {
    /// <summary>
    /// Initializes a new instance of <see cref="TypeParser{T}"/>
    /// </summary>
    public TypeParser()
      : base(typeof(T))
    {
    }

    /// <summary>
    /// Tries to parse the specified value to the specified parse result
    /// </summary>
    /// <param name="value">
    /// The value to parse
    /// </param>
    /// <param name="parseResult">
    /// The parsed value
    /// </param>
    /// <returns>
    /// True if value was converted successfully; otherwise, false
    /// </returns>
    public override bool TryParse(string value, out object parseResult)
    {
      var result = this.TryParse(value, out T innerParseResult);

      parseResult = innerParseResult;

      return result;
    }

    /// <summary>
    /// Tries to parse the specified value to the specified parse result
    /// </summary>
    /// <param name="value">
    /// The value to parse
    /// </param>
    /// <param name="parseResult">
    /// The parsed value
    /// </param>
    /// <returns>
    /// True if value was converted successfully; otherwise, false
    /// </returns>
    public abstract bool TryParse(string value, out T parseResult);
  }
}
