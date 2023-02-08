namespace UniqueCodeGenerator;

public static class UniqueCodeGenerator
{
    public static string Generate(string charset, uint length = 8)
    {
        var code = new char[length];

        for (var i = 0; i < length; i++)
        {
            var shuffle = charset.OrderBy(_ => Random.Shared.Next()).ToArray();
            var randomIndex = Random.Shared.Next(0, shuffle.Length);
            code[i] = shuffle[randomIndex];
        }

        return new string(code.ToArray());
    }
}