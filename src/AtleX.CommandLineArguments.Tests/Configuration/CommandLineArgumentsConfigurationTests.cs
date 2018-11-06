using System;
using System.Collections.Generic;
using System.Linq;
using AtleX.CommandLineArguments.Configuration;
using AtleX.CommandLineArguments.Parsers.TypeParsers;
using AtleX.CommandLineArguments.Tests.Mocks;
using AtleX.CommandLineArguments.Validators;
using Xunit;

namespace AtleX.CommandLineArguments.Tests.Configuration
{
  public class CommandLineArgumentsConfigurationTests
  {
    [Fact]
    public void Ctor_WithNullIArgumentValidator_Throws()
    {
      Assert.Throws<ArgumentNullException>(() => new CommandLineArgumentsConfiguration((IArgumentValidator)null));
    }

    [Fact]
    public void Ctor_WithIArgumentValidator_Succeeds()
    {
      var c = new CommandLineArgumentsConfiguration(new MockArgumentValidator());

      Assert.Contains(c.Validators, v => v.GetType() == typeof(MockArgumentValidator));
    }

    [Fact]
    public void Ctor_WithIArgumentValidators_Succeeds()
    {
      var c = new CommandLineArgumentsConfiguration(new[] { new MockArgumentValidator() });

      Assert.Contains(c.Validators, v => v.GetType() == typeof(MockArgumentValidator));
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
    public void Ctor_WithITypeParser_Succeeds()
    {
      var c = new CommandLineArgumentsConfiguration(new MockTypeParser());

      Assert.Contains(c.TypeParsers, p => p.GetType() == typeof(MockTypeParser));
    }

    [Fact]
    public void Ctor_WithITypeParsers_Succeeds()
    {
      var c = new CommandLineArgumentsConfiguration(new[] { new MockTypeParser() });

      Assert.Contains(c.TypeParsers, p => p.GetType() == typeof(MockTypeParser));
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

    [Fact]
    public void Add_TypeParser_WithNull_Throws()
    {
      var config = new CommandLineArgumentsConfiguration();

      Assert.Throws<ArgumentNullException>(() => config.Add((ITypeParser)null));
    }

    [Fact]
    public void AddRange_ArgumentValidators_WithNull_Throws()
    {
      var config = new CommandLineArgumentsConfiguration();

      Assert.Throws<ArgumentNullException>(() => config.AddRange((IEnumerable<IArgumentValidator>)null));
    }

    [Fact]
    public void AddRange_ArgumentValidators_WithValidValidator_Succeeds()
    {
      var config = new CommandLineArgumentsConfiguration();

      config.AddRange(new[] { new MockArgumentValidator() });

      Assert.Contains(config.Validators, v => v.GetType() == typeof(MockArgumentValidator));
    }

    [Fact]
    public void AddRange_TypeParsers_WithNull_Throws()
    {
      var config = new CommandLineArgumentsConfiguration();

      Assert.Throws<ArgumentNullException>(() => config.AddRange((IEnumerable<ITypeParser>)null));
    }

    [Fact]
    public void AddRange_TypeParsers_WithValidParser_Succeeds()
    {
      var config = new CommandLineArgumentsConfiguration();

      config.AddRange(new[] { new MockTypeParser() });

      Assert.Contains(config.TypeParsers, p => p.GetType() == typeof(MockTypeParser));
    }
  }
}
