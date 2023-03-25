namespace UniqueCodeGenerator;

public class Benchmarks
{
    [Benchmark]
    public void StandartGenerate()
    {
        // ~0,0006 duplication in 10_000_000 takes around ~55-57 seconds
        // ~0,0006 duplication in 1_000_000 takes ~4 seconds
        var sw = Stopwatch.StartNew();
        sw.Start();

        var codes = new ConcurrentBag<string>();

        const int testCount = 1_000_000;

        var (charset, length, _) = new Options();

        Parallel.For(0, testCount, _ => codes.Add(UniqueCodeGenerator.Generate(charset, length)));

        var uniqueCount = codes.Distinct().ToList().Count;

        Console.WriteLine("Unique codes {0}", uniqueCount.ToString());
        Console.WriteLine(uniqueCount == testCount ? "Success" : "Failure");
        Console.WriteLine("took {0} ms", sw.ElapsedMilliseconds.ToString());
        sw.Stop();
    }
    public void ParallelGenerate()
    {
        var sw = Stopwatch.StartNew();
        sw.Start();

        var codes = new ConcurrentBag<string>();

        const int testCount = 1_000_000;

        var (charset, length, _) = new Options();

        Parallel.For(0, testCount, _ => codes.Add(UniqueCodeGenerator.GenerateParallel(charset, length)));

        var uniqueCount = codes.Distinct().ToList().Count;

        Console.WriteLine("Unique codes {0}", uniqueCount.ToString());
        Console.WriteLine(uniqueCount == testCount ? "Success" : "Failure");
        Console.WriteLine("took {0} ms", sw.ElapsedMilliseconds.ToString());
        sw.Stop();
    }
}