using System;
using AtleX.CommandLineArguments.Configuration;
using AtleX.CommandLineArguments.Parsers.TypeParsers;
using AtleX.CommandLineArguments.Validators;
using Xunit;

namespace AtleX.CommandLineArguments.Tests.Configuration
{
  public class CommandLineArgumentsConfigurationTests
  {
    [Fact]
    public void Add_TypeParser_WithNull_Throws()
    {
      var config = new CommandLineArgumentsConfiguration();

      Assert.Throws<ArgumentNullException>(() => config.Add((ITypeParser)null));
    }

    [Fact]
    public void Add_ArgumentValidator_WithNull_Throws()
    {
      var config = new CommandLineArgumentsConfiguration();

      Assert.Throws<ArgumentNullException>(() => config.Add((IArgumentValidator)null));
    }
  }
}
