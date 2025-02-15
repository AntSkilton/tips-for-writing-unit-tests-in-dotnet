using TipsForWritingUnitTests.Models;

namespace TipsForWritingUnitTests.Services;

public class CurrencyService : ICurrencyService
{
    public Task<Currency> FetchCurrencyDataAsync()
    {
        var result = new Currency("", "","");
        
        // Speak with repository and get some data about the currency for example.
        
        return Task.FromResult(result);
    }
}