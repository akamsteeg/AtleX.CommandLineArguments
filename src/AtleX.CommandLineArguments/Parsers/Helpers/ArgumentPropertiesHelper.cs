using System;
using System.Collections.Generic;
using System.Reflection;

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
    /// <summary>
    /// Gets the cached <see cref="Type"/>
    /// </summary>
    /// <remarks>
    /// https://msdn.microsoft.com/en-us/library/aa711900(v=vs.71).aspx
    /// </remarks>
    // PERF: By caching these, we avoid allocating them over and over again
    private readonly Type byteType,
      shortType,
      intType,
      longType,

      floatType,
      doubleType,

      decimalType,

      boolType,
      dateType,

      charType,
      stringType;

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

      // Cache the primitive types
      byteType = typeof(byte);
      shortType = typeof(short);
      intType = typeof(int);
      longType = typeof(long);

      floatType = typeof(float);
      doubleType = typeof(double);

      decimalType = typeof(decimal);

      boolType = typeof(bool);

      dateType = typeof(DateTime);

      charType = typeof(char);
      stringType = typeof(string);
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
            if (!currentPropertyInfo.DeclaringType.GetTypeInfo().IsEnum
              || !TryFillEnum(arguments, currentPropertyInfo, propertyValue))
            {
              // Silently discard not supported values and typesra
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
      bool result = false;

      var propertyType = property.PropertyType;

      // PERF Most used types first
      
      // String
      if (propertyType == this.stringType)
      {
        property.SetValue(arguments, value);
        result = true;
      }
      // Bool
      else if (propertyType == this.boolType)
      {
        var propertyValue = false;
        if (value != null)
        {
          result = bool.TryParse(value, out propertyValue);
        }
        else // Just a toggle (argument without value)
        {
          propertyValue = true;
          result = true;
        }

        property.SetValue(arguments, propertyValue);

      }
      // Int
      else if (propertyType == this.intType)
      {
        int propertyValue;
        if (result = int.TryParse(value, out propertyValue) == true)
        {
          property.SetValue(arguments, propertyValue);
        }
      }
      // Other primitive argument types
      // Byte
      else if (propertyType == this.byteType)
      {
        byte propertyValue;
        if (result = byte.TryParse(value, out propertyValue) == true)
        {
          property.SetValue(arguments, propertyValue);
        }
      }
      // Short
      else if (propertyType == this.shortType)
      {
        short propertyValue;
        if (result = short.TryParse(value, out propertyValue) == true)
        {
          property.SetValue(arguments, propertyValue);
        }
      }
      // Long
      else if (propertyType == this.longType)
      {
        long propertyValue;
        if (result = long.TryParse(value, out propertyValue) == true)
        {
          property.SetValue(arguments, propertyValue);
        }
      }
      // Float
      else if (propertyType == this.floatType)
      {
        float propertyValue;
        if (result = float.TryParse(value, out propertyValue) == true)
        {
          property.SetValue(arguments, propertyValue);
        }
      }
      // Double
      else if (propertyType == this.doubleType)
      {
        double propertyValue;
        if (result = double.TryParse(value, out propertyValue) == true)
        {
          property.SetValue(arguments, propertyValue);
        }
      }
      // Decimal
      else if (propertyType == this.decimalType)
      {
        decimal propertyValue;
        if (result = decimal.TryParse(value, out propertyValue) == true)
        {
          property.SetValue(arguments, propertyValue);
        }
      }
      // Date
      else if (propertyType == this.dateType)
      {
        DateTime propertyValue;
        if (result = DateTime.TryParse(value, out propertyValue) == true)
        {
          property.SetValue(arguments, propertyValue);
        }
      }
      // Char
      else if (propertyType == this.charType)
      {
        char propertyValue;
        if (result = char.TryParse(value, out propertyValue) == true)
        {
          property.SetValue(arguments, propertyValue);
        }
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
