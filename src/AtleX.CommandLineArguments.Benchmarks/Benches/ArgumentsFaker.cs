namespace AtleX.CommandLineArguments.Benchmarks
{
  public static class ArgumentsFaker
  {

    public static string[] GetWindowsStyleArguments()
    {
      var result = new string[]
      {
        "/Toggle",

        "/String", "lorem ipsum dolor sit amet",

        "/int", "0",

        "/DateTime", "2038-01-19 03:14:07",

        "Enum", "Maybe",
      };

      return result;
    }
  }
}
