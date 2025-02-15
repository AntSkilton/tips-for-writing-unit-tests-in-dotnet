using FluentValidation;
using TipsForWritingUnitTests.Models;

namespace TipsForWritingUnitTests.Validators;

public class CurrencyValidator : AbstractValidator<Currency>
{
    public CurrencyValidator()
    {
        RuleFor(x => x.Iso3Code)
            .NotEmpty();

        RuleFor(x => x.Iso3Code)
            .MaximumLength(3)
            .WithMessage("Currency Iso 3 too long. Should be 3 characters long.")
            
            .MinimumLength(3)
            .WithMessage("Currency Iso 3 too short. Should be 3 characters long.");
    }
}