using AtleX.CommandLineArguments.Configuration;
using AtleX.CommandLineArguments.Parsers;

namespace AtleX.CommandLineArguments.Tests.Mocks
{
  public class TestCommandLineArgumentsConfiguration
    : CommandLineArgumentsConfiguration
  {
    public TestCommandLineArgumentsConfiguration(ICommandLineArgumentsParser parser)
    {
      this.Parser = parser;
    }
  }
}
