using System;
using AtleX.CommandLineArguments.Parsers.TypeParsers;
using Xunit;

namespace AtleX.CommandLineArguments.Tests.Parsers.TypeParsers
{
  public abstract class TypeParserTests
  {
    protected readonly TypeParser typeParser;

    public TypeParserTests(TypeParser parser)
    {
      this.typeParser = parser;
    }

    public virtual void ValidArgument_ReturnsTrue(string value)
    {
      var result = this.typeParser.TryParse(value, out var parseResult);

      Assert.True(result);
    }

    public virtual void ValidArgument_OutArgumentIsNotNull(string value)
    {
      var result = this.typeParser.TryParse(value, out var parseResult);

      Assert.NotNull(parseResult);
    }

    public virtual void ValidArgument_OutParamIsOfValidType(string value)
    {

      var result = this.typeParser.TryParse(value, out var parseResult);

      Assert.IsType(this.typeParser.Type, parseResult);
    }
  }
}
