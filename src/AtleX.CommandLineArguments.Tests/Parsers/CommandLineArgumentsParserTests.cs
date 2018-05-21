using AtleX.CommandLineArguments.Parsers;
using AtleX.CommandLineArguments.Tests.Mocks;
using System;
using System.Collections.Generic;
using AtleX.CommandLineArguments.Validators;
using AtleX.CommandLineArguments.Parsers.TypeParsers;
using Xunit;

namespace AtleX.CommandLineArguments.Tests.Parsers
{
  public abstract class CommandLineArgumentsParserTests
  {
    protected readonly ICommandLineArgumentsParser parser;

    protected readonly IEnumerable<ArgumentValidator> validators;

    protected readonly IEnumerable<TypeParser> typeParsers;

    public CommandLineArgumentsParserTests(ICommandLineArgumentsParser parser, IEnumerable<ArgumentValidator> validators)
    {
      this.parser = parser;
      this.validators = validators;
      this.typeParsers = new List<TypeParser>()
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
      };
    }

    [Fact]
    public void TryParse_ArgumentsNull_Throws()
    {
      Assert.Throws<ArgumentNullException>(() => parser.Parse<TestArguments>(null, this.validators, this.typeParsers));
    }

    [Fact]
    public void TryParse_ValidatorsNull_Throws()
    {
      var arguments = CreateValidArguments();

      Assert.Throws<ArgumentNullException>(() => parser.Parse<TestArguments>(arguments, null, this.typeParsers));
    }

    [Fact]
    public void TryParse_TypeParsersNull_Throws()
    {
      var arguments = CreateValidArguments();

      Assert.Throws<ArgumentNullException>(() => parser.Parse<TestArguments>(arguments, this.validators, null));
    }

    [Fact]
    public void TryParse_ValidArguments()
    {
      var arguments = CreateValidArguments();

      var result = parser.Parse<TestArguments>(arguments, this.validators, this.typeParsers);

      AssertValidArguments(result.CommandLineArguments);
    }

    [Fact]
    public void CommandLineArgumentsTryParse_ValidArguments()
    {
      var configuration = new TestCommandLineArgumentsConfiguration(parser);
      CommandLineArguments.Configuration = configuration;

      var arguments = CreateValidArguments();

      var result = CommandLineArguments.TryParse<TestArguments>(arguments, out var parsedArguments, out var validationErrors);

      Assert.True(result);
      Assert.Empty(validationErrors);
      AssertValidArguments(parsedArguments);
    }

    private static void AssertValidArguments(TestArguments arguments)
    {
      Assert.NotNull(arguments);

      Assert.Equal(PrimitiveTypeTestValues.Byte, arguments.Byte);
      Assert.Equal(PrimitiveTypeTestValues.Short, arguments.Short);
      Assert.Equal(PrimitiveTypeTestValues.Int, arguments.Int);
      Assert.Equal(PrimitiveTypeTestValues.Long, arguments.Long);

      Assert.Equal(PrimitiveTypeTestValues.Float, arguments.Float);
      Assert.Equal(PrimitiveTypeTestValues.Double, arguments.Double);

      Assert.Equal(PrimitiveTypeTestValues.Decimal, arguments.Decimal);

      Assert.Equal(PrimitiveTypeTestValues.Bool, arguments.Bool);

      Assert.Equal(PrimitiveTypeTestValues.DateTime, arguments.DateTime);

      Assert.Equal(PrimitiveTypeTestValues.Char, arguments.Char);
      Assert.Equal(PrimitiveTypeTestValues.String, arguments.String);

      Assert.True(arguments.Toggle);
    }

    /// <summary>
    /// When overridden, create valid arguments for the <see cref="ICommandLineArgumentsParser"/>
    /// </summary>
    /// <returns>
    /// The valid commandline arguments
    /// </returns>
    protected abstract string[] CreateValidArguments();
  }
}
