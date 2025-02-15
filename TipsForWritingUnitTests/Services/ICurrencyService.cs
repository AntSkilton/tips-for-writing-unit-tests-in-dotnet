using TipsForWritingUnitTests.Models;

namespace TipsForWritingUnitTests.Services;

public interface ICurrencyService
{ 
    Task<Currency> FetchCurrencyDataAsync();   
}