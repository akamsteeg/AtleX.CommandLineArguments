using AtleX.CommandLineArguments.Help;

namespace AtleX.CommandLineArguments.Tests.Help
{
  public class LinuxStyleHelpWriterTests
: HelpWriterTests
  {
    public LinuxStyleHelpWriterTests()
      : base(new LinuxStyleHelpWriter())
    {

    }
  }
}
