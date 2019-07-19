using ClientApp.Controllers.Resources;
using FluentValidation;

namespace ClientApp.Validation
{
    public class RequesterNameResourceValidator : AbstractValidator<RequesterNameResource>
    {
        public RequesterNameResourceValidator()
        {
            RuleFor(n => n.FirstName).NotEmpty()
                .MaximumLength(20);

            RuleFor(n => n.FatherName).NotEmpty()
                .MaximumLength(20);

            RuleFor(n => n.GrandFatherName).NotEmpty()
                .MaximumLength(20);

            RuleFor(n => n.FamilyName).NotEmpty()
                .MaximumLength(20);
        }
    }
}
