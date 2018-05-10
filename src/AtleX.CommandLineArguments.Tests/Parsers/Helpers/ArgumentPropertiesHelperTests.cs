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
    public void Ctor_WithNullTypeParsers_Throws()
    {
      Assert.Throws<ArgumentNullException>(() => new ArgumentPropertiesHelper(null));
    }

    [Fact]
    public void Ctor_WithTypeParsers_DoesNotThrow()
    {
      new ArgumentPropertiesHelper(Enumerable.Empty<TypeParser>());
    }

    [Fact]
    public void FillProperty_WithNullArgumentParameter_Throws()
    {
      var helper = new ArgumentPropertiesHelper(Enumerable.Empty<TypeParser>());
      var property = typeof(TestArguments).GetTypeInfo().DeclaredProperties.First(a => a.Name == "RequiredString");

      Assert.Throws<ArgumentNullException>(() => helper.FillProperty<TestArguments>(null, property, "value"));
    }

    [Fact]
    public void FillProperty_WithNullPropertyParameter_Throws()
    {
      var helper = new ArgumentPropertiesHelper(Enumerable.Empty<TypeParser>());

      Assert.Throws<ArgumentNullException>(() => helper.FillProperty(new TestArguments(), null, "value"));
    }

    [Fact]
    public void FillProperty_WithNullPropertyValueParameter_DoesNotThrow()
    {
      var helper = new ArgumentPropertiesHelper(Enumerable.Empty<TypeParser>());
      var property = typeof(TestArguments).GetTypeInfo().DeclaredProperties.First(a => a.Name == "RequiredString");

      helper.FillProperty(new TestArguments(), property, null);
    }

    [Fact]
    public void FillProperty_WithEmptyPropertyValueParameter_DoesNotThrow()
    {
      var helper = new ArgumentPropertiesHelper(Enumerable.Empty<TypeParser>());
      var property = typeof(TestArguments).GetTypeInfo().DeclaredProperties.First(a => a.Name == "RequiredString");

      helper.FillProperty(new TestArguments(), property, "");
    }

    [Fact]
    public void FillProperty_StringProperty_IsParsedCorrectly()
    {
      const string testValue = "TestValue";

      var typeParsers = new List<TypeParser>()
      {
        new StringTypeParser()
      };
      var helper = new ArgumentPropertiesHelper(typeParsers);
      var property = typeof(TestArguments).GetTypeInfo().DeclaredProperties.First(a => a.Name == "RequiredString");
      var arguments = new TestArguments();
      
      helper.FillProperty(arguments, property, testValue);

      Assert.Equal(testValue, arguments.RequiredString);
    }
  }
}
