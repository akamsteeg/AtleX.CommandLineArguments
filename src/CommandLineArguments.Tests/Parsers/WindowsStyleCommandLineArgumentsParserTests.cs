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

    protected override object[] CreateValidArguments()
    {
      var result = new object[]
      {
        "/firstKey", "firstKeyValue",
        "/secondKey", "true",
        "/thirdKey", "thirdKeyValue"
      };

      return result;
    }
  }
}
