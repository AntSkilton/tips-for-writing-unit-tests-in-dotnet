using FluentAssertions;
using TipsForWritingUnitTests.Models;
using TipsForWritingUnitTests.Validators;
using Xunit;

namespace TipsForWritingUnitTests.UnitTests;

public class CurrencyValidatorTests
{
    private readonly CurrencyValidator _currencyValidator = new();
    
    public static IEnumerable<object[]> GetValidCurrencies()
    {
        yield return [new Currency("GBP", "Great British Pounds", "£")];
        yield return [new Currency("USD", "United States Dollar", "$")];
        yield return [new Currency("EUR", "Euro", "€")];
    }
    
    private Currency Gbp => new("GBP", "Great British Pounds", "£");

    [Theory]
    [MemberData(nameof(GetValidCurrencies))]
    public void PassingModel_Multiple_ValidationSucceeds(Currency currency)
    {
        var result = _currencyValidator.Validate(currency);
        
        result.IsValid.Should().BeTrue();
    }
    
    [Fact]
    public void PassingModel_ValidationSucceeds()
    {
        var result = _currencyValidator.Validate(Gbp);
        
        result.IsValid.Should().BeTrue();
    }
    
    [Fact]
    public void Iso3Code_IsEmpty_ValidationFails()
    {
        var currency = Gbp;
        currency.Iso3Code = "";
        
        var result = _currencyValidator.Validate(currency);
        
        result.Errors.Should().Contain(x => x.ErrorMessage == "'Iso3 Code' must not be empty.");
    }
    
    [Theory]
    [InlineData("US")]
    [InlineData("GB")]
    [InlineData("CA")]
    public void Iso3Code_TooShort_ValidationFails(string isoCode)
    {
        var currency = new Currency(isoCode, "United States Dollar", "$");
        
        var result = _currencyValidator.Validate(currency);
        
        result.Errors.Should().Contain(x => x.ErrorMessage == "Currency Iso 3 too short. Should be 3 characters long.");
    }
    
    [Theory]
    [InlineData("USDA")]
    [InlineData("ITALY")]
    [InlineData("POUND")]
    public void Iso3Code_TooLong_ValidationFails(string isoCode)
    {
        var currency = new Currency(isoCode, "United States Dollar", "$");
        
        var result = _currencyValidator.Validate(currency);
        
        result.Errors.Should().Contain(x => x.ErrorMessage == "Currency Iso 3 too long. Should be 3 characters long.");
    }
}