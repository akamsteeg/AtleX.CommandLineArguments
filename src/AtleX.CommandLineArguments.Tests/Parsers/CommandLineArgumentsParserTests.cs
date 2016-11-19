using AtleX.CommandLineArguments.Parsers;
using AtleX.CommandLineArguments.Tests.Mocks;
using NUnit.Framework;
using System;

namespace AtleX.CommandLineArguments.Tests.Parsers
{
  public abstract class CommandLineArgumentsParserTests
  {
    protected readonly CommandLineArgumentsParser parser;

    public CommandLineArgumentsParserTests(CommandLineArgumentsParser parser)
    {
      this.parser = parser;
    }

    [Test]
    public void Parse_ArgumentsNull_Throws()
    {
      Assert.Throws<ArgumentNullException>(() => parser.Parse<TestArguments>(null));
    }

    [Test]
    public void Parse_ValidArguments()
    {
      var arguments = CreateValidArguments();

      var result = parser.Parse<TestArguments>(arguments);

      AssertValidArguments(result);
    }

    [Test]
    public void CommandLineArgumentsParse_ValidArguments()
    {
      var configuration = new TestCommandLineArgumentsConfiguration(parser);
      CommandLineArguments.Configuration = configuration;

      var arguments = CreateValidArguments();

      var result = CommandLineArguments.Parse<TestArguments>(arguments);
      AssertValidArguments(result);
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
    protected abstract object[] CreateValidArguments();
  }
}
