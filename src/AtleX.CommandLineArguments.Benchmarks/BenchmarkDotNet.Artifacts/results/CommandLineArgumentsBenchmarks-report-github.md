``` ini

BenchmarkDotNet=v0.10.9, OS=Windows 10 Redstone 2 (10.0.15063)
Processor=Intel Core i7-6820HQ CPU 2.70GHz (Skylake), ProcessorCount=8
Frequency=2648435 Hz, Resolution=377.5815 ns, Timer=TSC
.NET Core SDK=2.0.0
  [Host] : .NET Core 2.0.0 (Framework 4.6.00001.0), 64bit RyuJIT
  Clr    : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2102.0
  Core   : .NET Core 2.0.0 (Framework 4.6.00001.0), 64bit RyuJIT


```
 |                                                                                        Method |  Job | Runtime |      Mean |     Error |    StdDev |    Median | Scaled |  Gen 0 | Allocated |
 |---------------------------------------------------------------------------------------------- |----- |-------- |----------:|----------:|----------:|----------:|-------:|-------:|----------:|
 |                                  CommandLineArgumentsTryParse_DefaultConfiguration_SuccessFul |  Clr |     Clr | 17.040 us | 0.3410 us | 0.6060 us | 17.141 us |   1.00 | 1.0986 |    4.6 KB |
 |     CommandLineArgumentsTryParse_WindowsStyleParsersWithoutValidationAndHelpWriter_SuccessFul |  Clr |     Clr |  2.603 us | 0.0392 us | 0.0328 us |  2.602 us |   0.15 | 0.2708 |   1.12 KB |
 | CommandLineArgumentsTryParse_WindowsStyleParsersWithoutValidationAndWithHelpWriter_SuccessFul |  Clr |     Clr |  2.526 us | 0.0497 us | 0.0697 us |  2.485 us |   0.15 | 0.2785 |   1.15 KB |
 |                                  CommandLineArgumentsTryParse_DefaultConfiguration_SuccessFul | Core |    Core | 14.170 us | 0.2721 us | 0.3133 us | 14.297 us |   1.00 | 1.0529 |   4.31 KB |
 |     CommandLineArgumentsTryParse_WindowsStyleParsersWithoutValidationAndHelpWriter_SuccessFul | Core |    Core |  2.444 us | 0.0249 us | 0.0208 us |  2.443 us |   0.17 | 0.2708 |   1.12 KB |
 | CommandLineArgumentsTryParse_WindowsStyleParsersWithoutValidationAndWithHelpWriter_SuccessFul | Core |    Core |  2.429 us | 0.0483 us | 0.0677 us |  2.461 us |   0.17 | 0.2785 |   1.15 KB |
