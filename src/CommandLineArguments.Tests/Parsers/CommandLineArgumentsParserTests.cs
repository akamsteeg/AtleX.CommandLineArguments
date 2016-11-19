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
    protected object[] CreateValidArguments()
    {
      var result = new object[]
      {
        CreateAppropriateKey("Byte"), PrimitiveTypeTestValues.Byte.ToString(),
        CreateAppropriateKey("Short"), PrimitiveTypeTestValues.Short.ToString(),
        CreateAppropriateKey("Int"), PrimitiveTypeTestValues.Int.ToString(),
        CreateAppropriateKey("Long"), PrimitiveTypeTestValues.Long.ToString(),

        CreateAppropriateKey("Float"), PrimitiveTypeTestValues.Float.ToString(),
        CreateAppropriateKey("Double"), PrimitiveTypeTestValues.Double.ToString(),

        CreateAppropriateKey("Decimal"), PrimitiveTypeTestValues.Decimal.ToString(),

        CreateAppropriateKey("Bool"), PrimitiveTypeTestValues.Bool.ToString(),

        CreateAppropriateKey("DateTime"), PrimitiveTypeTestValues.DateTime.ToString(),

        CreateAppropriateKey("Char"), PrimitiveTypeTestValues.Char.ToString(),
        CreateAppropriateKey("String"), PrimitiveTypeTestValues.String.ToString(),

        CreateAppropriateKey("Toggle") /* No value after this one! */,
      };

      return result;
    }

    /// <summary>
    /// Create the appropriate full key with the specified name
    /// </summary>
    /// <param name="keyName">
    /// The name of the key
    /// </param>
    /// <returns>
    /// The appropriate full key
    /// </returns>
    protected abstract string CreateAppropriateKey(string keyName);
  }
}
