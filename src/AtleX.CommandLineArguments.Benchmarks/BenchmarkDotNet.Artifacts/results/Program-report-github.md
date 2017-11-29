``` ini

BenchmarkDotNet=v0.10.9, OS=Windows 10 Redstone 2 (10.0.15063)
Processor=Intel Core i7-6820HQ CPU 2.70GHz (Skylake), ProcessorCount=8
Frequency=2648435 Hz, Resolution=377.5815 ns, Timer=TSC
.NET Core SDK=2.0.0
  [Host] : .NET Core 2.0.0 (Framework 4.6.00001.0), 64bit RyuJIT
  Clr    : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2102.0
  Core   : .NET Core 2.0.0 (Framework 4.6.00001.0), 64bit RyuJIT


```
 |    Method |  Job | Runtime |      Mean |     Error |    StdDev |    Median | Allocated |
 |---------- |----- |-------- |----------:|----------:|----------:|----------:|----------:|
 | Benchmark |  Clr |     Clr | 0.0125 ns | 0.0141 ns | 0.0179 ns | 0.0000 ns |       0 B |
 | Benchmark | Core |    Core | 0.0324 ns | 0.0207 ns | 0.0183 ns | 0.0234 ns |       0 B |
