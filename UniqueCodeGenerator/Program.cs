namespace UniqueCodeGenerator;

public static class Program
{
    public static void Main(string[] args)
    {
        var (charset, length) = Parser.Default.ParseArguments<Options>(args).Value;

        Console.WriteLine("Generating {0} lenght unique code with given charset '{1}'", length.ToString(), charset);

        var generatedCode = UniqueCodeGenerator.Generate(charset, length);

        Console.WriteLine("Generated code and copied to your clipboard \n{0}\nPress any key to exit", generatedCode);
        TextCopy.ClipboardService.SetText(generatedCode);

        Console.ReadKey();
        // BenchmarkRunner.Run<Benchmarks>();
    }
}