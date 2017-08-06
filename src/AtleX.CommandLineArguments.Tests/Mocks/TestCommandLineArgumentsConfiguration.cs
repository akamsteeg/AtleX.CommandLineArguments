using AtleX.CommandLineArguments.Configuration;
using AtleX.CommandLineArguments.Parsers;
using System;
using AtleX.CommandLineArguments.Validators;
using System.Collections.Generic;
using AtleX.CommandLineArguments.Parsers.TypeParsers;

namespace AtleX.CommandLineArguments.Tests.Mocks
{
  public class TestCommandLineArgumentsConfiguration
    : CommandLineArgumentsConfiguration
  {
    public TestCommandLineArgumentsConfiguration(CommandLineArgumentsParser parser)
    {
      this.Parser = parser;
      this.Validators.Add(new RequiredArgumentValidator());
      this.TypeParsers.AddRange(new List<TypeParser>()
      {
        new BoolTypeParser(),
        new ByteTypeParser(),
        new CharTypeParser(),
        new DateTimeTypeParser(),
        new DecimalTypeParser(),
        new DoubleTypeParser(),
        new FloatTypeParser(),
        new IntTypeParser(),
        new LongTypeParser(),
        new ShortTypeParser(),
        new StringTypeParser(),
      });
    }
  }
}
