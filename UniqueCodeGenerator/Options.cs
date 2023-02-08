namespace UniqueCodeGenerator;

public class Options
{
    [Option('c', "charset", Required = true, HelpText = "Charset to be used in generation")]
    public string Charset { get; set; }

    [Option('l', "length", Required = true, HelpText = "Length of the generated code")]
    public uint Length { get; set; }

    public void Deconstruct(out string charset, out uint length)
        => (charset, length) = (Charset, Length);
}