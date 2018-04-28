using AtleX.CommandLineArguments.Parsers.TypeParsers;
using NUnit.Framework;

namespace AtleX.CommandLineArguments.Tests.Parsers.TypeParsers
{
  internal abstract class ToggleTypeParserTests<Tparser>
    : TypeParserTests<Tparser>
    where Tparser: TypeParser
  {
    [Test]
    public void EmptyArgument_ReturnsTrue()
    {
      var result = this.typeParser.TryParse("", out _);

      Assert.IsTrue(result);
    }
  }
}
