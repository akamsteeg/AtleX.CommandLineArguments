using System;
using System.Collections.Generic;
using System.Reflection;
using AtleX.CommandLineArguments.Parsers.TypeParsers;

namespace AtleX.CommandLineArguments.Parsers.Helpers
{
  /// <summary>
  /// Represents a helper for setting property values in the <see cref="Arguments"/>
  /// </summary>
  /// <typeparam name="T">
  /// The <see cref="Arguments"/> type
  /// </typeparam>
  internal sealed class ArgumentPropertiesHelper<T>
      where T : Arguments, new()
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
    /// Initializes a new instance of <see cref="ArgumentPropertiesHelper{T}"/>
    /// </summary>
    /// <param name="typeParsers">
    /// The <see cref="IEnumerable{T}"/> of <see cref="TypeParser"/> to parse the argument values with
    /// </param>
    public ArgumentPropertiesHelper(IEnumerable<TypeParser> typeParsers)
    {
      this.argumentProperties = typeof(T).GetTypeInfo().DeclaredProperties;

      this.typeParsers = typeParsers ?? throw new ArgumentNullException(nameof(typeParsers));
    }

    /// <summary>
    /// Get the <see cref="IEnumerable{T}"/> of <see cref="PropertyInfo"/> of the currently managed <see cref="Arguments"/>
    /// </summary>
    /// <returns>
    /// The <see cref="IEnumerable{T}"/> of <see cref="PropertyInfo"/> of the currently managed <see cref="Arguments"/>
    /// </returns>
    public IEnumerable<PropertyInfo> GetProperties()
    {
      return this.argumentProperties;
    }

    /// <summary>
    /// Set the value of the property with the specified name in the <see
    /// cref="Arguments"/> to the specified value
    /// </summary>
    /// <param name="arguments">
    /// The <see cref="Arguments"/> instance to set the property in
    /// </param>
    /// <param name="propertyName">
    /// The name of the property to set
    /// </param>
    /// <param name="propertyValue">
    /// The value of the property to set
    /// </param>
    public void FillProperty(T arguments, string propertyName, string propertyValue)
    {
      _ = arguments ?? throw new ArgumentNullException(nameof(arguments));
      if (string.IsNullOrWhiteSpace(propertyName))
        throw new ArgumentNullException(nameof(propertyName));

      foreach (var currentPropertyInfo in this.argumentProperties)
      {
        if (currentPropertyInfo.Name.Equals(propertyName, StringComparison.OrdinalIgnoreCase))
        {
          if (!this.TryFillCustomType(arguments, currentPropertyInfo, propertyValue))
          {
            if (!currentPropertyInfo.PropertyType.GetTypeInfo().IsEnum
              || !TryFillEnum(arguments, currentPropertyInfo, propertyValue))
            {
              // No correct type parser configured, ignore the value
            }
          }
        }
      }
    }

    /// <summary>
    /// Try to set the enum property for the specified <see
    /// cref="Arguments"/> with the specified name and value
    /// </summary>
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
    private bool TryFillEnum(T arguments, PropertyInfo property, string value)
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
    private bool TryFillCustomType(T arguments, PropertyInfo property, string value)
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
