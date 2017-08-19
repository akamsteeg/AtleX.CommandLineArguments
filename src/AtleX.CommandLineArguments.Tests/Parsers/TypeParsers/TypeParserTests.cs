using System;
using AtleX.CommandLineArguments.Parsers.TypeParsers;
using NUnit.Framework;

namespace AtleX.CommandLineArguments.Tests.Parsers.TypeParsers
{
  public abstract class TypeParserTests<Tparser>
    where Tparser: TypeParser
  {
    protected readonly TypeParser typeParser;

    public TypeParserTests()
    {
      this.typeParser = Activator.CreateInstance<Tparser>();
    }

    public virtual void ValidArgument_ReturnsTrue(string value)
    {
      var result = this.typeParser.TryParse(value, out var parseResult);

      Assert.IsTrue(result);
    }

    public virtual void ValidArgument_OutArgumentIsNotNull(string value)
    {
      var result = this.typeParser.TryParse(value, out var parseResult);

      Assert.IsNotNull(parseResult);
    }

    public virtual void ValidArgument_OutParamIsOfValidType(string value)
    {

      var result = this.typeParser.TryParse(value, out var parseResult);

      Assert.IsInstanceOf(this.typeParser.Type, parseResult);
    }
  }
}
