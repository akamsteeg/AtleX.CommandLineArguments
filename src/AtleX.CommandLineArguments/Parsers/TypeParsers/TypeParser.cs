using System;

namespace AtleX.CommandLineArguments.Parsers.TypeParsers
{
  /// <summary>
  /// Represents a type parser for custom types
  /// </summary>
  public abstract class TypeParser
    : ITypeParser
  {
    /// <summary>
    /// Gets the <see cref="Type"/> this <see cref="TypeParser{T}"/> handles
    /// </summary>
    public Type Type
    {
      get;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="TypeParser"/>
    /// </summary>
    /// <param name="type">
    /// The type this <see cref="TypeParser"/> handles
    /// </param>
    public TypeParser(Type type)
    {
      this.Type = type ?? throw new ArgumentNullException(nameof(type));
    }

    /// <inheritdoc />
    public abstract bool TryParse(string value, out object parseResult);
  }
}
