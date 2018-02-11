using AtleX.CommandLineArguments.Parsers;
using AtleX.CommandLineArguments.Tests.Mocks;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using AtleX.CommandLineArguments.Validators;
using AtleX.CommandLineArguments.Parsers.TypeParsers;
using System.Linq;

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

    [Test]
    public void TryParse_ArgumentsNull_Throws()
    {
      Assert.Throws<ArgumentNullException>(() => parser.Parse<TestArguments>(null, this.validators, this.typeParsers));
    }

    [Test]
    public void TryParse_ValidArguments()
    {
      var arguments = CreateValidArguments();

      var result = parser.Parse<TestArguments>(arguments, this.validators, this.typeParsers);

      AssertValidArguments(result.CommandLineArguments);
    }

    [Test]
    public void CommandLineArgumentsTryParse_ValidArguments()
    {
      var configuration = new TestCommandLineArgumentsConfiguration(parser);
      CommandLineArguments.Configuration = configuration;

      var arguments = CreateValidArguments();

      var result = CommandLineArguments.TryParse<TestArguments>(arguments, out var parsedArguments, out var validationErrors);

      Assert.IsTrue(result);
      Assert.IsFalse(validationErrors.Any());
      AssertValidArguments(parsedArguments);
    }

    private static void AssertValidArguments(TestArguments arguments)
    {
      Assert.IsNotNull(arguments);

      Assert.AreEqual(PrimitiveTypeTestValues.Byte, arguments.Byte);
      Assert.AreEqual(PrimitiveTypeTestValues.Short, arguments.Short);
      Assert.AreEqual(PrimitiveTypeTestValues.Int, arguments.Int);
      Assert.AreEqual(PrimitiveTypeTestValues.Long, arguments.Long);

      Assert.AreEqual(PrimitiveTypeTestValues.Float, arguments.Float);
      Assert.AreEqual(PrimitiveTypeTestValues.Double, arguments.Double);

      Assert.AreEqual(PrimitiveTypeTestValues.Decimal, arguments.Decimal);

      Assert.AreEqual(PrimitiveTypeTestValues.Bool, arguments.Bool);

      Assert.AreEqual(PrimitiveTypeTestValues.DateTime, arguments.DateTime);

      Assert.AreEqual(PrimitiveTypeTestValues.Char, arguments.Char);
      Assert.AreEqual(PrimitiveTypeTestValues.String, arguments.String);

      Assert.AreEqual(true, arguments.Toggle);
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
