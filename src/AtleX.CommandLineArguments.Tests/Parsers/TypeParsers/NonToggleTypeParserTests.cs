using AtleX.CommandLineArguments.Parsers.TypeParsers;
using NUnit.Framework;

namespace AtleX.CommandLineArguments.Tests.Parsers.TypeParsers
{
  internal abstract class NonToggleTypeParserTests<Tparser>
    : TypeParserTests<Tparser>
    where Tparser: TypeParser
  {
    [Test]
    public void EmptyArgument_ReturnsFalse()
    {
      Assert.IsFalse(this.typeParser.TryParse("", out _));
    }

    [Test]
    public void NullArgument_ReturnsFalse()
    {
      Assert.IsFalse(this.typeParser.TryParse(null, out _));
    }

    public virtual void InvalidArgument_ReturnsFalse(string value)
    {
      var result = this.typeParser.TryParse(value, out _);

      Assert.IsFalse(result);
    }
  }
}
