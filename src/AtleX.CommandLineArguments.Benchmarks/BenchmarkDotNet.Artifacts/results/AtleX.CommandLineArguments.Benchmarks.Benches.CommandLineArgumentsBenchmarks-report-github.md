``` ini

BenchmarkDotNet=v0.10.10, OS=Windows 10 Redstone 2 [1703, Creators Update] (10.0.15063.726)
Processor=Intel Core i7-6820HQ CPU 2.70GHz (Skylake), ProcessorCount=8
Frequency=2648437 Hz, Resolution=377.5812 ns, Timer=TSC
.NET Core SDK=2.0.3
  [Host] : .NET Core 2.0.3 (Framework 4.6.25815.02), 64bit RyuJIT
  Clr    : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2115.0
  Core   : .NET Core 2.0.3 (Framework 4.6.25815.02), 64bit RyuJIT


```
|                                                                                        Method |  Job | Runtime |      Mean |     Error |    StdDev | Scaled |  Gen 0 | Allocated |
|---------------------------------------------------------------------------------------------- |----- |-------- |----------:|----------:|----------:|-------:|-------:|----------:|
|                                  CommandLineArgumentsTryParse_DefaultConfiguration_SuccessFul |  Clr |     Clr | 15.338 us | 0.2063 us | 0.1722 us |   1.00 | 1.1292 |   4.71 KB |
|     CommandLineArgumentsTryParse_WindowsStyleParsersWithoutValidationAndHelpWriter_SuccessFul |  Clr |     Clr |  1.882 us | 0.0107 us | 0.0083 us |   0.12 | 0.2975 |   1.23 KB |
| CommandLineArgumentsTryParse_WindowsStyleParsersWithoutValidationAndWithHelpWriter_SuccessFul |  Clr |     Clr |  1.867 us | 0.0316 us | 0.0296 us |   0.12 | 0.3052 |   1.26 KB |
|                                  CommandLineArgumentsTryParse_DefaultConfiguration_SuccessFul | Core |    Core | 13.144 us | 0.1447 us | 0.1046 us |   1.00 | 1.0681 |   4.42 KB |
|     CommandLineArgumentsTryParse_WindowsStyleParsersWithoutValidationAndHelpWriter_SuccessFul | Core |    Core |  1.887 us | 0.0377 us | 0.0387 us |   0.14 | 0.2995 |   1.23 KB |
| CommandLineArgumentsTryParse_WindowsStyleParsersWithoutValidationAndWithHelpWriter_SuccessFul | Core |    Core |  1.909 us | 0.0104 us | 0.0087 us |   0.15 | 0.3052 |   1.26 KB |
