using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AtleX.CommandLineArguments.Parsers.Helpers;
using AtleX.CommandLineArguments.Parsers.TypeParsers;
using AtleX.CommandLineArguments.Tests.Mocks;
using Xunit;

namespace AtleX.CommandLineArguments.Tests.Parsers.Helpers
{
  public class ArgumentPropertiesHelperTests
  {
    [Fact]
    public void FillProperty_WithNullArgumentParameter_Throws()
    {
      var property = typeof(TestArguments).GetTypeInfo().DeclaredProperties.First(a => a.Name == "RequiredString");

      Assert.Throws<ArgumentNullException>(() =>
        ArgumentPropertiesHelper.FillProperty<TestArguments>(null, property, "value", Enumerable.Empty<TypeParser>())
      );
    }

    [Fact]
    public void FillProperty_WithNullPropertyParameter_Throws()
    {
      Assert.Throws<ArgumentNullException>(() =>
        ArgumentPropertiesHelper.FillProperty(new TestArguments(), null, "value", Enumerable.Empty<TypeParser>())
      );
    }

    [Fact]
    public void FillProperty_WithNullPropertyValueParameter_DoesNotThrow()
    {
      var property = typeof(TestArguments).GetTypeInfo().DeclaredProperties.First(a => a.Name == "RequiredString");

      ArgumentPropertiesHelper.FillProperty(new TestArguments(), property, null, Enumerable.Empty<TypeParser>());
    }

    [Fact]
    public void FillProperty_WithEmptyPropertyValueParameter_DoesNotThrow()
    {
      var property = typeof(TestArguments).GetTypeInfo().DeclaredProperties.First(a => a.Name == "RequiredString");

      ArgumentPropertiesHelper.FillProperty(new TestArguments(), property, "", Enumerable.Empty<TypeParser>());
    }

    [Fact]
    public void FillProperty_WithNullTypeParsersParameter_Throws()
    {
      Assert.Throws<ArgumentNullException>(() =>
        ArgumentPropertiesHelper.FillProperty(new TestArguments(), null, "value", null)
      );
    }

    [Fact]
    public void FillProperty_StringProperty_IsParsedCorrectly()
    {
      const string testValue = "TestValue";

      var typeParsers = new List<TypeParser>()
      {
        new StringTypeParser()
      };

      var property = typeof(TestArguments).GetTypeInfo().DeclaredProperties.First(a => a.Name == "RequiredString");
      var arguments = new TestArguments();

      ArgumentPropertiesHelper.FillProperty(arguments, property, testValue, typeParsers);

      Assert.Equal(testValue, arguments.RequiredString);
    }
  }
}
