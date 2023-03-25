namespace UniqueCodeGenerator;

public static class UniqueCodeGenerator
{
    public static string Generate(string charset, uint length = 8)
    {
        var distinctCharset = charset.Distinct();

        var code = new char[length];

        for (var i = 0; i < length; i++)
        {
            var shuffle = distinctCharset.OrderBy(_ => RandomNumberGenerator.GetInt32(int.MaxValue)).ToArray();

            var randomIndex = RandomNumberGenerator.GetInt32(0, shuffle.Length);
            code[i] = shuffle[randomIndex];
        }

        return new string(code.ToArray());
    }
}