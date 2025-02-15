namespace TipsForWritingUnitTests.Models;

public class Currency(string iso3Code, string name, string symbol)
{
    public string Name { get; set; } = name;
    public string Iso3Code { get; set; } = iso3Code;
    public string Symbol { get; set; } = symbol;
}
