using System;

namespace AtleX.CommandLineArguments.Tests.Parsers
{
  internal static class PrimitiveTypeTestValues
  {
    public static readonly byte Byte = byte.MaxValue;
    public static readonly short Short = short.MaxValue;
    public static readonly int Int = int.MaxValue;
    public static readonly long Long = long.MaxValue;

    public static readonly float Float = 100.00F;
    public static readonly double Double = 200.00D;

    public static readonly decimal Decimal = decimal.MaxValue;

    public static readonly bool Bool = true;

    public static readonly DateTime DateTime = new DateTime(1986, 8, 7, 19, 30, 0, DateTimeKind.Utc);

    public static readonly char Char = 'A';
    public static readonly string String = "AtleX.CommandLineArguments";
  }
}
