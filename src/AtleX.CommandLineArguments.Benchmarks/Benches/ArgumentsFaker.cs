namespace AtleX.CommandLineArguments.Benchmarks
{
  public static class ArgumentsFaker
  {

    public static string[] GetWindowsStyleArguments()
    {
      var result = new string[]
      {
        "/Byte", "1",
        "/Short", "1",
        "/Int", "10000000",
        "/Long", "1000000000000000000000",

        "/Float", "0.1",
        "/Double", "0.1",

        "/Decimal", "0.1",

        "/Bool", "true",

        "/DateTime", "december 25, 2100 17:00",

        "/Char", "a",
        "/String", "aa",

        "/Toggle" /* No value after this one! */,

        "/Required", "true",
        "/RequiredToggle",
        "/RequiredString", "aa",
      };

      return result;
    }
  }
}
