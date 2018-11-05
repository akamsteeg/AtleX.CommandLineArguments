using System;
using System.Collections.Generic;
using AtleX.CommandLineArguments.Parsers;
using AtleX.CommandLineArguments.Parsers.TypeParsers;
using AtleX.CommandLineArguments.Validators;

namespace AtleX.CommandLineArguments.Tests.Mocks
{
  public sealed class MockParser
    : ICommandLineArgumentsParser
  {
    public ParseResult<T> Parse<T>(string[] arguments, IEnumerable<ArgumentValidator> validators, IEnumerable<ITypeParser> typeParsers) where T : Arguments, new()
    {
      throw new NotImplementedException();
    }
  }
}
