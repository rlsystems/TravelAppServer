using ServerApp.Application.Common.Validators;
using ServerApp.Shared.DTOs.Catalog;
using FluentValidation;

namespace ServerApp.Application.Catalog.Validators;

public class UpdateBrandRequestValidator : CustomValidator<UpdateBrandRequest>
{
    public UpdateBrandRequestValidator()
    {
        RuleFor(p => p.Name).MaximumLength(75).NotEmpty();
    }
}