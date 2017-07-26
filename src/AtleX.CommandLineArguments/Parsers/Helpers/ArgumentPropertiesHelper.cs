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
  /// <remarks>
  /// Do not cache an instance of this object in a field or property. It's quite
  /// big and allocates some stuff itself. By instantiating it as close to the
  /// code that needs it and null it afterwards, the garbage collector can do
  /// its work
  /// </remarks>
  internal class ArgumentPropertiesHelper<T>
      where T : Arguments, new()
  {
    // PERF: By caching these, we avoid allocating them over and over again
    
    // TODO: Make these Lazy<T> to reduce memory usage?

    /// <summary>
    /// Gets the <see cref="TypeParser{T}"/> for <see cref="byte"/>
    /// </summary>
    private readonly TypeParser<byte> byteParser;

    /// <summary>
    /// Gets the <see cref="TypeParser{T}"/> for <see cref="short"/>
    /// </summary>
    private readonly TypeParser<short> shortParser;

    /// <summary>
    /// Gets the <see cref="TypeParser{T}"/> for <see cref="int"/>
    /// </summary>
    private readonly TypeParser<int> intParser;

    /// <summary>
    /// Gets the <see cref="TypeParser{T}"/> for <see cref="long"/>
    /// </summary>
    private readonly TypeParser<long> longParser;

    /// <summary>
    /// Gets the <see cref="TypeParser{T}"/> for <see cref="float"/>
    /// </summary>
    private readonly TypeParser<float> floatParser;

    /// <summary>
    /// Gets the <see cref="TypeParser{T}"/> for <see cref="double"/>
    /// </summary>
    private readonly TypeParser<double> doubleParser;

    /// <summary>
    /// Gets the <see cref="TypeParser{T}"/> for <see cref="decimal"/>
    /// </summary>
    private readonly TypeParser<decimal> decimalParser;

    /// <summary>
    /// Gets the <see cref="TypeParser{T}"/> for <see cref="bool"/>
    /// </summary>
    private readonly TypeParser<bool> boolParser;

    /// <summary>
    /// Gets the <see cref="TypeParser{T}"/> for <see cref="DateTime"/>
    /// </summary>
    private readonly TypeParser<DateTime> dateTimeParser;

    /// <summary>
    /// Gets the <see cref="TypeParser{T}"/> for <see cref="char"/>
    /// </summary>
    private readonly TypeParser<char> charParser;

    /// <summary>
    /// Gets the <see cref="TypeParser{T}"/> for <see cref="string"/>
    /// </summary>
    private readonly TypeParser<string> stringParser;

    /// <summary>
    /// Gets the collection of <see cref="PropertyInfo"/> for the specified type
    /// </summary>
    private readonly IEnumerable<PropertyInfo> argumentProperties;

    /// <summary>
    /// Initializes a new instance of <see cref="ArgumentPropertiesHelper{T}"/>
    /// </summary>
    public ArgumentPropertiesHelper()
    {
      this.argumentProperties = typeof(T).GetTypeInfo().DeclaredProperties;

      // Cache the primitive type parsers
      this.byteParser = new ByteTypeParser();
      this.shortParser = new ShortTypeParser();
      this.intParser = new IntTypeParser();
      this.longParser = new LongTypeParser();

      this.floatParser = new FloatTypeParser();
      this.doubleParser = new DoubleTypeParser();

      this.decimalParser = new DecimalTypeParser();

      this.boolParser = new BoolTypeParser();

      this.dateTimeParser = new DateTimeTypeParser();

      this.charParser = new CharTypeParser();
      this.stringParser = new StringTypeParser();
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
      if (arguments == null)
        throw new ArgumentNullException(nameof(arguments));
      if (string.IsNullOrWhiteSpace(propertyName))
        throw new ArgumentNullException(nameof(propertyName));

      foreach (var currentPropertyInfo in this.argumentProperties)
      {
        if (currentPropertyInfo.Name.Equals(propertyName, StringComparison.OrdinalIgnoreCase))
        {
          if (!TryFillPrimitiveProperty(arguments, currentPropertyInfo, propertyValue))
          {
            if (!currentPropertyInfo.PropertyType.GetTypeInfo().IsEnum
              || !TryFillEnum(arguments, currentPropertyInfo, propertyValue))
            {
              // Silently discard not supported values and types
            }
          }
        }
      }
    }

    /// <summary>
    /// Try to set the primitive property for the specified <see
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
    private bool TryFillPrimitiveProperty(T arguments, PropertyInfo property, string value)
    {
      var result = true;

      var propertyType = property.PropertyType;

      // PERF Most used types first

      // String
      if (propertyType == this.stringParser.Type && this.stringParser.TryParse(value, out var stringValue))
      {
        property.SetValue(arguments, stringValue);
      }
      // Bool
      else if (propertyType == this.boolParser.Type && this.boolParser.TryParse(value, out var boolValue))
      {
        property.SetValue(arguments, boolValue);
      }
      // Int
      else if (propertyType == this.intParser.Type && this.intParser.TryParse(value, out var intValue))
      {
        property.SetValue(arguments, intValue);
      }
      // Other primitive argument types
      // Byte
      else if (propertyType == this.byteParser.Type && this.byteParser.TryParse(value, out var byteValue))
      {
        property.SetValue(arguments, byteValue);
      }
      // Short
      else if (propertyType == this.shortParser.Type && this.shortParser.TryParse(value, out var shortValue))
      {
        property.SetValue(arguments, shortValue);
      }
      // Long
      else if (propertyType == this.longParser.Type && this.longParser.TryParse(value, out var longValue))
      {
        property.SetValue(arguments, longValue);
      }
      // Float
      else if (propertyType == this.floatParser.Type && this.floatParser.TryParse(value, out var floatValue))
      {
        property.SetValue(arguments, floatValue);
      }
      // Double
      else if (propertyType == this.doubleParser.Type && this.doubleParser.TryParse(value, out var doubleValue))
      {
        property.SetValue(arguments, doubleValue);
      }
      // Decimal
      else if (propertyType == this.decimalParser.Type && this.decimalParser.TryParse(value, out var decimalValue))
      {
        property.SetValue(arguments, decimalValue);
      }
      // Date
      else if (propertyType == this.dateTimeParser.Type && this.dateTimeParser.TryParse(value, out var dateTimeValue))
      {
        property.SetValue(arguments, dateTimeValue);
      }
      // Char
      else if (propertyType == this.charParser.Type && this.charParser.TryParse(value, out var charValue))
      {
        property.SetValue(arguments, charValue);
      }
      else
      {
        result = false;
      }

      return result;
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
  }
}
