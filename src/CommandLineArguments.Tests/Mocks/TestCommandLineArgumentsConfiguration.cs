using AtleX.CommandLineArguments.Configuration;
using AtleX.CommandLineArguments.Parsers;
using System;

namespace AtleX.CommandLineArguments.Tests.Mocks
{
  public class TestCommandLineArgumentsConfiguration
    : CommandLineArgumentsConfiguration
  {
    public TestCommandLineArgumentsConfiguration(CommandLineArgumentsParser parser)
    {
      this.Parser = parser;
    }
  }
}
