using ClientApp.Controllers.Resources;
using FluentValidation;

namespace ClientApp.Validation
{
    public class ContactDetailsResourceValidator : AbstractValidator<ContactDetailsResource>
    {
        public ContactDetailsResourceValidator()
        {
            RuleFor(c => c.Email).NotEmpty()
                .MaximumLength(50)
                .EmailAddress();

            RuleFor(c => c.Mobile1).NotEmpty()
                .MaximumLength(20)
                .Matches(@"^01\d{9}$");

            RuleFor(c => c.Mobile2)
                .MaximumLength(20)
                .Matches(@"^01\d{9}$").Unless(c=> string.IsNullOrWhiteSpace(c.Mobile2));

            RuleFor(c => c.PhoneHome).MaximumLength(20).Unless(c => string.IsNullOrWhiteSpace(c.PhoneHome));
            RuleFor(c => c.PhoneWork).MaximumLength(20).Unless(c => string.IsNullOrWhiteSpace(c.PhoneWork));
        }
    }
}
