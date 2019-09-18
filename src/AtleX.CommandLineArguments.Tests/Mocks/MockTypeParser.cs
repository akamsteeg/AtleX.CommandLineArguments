using AtleX.CommandLineArguments.Parsers.TypeParsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtleX.CommandLineArguments.Tests.Mocks
{
  public class MockTypeParser
    : ITypeParser
  {
    public Type Type => typeof(string);

    public bool TryParse(string value, out object parseResult)
    {
      parseResult = value;

      return true;
    }
  }
}
