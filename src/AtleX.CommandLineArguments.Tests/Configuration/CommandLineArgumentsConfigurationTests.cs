using System;
using System.Collections.Generic;
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
    public void Ctor_WithNullIArgumentValidator_Throws()
    {
      Assert.Throws<ArgumentNullException>(() => new CommandLineArgumentsConfiguration((IArgumentValidator)null));
    }

    [Fact]
    public void Ctor_WithNullIArgumentValidators_Throws()
    {
      Assert.Throws<ArgumentNullException>(() => new CommandLineArgumentsConfiguration((IEnumerable<IArgumentValidator>)null));
    }

    [Fact]
    public void Ctor_WithNullITypeParser_Throws()
    {
      Assert.Throws<ArgumentNullException>(() => new CommandLineArgumentsConfiguration((ITypeParser)null));
    }

    [Fact]
    public void Ctor_WithNullITypeParsers_Throws()
    {
      Assert.Throws<ArgumentNullException>(() => new CommandLineArgumentsConfiguration((IEnumerable<ITypeParser>)null));
    }

    [Fact]
    public void Add_ArgumentValidator_WithNull_Throws()
    {
      var config = new CommandLineArgumentsConfiguration();

      Assert.Throws<ArgumentNullException>(() => config.Add((IArgumentValidator)null));
    }
  }
}
