using Firmabul.Core.DTOs;
using FluentValidation;

namespace Firmabul.Service.Validations;

public class CompanyDtoValidator : AbstractValidator<CompanyDto>
{
    public CompanyDtoValidator()
    {
        RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");

        RuleFor(x => x.SectorId).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be grater 0");
    }
}