using ServerApp.Application.Common.Validators;
using ServerApp.Shared.DTOs.Catalog;
using FluentValidation;

namespace ServerApp.Application.Catalog.Validators;

public class CreateBrandRequestValidator : CustomValidator<CreateBrandRequest>
{
    public CreateBrandRequestValidator()
    {
        RuleFor(p => p.Name).MaximumLength(75).NotEmpty();
    }
}