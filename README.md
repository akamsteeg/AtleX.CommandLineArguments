# AtleX.CommandLineArguments

AtleX.CommandLineArguments is a helper library to facilitate parsing command line arguments into a strongly-typed object. Values can be validated with extensible
and customisable validators and the library can automatically generate help for the user.

Supported .NET frameworks:
* .NET 4.6.1
* NETSTANDARD 2.0

# Installation

AtleX.CommandLineArguments is available [as NuGet package](https://www.nuget.org/packages/AtleX.CommandLineArguments/):

```
install-package AtleX.CommandLineArguments -Pre
```

# Documentation

See [the Wiki](https://github.com/akamsteeg/AtleX.CommandLineArguments/wiki) for documentation. Use 
[Getting started](https://github.com/akamsteeg/AtleX.CommandLineArguments/wiki/Getting-started) to get going.

# Example

```csharp
public class Program
{
	private class MyArgumentsClass : Arguments
	{
		[Required]
		[Display(Description = "This text will be displayed in the help, when requested")]
		public bool Argument1
		{
			get;
			set;
		}

		[Display(Description = "This text will be displayed in the help, when requested")]
		public string Name // Not required
		{
			get;
			set;
		}
	}
	
	static void Main(string[] args)
	{
		MyArgumentsClass cliArguments;
		if (!CommandLineArguments.TryParse<MyArgumentsClass>(args, out cliArguments))
		{
			// Something wrong, exit or display help?
			CommandLineArguments.DisplayHelp(cliArguments);
			return;
		}

		if (cliArguments.Argument1)
		{
		
		}
	}
}
```

# License

AtleX.CommandLineArguments uses the MIT license, see the LICENSE file.
