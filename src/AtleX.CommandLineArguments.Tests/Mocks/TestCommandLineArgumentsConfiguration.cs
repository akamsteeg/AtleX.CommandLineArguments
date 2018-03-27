using AtleX.CommandLineArguments.Configuration;
using AtleX.CommandLineArguments.Parsers;
using AtleX.CommandLineArguments.Validators;
using AtleX.CommandLineArguments.Parsers.TypeParsers;

namespace AtleX.CommandLineArguments.Tests.Mocks
{
  public class TestCommandLineArgumentsConfiguration
    : CommandLineArgumentsConfiguration
  {
    public TestCommandLineArgumentsConfiguration(ICommandLineArgumentsParser parser)
    {
      this.Parser = parser;
      this.Validators.Add(new RequiredArgumentValidator());
      this.TypeParsers.Add(new BoolTypeParser());
      this.TypeParsers.Add(new ByteTypeParser());
      this.TypeParsers.Add(new CharTypeParser());
      this.TypeParsers.Add(new DateTimeTypeParser());
      this.TypeParsers.Add(new DecimalTypeParser());
      this.TypeParsers.Add(new DoubleTypeParser());
      this.TypeParsers.Add(new FloatTypeParser());
      this.TypeParsers.Add(new IntTypeParser());
      this.TypeParsers.Add(new LongTypeParser());
      this.TypeParsers.Add(new ShortTypeParser());
      this.TypeParsers.Add(new StringTypeParser());
    }
  }
}
