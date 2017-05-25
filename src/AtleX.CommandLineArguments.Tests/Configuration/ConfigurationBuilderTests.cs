using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtleX.CommandLineArguments.Configuration;
using AtleX.CommandLineArguments.Parsers;
using NUnit.Framework;

namespace AtleX.CommandLineArguments.Tests.Configuration
{
  [TestFixture]
  public class ConfigurationBuilderTests
  {
    [Test]
    public void ConfigurationBuilderFor_NoParser_Throws()
    {
      Assert.Throws<ArgumentNullException>(() => ConfigurationBuilder.For(null));
    }

    [Test]
    public void ConfigurationBuilderFor_WithParser()
    {
      var configuration = ConfigurationBuilder.For(new WindowsStyleCommandLineArgumentsParser());

      Assert.IsNotNull(configuration);
    }
  }
}
