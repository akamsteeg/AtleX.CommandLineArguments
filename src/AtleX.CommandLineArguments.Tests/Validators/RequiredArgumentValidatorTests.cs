using System.Linq;
using System.Reflection;
using AtleX.CommandLineArguments.Tests.Mocks;
using AtleX.CommandLineArguments.Validators;
using Xunit;

namespace AtleX.CommandLineArguments.Tests.Validators
{
  public class RequiredArgumentValidatorTests
  {
    [Fact]
    public void TryValidate_PropertyRequiredAndNotEmptyButArgumentNotSupplied_ReturnsFalse()
    {
      var property = typeof(TestArguments).GetTypeInfo().DeclaredProperties.First(a => a.Name == "RequiredString");

      var requiredArgumentValidator = new RequiredArgumentValidator();

      var result = requiredArgumentValidator.TryValidate(property, false, "", out _);

      Assert.False(result);
    }

    [Fact]
    public void TryValidate_PropertyRequiredAndNotEmptyAndArgumentSuppliedButEmpty_ReturnsFalse()
    {
      var property = typeof(TestArguments).GetTypeInfo().DeclaredProperties.First(a => a.Name == "RequiredString");

      var requiredArgumentValidator = new RequiredArgumentValidator();

      var result = requiredArgumentValidator.TryValidate(property, true, "", out _);

      Assert.False(result);
    }

    [Fact]
    public void TryValidate_ValidationFail_ShouldCreateValidationError()
    {
      var property = typeof(TestArguments).GetTypeInfo().DeclaredProperties.First(a => a.Name == "RequiredString");

      var requiredArgumentValidator = new RequiredArgumentValidator();

      var result = requiredArgumentValidator.TryValidate(property, false, "", out var validationError);

      Assert.False(result);
      Assert.NotNull(validationError);
    }

    [Fact]
    public void TryValidate_SuccesfulValidation_ShouldReturnTrue()
    {
      var property = typeof(TestArguments).GetTypeInfo().DeclaredProperties.First(a => a.Name == "RequiredString");

      var requiredArgumentValidator = new RequiredArgumentValidator();

      var result = requiredArgumentValidator.TryValidate(property, true, "value", out _);

      Assert.True(result);
    }
  }
}
