using ClientApp.Controllers.Resources;
using FluentValidation;

namespace ClientApp.Validation
{
    public class RequestResourceInValidator : AbstractValidator<RequestResourceIn>
    {
        public RequestResourceInValidator()
        {
            RuleFor(r => r.Name).NotEmpty();
            //RuleFor(r => r.Code).NotEmpty()
            //    .MaximumLength(20);

            RuleFor(r => r.MotherFullName).NotEmpty()
                .MaximumLength(50);

            RuleFor(r => r.GenderId).NotEmpty();

            //RuleFor(r => r.IssuerId).NotEmpty();

            //RuleFor(r => r.PaymentMethodId).NotEmpty();

            RuleFor(r => r.ContactDetails).NotEmpty();
            RuleFor(r => r.ResidencyAddress).NotEmpty();
            RuleFor(r => r.DeliveryAddress).NotEmpty();
        }
    }
}