using AtleX.CommandLineArguments.Help;

namespace AtleX.CommandLineArguments.Tests.Help
{
  public class WindowsStyleHelpWriterTests
  : HelpWriterTests
  {
    public WindowsStyleHelpWriterTests()
      : base(new WindowsStyleHelpWriter())
    {

    }
  }
}
