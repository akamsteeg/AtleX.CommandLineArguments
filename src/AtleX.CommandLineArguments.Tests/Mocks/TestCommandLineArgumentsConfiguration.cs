using AtleX.CommandLineArguments.Configuration;
using AtleX.CommandLineArguments.Parsers;
using System;
using AtleX.CommandLineArguments.Validators;

namespace AtleX.CommandLineArguments.Tests.Mocks
{
  public class TestCommandLineArgumentsConfiguration
    : CommandLineArgumentsConfiguration
  {
    public TestCommandLineArgumentsConfiguration(CommandLineArgumentsParser parser)
      : base(parser)
    {
      this.Validators.Add(new RequiredArgumentValidator());
    }
  }
}
