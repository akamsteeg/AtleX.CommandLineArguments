using AtleX.CommandLineArguments.Parsers.TypeParsers;
using AtleX.CommandLineArguments.Validators;
using System.Collections.Generic;

namespace AtleX.CommandLineArguments.Parsers
{
  /// <summary>
  /// Represents a commandline arguments parser
  /// </summary>
  public interface ICommandLineArgumentsParser
  {
    /// <summary>
    /// Parse the specified arguments to the specified type
    /// </summary>
    /// <typeparam name="T">
    /// The <see cref="Arguments"/> to parse to
    /// </typeparam>
    /// <param name="arguments">
    /// The arguments to parse
    /// </param>
    /// <param name="validators">
    /// The <see cref="IEnumerable{T}"/> of <see cref="IArgumentValidator"/> to validate the arguments with
    /// </param>
    /// <param name="typeParsers">
    /// The <see cref="IEnumerable{T}"/> of <see cref="ITypeParser"/> to parse the argument values with
    /// </param>
    /// <returns>
    /// The <see cref="ParseResult{T}"/>
    /// </returns>
    ParseResult<T> Parse<T>(string[] arguments, IEnumerable<IArgumentValidator> validators, IEnumerable<ITypeParser> typeParsers)
        where T : Arguments, new();
    }
}
