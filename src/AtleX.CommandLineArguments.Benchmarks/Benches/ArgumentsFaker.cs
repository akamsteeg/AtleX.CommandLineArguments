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

        "Enum", "Maybe",
      };

      return result;
    }
  }
}
