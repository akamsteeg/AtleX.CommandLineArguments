using AtleX.CommandLineArguments.Parsers;
using AtleX.CommandLineArguments.Tests.Mocks;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using AtleX.CommandLineArguments.Validators;

namespace AtleX.CommandLineArguments.Tests.Parsers
{
  public abstract class CommandLineArgumentsParserTests
  {
    protected readonly CommandLineArgumentsParser parser;

    protected readonly IEnumerable<ArgumentValidator> validators;

    public CommandLineArgumentsParserTests(CommandLineArgumentsParser parser, IEnumerable<ArgumentValidator> validators)
    {
      this.parser = parser;
      this.validators = validators;
    }

    [Test]
    public void TryParse_ArgumentsNull_Throws()
    {
      Assert.Throws<ArgumentNullException>(() => parser.Parse<TestArguments>(null, this.validators));
    }

    [Test]
    public void TryParse_ValidArguments()
    {
      var arguments = CreateValidArguments();

      var result = parser.Parse<TestArguments>(arguments, this.validators);

      AssertValidArguments(result.CommandLineArguments);
    }

    [Test]
    public void CommandLineArgumentsTryParse_ValidArguments()
    {
      var configuration = new TestCommandLineArgumentsConfiguration(parser);
      CommandLineArguments.Configuration = configuration;

      var arguments = CreateValidArguments();

      var result = CommandLineArguments.TryParse<TestArguments>(arguments, out TestArguments parsedArguments, out IEnumerable<ValidationError> vr);
      Assert.IsTrue(result);
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
    /// When overridden, create valid arguments for the <see cref="CommandLineArgumentsParser"/>
    /// </summary>
    /// <returns>
    /// The valid commandline arguments
    /// </returns>
    protected abstract string[] CreateValidArguments();
  }
}
