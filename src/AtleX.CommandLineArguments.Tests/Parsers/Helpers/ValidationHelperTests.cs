using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtleX.CommandLineArguments.Parsers.Helpers;
using AtleX.CommandLineArguments.Validators;
using Xunit;

namespace AtleX.CommandLineArguments.Tests.Parsers.Helpers
{
  public class ValidationHelperTests
  {
    [Fact]
    public void Ctor_WithNullValidatorsToRun_Throws()
    {
      Assert.Throws<ArgumentNullException>(() => new ValidationHelper(null));
    }

    [Fact]
    public void Ctor_WithValidatorsToRun_DoesNotThrow()
    {
      new ValidationHelper(Enumerable.Empty<ArgumentValidator>());
    }

    [Fact]
    public void TryValidate_WithNullPropertyInfo_Throws()
    {
      var helper = new ValidationHelper(Enumerable.Empty<ArgumentValidator>());

      Assert.Throws<ArgumentNullException>(() => helper.TryValidate(null, true, "", out _));
    }
  }
}
 