using System;
using System.Collections.Generic;
using System.Reflection;
using AtleX.CommandLineArguments.Parsers.TypeParsers;

namespace AtleX.CommandLineArguments.Parsers.Helpers
{
  /// <summary>
  /// Represents a helper for setting property values in the <see cref="Arguments"/>
  /// </summary>
  internal sealed class ArgumentPropertiesHelper
  { 
    /// <summary>
    /// Gets the collection of <see cref="PropertyInfo"/> for the specified type
    /// </summary>
    private readonly IEnumerable<PropertyInfo> argumentProperties;

    /// <summary>
    /// Gets the collection of <see cref="TypeParser"/> to parse the argument values with
    /// </summary>
    private readonly IEnumerable<TypeParser> typeParsers;

    /// <summary>
    /// Initializes a new instance of <see cref="ArgumentPropertiesHelper"/>
    /// </summary>
    /// <param name="argumentProperties"></param>
    /// <param name="typeParsers">
    /// The <see cref="IEnumerable{T}"/> of <see cref="TypeParser"/> to parse the argument values with
    /// </param>
    public ArgumentPropertiesHelper(IEnumerable<PropertyInfo> argumentProperties, IEnumerable<TypeParser> typeParsers)
    {
      this.argumentProperties = argumentProperties ?? throw new ArgumentNullException(nameof(argumentProperties));

      this.typeParsers = typeParsers ?? throw new ArgumentNullException(nameof(typeParsers));
    }

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
    /// <param name="propertyName">
    /// The name of the property to set
    /// </param>
    /// <param name="propertyValue">
    /// The value of the property to set
    /// </param>
    public void FillProperty<T>(T arguments, string propertyName, string propertyValue)
      where T: Arguments
    {
      _ = arguments ?? throw new ArgumentNullException(nameof(arguments));
      if (string.IsNullOrWhiteSpace(propertyName))
        throw new ArgumentNullException(nameof(propertyName));

      foreach (var currentPropertyInfo in this.argumentProperties)
      {
        if (currentPropertyInfo.Name.Equals(propertyName, StringComparison.OrdinalIgnoreCase))
        {
          if (
            (this.TryFillCustomType(arguments, currentPropertyInfo, propertyValue))
            ||
             (currentPropertyInfo.PropertyType.GetTypeInfo().IsEnum && TryFillEnum(arguments, currentPropertyInfo, propertyValue))
             )
          {
            break;
          }
        }
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
    private bool TryFillEnum<T>(T arguments, PropertyInfo property, string value)
      where T: Arguments
    {
      var result = false;

      var enumType = property.PropertyType;

      if (result = property.PropertyType.GetTypeInfo().IsEnumDefined(value) == true)
      {
        var propertyValue = Enum.Parse(property.PropertyType, value, true);

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
    /// <returns>
    /// True when the property value could be set, false otherwise
    /// </returns>
    private bool TryFillCustomType<T>(T arguments, PropertyInfo property, string value)
      where T: Arguments
    {
      var result = false;

      foreach (var currentTypeParser in this.typeParsers)
      {
        if (currentTypeParser.Type == property.PropertyType)
        {
          result = currentTypeParser.TryParse(value, out var parseResult);

          if (result)
          {
            property.SetValue(arguments, parseResult);
            break;
          }
        }
      }

      return result;
    }
  }
}
