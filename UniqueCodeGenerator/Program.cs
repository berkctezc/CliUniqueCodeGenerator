var (charset, length, verbose) = Parser.Default.ParseArguments<Options>(args).Value;

Stopwatch? sw = null;

if (verbose)
    sw = Stopwatch.StartNew();

var generatedCode = UniqueCodeGenerator.UniqueCodeGenerator.Generate(charset, length);

Console.WriteLine(generatedCode);

if (sw is not null)
{
    sw.Stop();

    Console.WriteLine("Generating {0} lenght unique code with given charset '{1}'", length.ToString(), charset);

    TextCopy.ClipboardService.SetText(generatedCode);

    Console.WriteLine("Generated code and copied to your clipboard in {0} ms\n{1}\nPress any key to exit", sw.ElapsedMilliseconds.ToString(), generatedCode);

    Console.ReadKey();
}

// BenchmarkDotNet.Running.BenchmarkRunner.Run<Benchmarks>();