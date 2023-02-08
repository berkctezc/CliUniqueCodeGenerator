namespace UniqueCodeGenerator;

public class Benchmarks
{
    [Benchmark]
    public void Test()
    {
        // ~0,0006 duplication in 10_000_000 takes around ~55-57 seconds
        // ~0,0006 duplication in 1_000_000 takes ~4 seconds
        var sw = Stopwatch.StartNew();
        sw.Start();

        var codes = new ConcurrentBag<string>();

        const int testCount = 1_000_000;

        const string charset = "ACDEFGHKLMNPRTXYZ234579";

        Parallel.For(0, testCount, _ => codes.Add(UniqueCodeGenerator.Generate(charset)));

        var uniqueCount = codes.Distinct().ToList().Count;

        Console.WriteLine("Unique codes {0}", uniqueCount.ToString());
        Console.WriteLine((uniqueCount == testCount) ? "Success" : "Failure");
        Console.WriteLine("took {0} ms", sw.ElapsedMilliseconds.ToString());
        sw.Stop();
    }
}