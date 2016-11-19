using AtleX.CommandLineArguments.Parsers.Helpers;
using System;

namespace AtleX.CommandLineArguments.Parsers
{
  /// <summary>
  /// 
  /// </summary>
  public sealed class KeyValueCommandLineArgumentsParser
    : CommandLineArgumentsParser
  {
    public override T Parse<T>(object[] arguments)
    {
      if (arguments == null)
        throw new ArgumentNullException(nameof(arguments));

      var result = new T();

      var argumentPropertiesHelper = new ArgumentPropertiesHelper<T>();

      string key;
      string value;
      for (var i = 0; i < arguments.Length; i++)
      {
        var argumentParts = arguments[i].ToString().Split('=');

        key = argumentParts[0];

        if (argumentParts.Length == 2)
        {
          value = argumentParts[1];
        }
        else
        {
          value = null;
        }

        argumentPropertiesHelper.FillProperty(result, key, value);
      }

      return result;
    }
  }
}
