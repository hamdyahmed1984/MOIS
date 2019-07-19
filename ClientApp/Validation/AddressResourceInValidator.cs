using ClientApp.Controllers.Resources;
using Domain.Entities;
using FluentValidation;

namespace ClientApp.Validation
{
    public class AddressResourceInValidator : AbstractValidator<AddressResourceIn>
    {
        public AddressResourceInValidator()
        {
            RuleFor(a => a.FlatNumber).NotEmpty();

            RuleFor(a => a.FloorNumber).NotEmpty();

            RuleFor(a => a.BuildingNumber).NotEmpty()
                .MaximumLength(20);

            RuleFor(a => a.StreetName).NotEmpty()
                .MaximumLength(50);

            RuleFor(a => a.DistrictName).NotEmpty()
                .MaximumLength(50);

            RuleFor(a => a.GovernorateId).NotEmpty();

            RuleFor(a => a.PoliceDepartmentId).NotEmpty();

            RuleFor(a => a.PostalCodeId).NotEmpty();
        }
    }
}
