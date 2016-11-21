﻿using AtleX.CommandLineArguments.Parsers.Helpers;
using System;

namespace AtleX.CommandLineArguments.Parsers
{
  /// <summary>
  /// Represents a Microsoft Windows CLI style ("/key value /key2 value2
  /// /toggle") command line arguments parser
  /// </summary>
  public sealed class WindowsStyleCommandLineArgumentsParser
    : CommandLineArgumentsParser
  {
    /// <summary>
    /// The character indicating a key
    /// </summary>
    private const string keyIndicatorCharacter = "/";

    /// <summary>
    /// Parse the specified arguments to the specified type
    /// </summary>
    /// <typeparam name="T">
    /// The <see cref="Arguments"/> to parse to
    /// </typeparam>
    /// <param name="arguments">
    /// The arguments to parse
    /// </param>
    /// <returns>
    /// The arguments, parsed to the specified type
    /// </returns>
    public override T Parse<T>(string[] arguments)
    {
      if (arguments == null)
        throw new ArgumentNullException(nameof(arguments));

      var result = new T();

      var argumentPropertiesHelper = new ArgumentPropertiesHelper<T>();

      string key;
      string value;

      for (var i = 0; i < arguments.Length; i++)
      {
        var currentItem = arguments[i];
        if (ArgumentIsKey(currentItem))
        {
          key = currentItem.Substring(1);

          if (i + 1 != arguments.Length)
          {
            var possibleValue = arguments[i + 1];
            if (!ArgumentIsKey(possibleValue))
            {
              value = possibleValue;
              i++;
            }
            else
            {
              value = null;
            }
          }
          else
          {
            value = null;
          }

          argumentPropertiesHelper.FillProperty(result, key, value);
        }
      }

      return result;
    }

    /// <summary>
    /// Determines whether the specified argument is a key or not
    /// </summary>
    /// <param name="argument">
    /// The parameter to verify
    /// </param>
    /// <returns>
    /// True when the specified parameter is a key, false otherwise
    /// </returns>
    private static bool ArgumentIsKey(string argument)
    {
      var result = argument.StartsWith(keyIndicatorCharacter);

      return result;
    }
  }
}
