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

    protected override string CreateAppropriateKey(string keyName)
    {
      var result = "/" + keyName;

      return result;
    }
  }
}
