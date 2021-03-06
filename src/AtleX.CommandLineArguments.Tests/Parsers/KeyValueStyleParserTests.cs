﻿using AtleX.CommandLineArguments.Parsers;
using System.Linq;
using AtleX.CommandLineArguments.Validators;
using Xunit;

namespace AtleX.CommandLineArguments.Tests.Parsers
{

  [Collection("NotInParallel")]
  public class KeyValueStyleParserTests
    : CommandLineArgumentsParserTests
  {
    public KeyValueStyleParserTests()
      : base(new KeyValueStyleParser(), Enumerable.Empty<ArgumentValidator>())
    {
    }

    protected override string[] CreateValidArguments()
    {
      var result = new string[]
      {
        "Byte=" + PrimitiveTypeTestValues.Byte.ToString(),
        "Short=" + PrimitiveTypeTestValues.Short.ToString(),
        "Int=" + PrimitiveTypeTestValues.Int.ToString(),
        "Long=" + PrimitiveTypeTestValues.Long.ToString(),

        "Float=" + PrimitiveTypeTestValues.Float.ToString(),
        "Double=" + PrimitiveTypeTestValues.Double.ToString(),

        "Decimal=" + PrimitiveTypeTestValues.Decimal.ToString(),

        "Bool=" + PrimitiveTypeTestValues.Bool.ToString(),

        "DateTime=" + PrimitiveTypeTestValues.DateTime.ToString(),

        "Char=" + PrimitiveTypeTestValues.Char.ToString(),
        "String=" + PrimitiveTypeTestValues.String.ToString(),

        "Toggle" /* No value after this one! */,

        "Required=" + PrimitiveTypeTestValues.Bool.ToString(),
        "RequiredToggle",
        "RequiredString=" + PrimitiveTypeTestValues.String.ToString(),
      };

      return result;
    }
  }
}
