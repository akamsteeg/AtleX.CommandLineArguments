using System;
using AtleX.CommandLineArguments.Help;

namespace AtleX.CommandLineArguments.Tests.Mocks
{
  public sealed class MockHelpWriter
  : IHelpWriter
  {
    public void Write<T>(T argumentsToWriteHelpFor) where T : Arguments, new()
    {
      throw new NotImplementedException();
    }
  }
}
