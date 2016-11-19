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

      Assert.IsNotNull(result);

      Assert.AreEqual(PrimitiveTypeTestValues.Byte, result.Byte);
      Assert.AreEqual(PrimitiveTypeTestValues.Short, result.Short);
      Assert.AreEqual(PrimitiveTypeTestValues.Int, result.Int);
      Assert.AreEqual(PrimitiveTypeTestValues.Long, result.Long);

      Assert.AreEqual(PrimitiveTypeTestValues.Float, result.Float);
      Assert.AreEqual(PrimitiveTypeTestValues.Double, result.Double);

      Assert.AreEqual(PrimitiveTypeTestValues.Decimal, result.Decimal);

      Assert.AreEqual(PrimitiveTypeTestValues.Bool, result.Bool);

      Assert.AreEqual(PrimitiveTypeTestValues.DateTime, result.DateTime);

      Assert.AreEqual(PrimitiveTypeTestValues.Char, result.Char);
      Assert.AreEqual(PrimitiveTypeTestValues.String, result.String);

      Assert.AreEqual(true, result.Toggle);
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
