using AtleX.CommandLineArguments.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AtleX.CommandLineArguments.Tests.Mocks
{
  public class MockArgumentValidator
    : IArgumentValidator
  {
    public bool TryValidate(PropertyInfo argumentPropertyInfo, bool isSpecified, string originalValue, out ValidationError validationError)
    {
      validationError = null;
      return true;
    }
  }
}
