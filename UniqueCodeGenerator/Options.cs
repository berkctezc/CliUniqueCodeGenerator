namespace UniqueCodeGenerator;

public class Options
{
    [Option('c', "charset", Required = false, HelpText = "Charset to be used in generation")]
    public string Charset { get; set; } = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

    [Option('l', "length", Required = false, HelpText = "Length of the generated code")]
    public uint Length { get; set; } = 36;

    [Option('v', "verbose", Required = false, HelpText = "Non-verbose only prints the generated code. Verbose mode also copies text to your clipboard")]
    public bool Verbose { get; set; } = false;

    public void Deconstruct(out string charset, out uint length, out bool verbose)
        => (charset, length, verbose) = (Charset, Length, Verbose);
}