using System;
using AtleX.CommandLineArguments.Parsers;
using NUnit.Framework;

namespace AtleX.CommandLineArguments.Tests.Parsers
{
  [TestFixture]
  public class WindowsStyleCommandLineArgumentsParserTests
    : CommandLineArgumentsParserTests
  {
    public WindowsStyleCommandLineArgumentsParserTests()
      : base(new WindowsStyleCommandLineArgumentsParser())
    {

    }

    protected override string[] CreateValidArguments()
    {
      var result = new string[]
      {
        "/Byte", PrimitiveTypeTestValues.Byte.ToString(),
        "/Short", PrimitiveTypeTestValues.Short.ToString(),
        "/Int", PrimitiveTypeTestValues.Int.ToString(),
        "/Long", PrimitiveTypeTestValues.Long.ToString(),

        "/Float", PrimitiveTypeTestValues.Float.ToString(),
        "/Double", PrimitiveTypeTestValues.Double.ToString(),

        "/Decimal", PrimitiveTypeTestValues.Decimal.ToString(),

        "/Bool", PrimitiveTypeTestValues.Bool.ToString(),

        "/DateTime", PrimitiveTypeTestValues.DateTime.ToString(),

        "/Char", PrimitiveTypeTestValues.Char.ToString(),
        "/String", PrimitiveTypeTestValues.String.ToString(),

        "/Toggle" /* No value after this one! */,
      };

      return result;
    }
  }
}
