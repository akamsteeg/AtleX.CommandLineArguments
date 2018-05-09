using System;
using AtleX.CommandLineArguments.Help;
using AtleX.CommandLineArguments.Tests.Mocks;
using Xunit;

namespace AtleX.CommandLineArguments.Tests.Help
{
  public abstract class HelpWriterTests
  {
    protected readonly IHelpWriter helpWriter;

    public HelpWriterTests(IHelpWriter helpWriter)
    {
      this.helpWriter = helpWriter;
    }

    [Fact]
    public void Write_WithNullArguments_Throws()
    {
      Assert.Throws<ArgumentNullException>(() => this.helpWriter.Write<TestArguments>(null));
    }

    [Fact]
    public void Write_WithArguments_Succeeds()
    {
      this.helpWriter.Write(new TestArguments());
    }
  }
}
