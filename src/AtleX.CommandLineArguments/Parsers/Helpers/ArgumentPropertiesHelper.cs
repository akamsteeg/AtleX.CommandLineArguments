using System;
using System.Collections.Generic;
using System.Reflection;
using AtleX.CommandLineArguments.Parsers.TypeParsers;

namespace AtleX.CommandLineArguments.Parsers.Helpers
{
  /// <summary>
  /// Represents a helper for setting property values in the <see cref="Arguments"/>
  /// </summary>
  internal static class ArgumentPropertiesHelper
  {
    /// <summary>
    /// Set the value of the property with the specified name in the <see
    /// cref="Arguments"/> to the specified value
    /// </summary>
    /// <typeparam name="T">
    /// The <see cref="Arguments"/> type
    /// </typeparam>
    /// <param name="arguments">
    /// The <see cref="Arguments"/> instance to set the property in
    /// </param>
    /// <param name="propertyInfo">
    /// The <see cref="PropertyInfo"/> to set the value for
    /// </param>
    /// <param name="propertyValue">
    /// The value of the property to set
    /// </param>
    /// <param name="typeParsers">
    /// The <see cref="IEnumerable{T}"/> of <see cref="ITypeParser"/> to parse the
    /// argument values with
    /// </param>
    public static void FillProperty<T>(T arguments, PropertyInfo propertyInfo, string propertyValue, IEnumerable<ITypeParser> typeParsers)
      where T : Arguments
    {
      _ = arguments ?? throw new ArgumentNullException(nameof(arguments));
      _ = propertyInfo ?? throw new ArgumentNullException(nameof(propertyInfo));
      _ = typeParsers ?? throw new ArgumentNullException(nameof(typeParsers));

      if (
            (TryFillCustomType(arguments, propertyInfo, propertyValue, typeParsers))
            ||
             (propertyInfo.PropertyType.GetTypeInfo().IsEnum && TryFillEnum(arguments, propertyInfo, propertyValue))
             )
      {
      }
    }

    /// <summary>
    /// Try to set the enum property for the specified <see
    /// cref="Arguments"/> with the specified name and value
    /// </summary>
    /// <typeparam name="T">
    /// The <see cref="Arguments"/> type
    /// </typeparam>
    /// <param name="arguments">
    /// The <see cref="Arguments"/> instance to set the property in
    /// </param>
    /// <param name="property">
    /// The <see cref="PropertyInfo"/> of the property to set
    /// </param>
    /// <param name="value">
    /// The value to set
    /// </param>
    /// <returns>
    /// True when the property value could be set, false otherwise
    /// </returns>
    private static bool TryFillEnum<T>(T arguments, PropertyInfo property, string value)
      where T : Arguments
    {
      var result = false;

      var enumType = property.PropertyType;

      if (result = enumType.GetTypeInfo().IsEnumDefined(value) == true)
      {
        var propertyValue = Enum.Parse(enumType, value, ignoreCase: true);

        property.SetValue(arguments, propertyValue);
      }

      return result;
    }

    /// <summary>
    /// Try to set the value for in the specified <see cref="Arguments"/> on the
    /// specified <see cref="PropertyInfo"/>
    /// </summary>
    /// <typeparam name="T">
    /// The <see cref="Arguments"/> type
    /// </typeparam>
    /// <param name="arguments">
    /// The <see cref="Arguments"/> instance to set the property in
    /// </param>
    /// <param name="property">
    /// The <see cref="PropertyInfo"/> of the property to set
    /// </param>
    /// <param name="value">
    /// The value to set
    /// </param>
    /// <param name="typeParsers">
    /// The <see cref="IEnumerable{T}"/> of <see cref="ITypeParser"/> to parse the
    /// argument values with
    /// </param>
    /// <returns>
    /// True when the property value could be set, false otherwise
    /// </returns>
    private static bool TryFillCustomType<T>(T arguments, PropertyInfo property, string value, IEnumerable<ITypeParser> typeParsers)
      where T : Arguments
    {
      var result = false;
      var typeParser = GetTypeParser(property.PropertyType, typeParsers);

      if (typeParser != null && typeParser.TryParse(value, out var parseResult))
      {
        result = true;
        property.SetValue(arguments, parseResult);
      }

      return result;
    }

    /// <summary>
    /// Get the <see cref="ITypeParser"/> for the specified <see cref="Type"/> in
    /// the specified <see cref="IEnumerable{T}"/> of <see cref="ITypeParser"/>
    /// </summary>
    /// <param name="type">
    /// The <see cref="Type"/> to get the <see cref="ITypeParser"/> for
    /// </param>
    /// <param name="typeParsers">
    /// The <see cref="IEnumerable{T}"/> of <see cref="ITypeParser"/> to find the
    /// parser for the specified <see cref="Type"/> in
    /// </param>
    /// <returns>
    /// The <see cref="ITypeParser"/> for the specified <see cref="Type"/>; null
    /// if no parser is available
    /// </returns>
    private static ITypeParser GetTypeParser(Type type, IEnumerable<ITypeParser> typeParsers)
    {
      ITypeParser result = null;
      foreach (var currentTypeParser in typeParsers)
      {
        if (currentTypeParser.Type == type)
        {
          result = currentTypeParser;
          break;
        }
      }

      return result;
    }
  }
}
