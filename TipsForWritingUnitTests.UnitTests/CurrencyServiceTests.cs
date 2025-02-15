using FluentAssertions;
using NSubstitute;
using TipsForWritingUnitTests.Models;
using TipsForWritingUnitTests.Services;
using Xunit;

namespace TipsForWritingUnitTests.UnitTests;

public class CurrencyServiceTests
{
    private readonly ICurrencyService _currencyService = Substitute.For<ICurrencyService>();

    [Fact]
    public async Task Service_ReturnsCurrency_ValidationSucceeds()
    {
        var expectedCurrency = new Currency("USD", "United States Dollar", "$");
        _currencyService.FetchCurrencyDataAsync().Returns(Task.FromResult(expectedCurrency));
        
        var result = await _currencyService.FetchCurrencyDataAsync();

        result.Should().NotBeNull();
        result.Iso3Code.Should().Be("USD");
        result.Name.Should().Be("United States Dollar");
        result.Symbol.Should().Be("$");
    }
}