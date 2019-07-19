using ClientApp.Controllers.Resources;
using FluentValidation;

namespace ClientApp.Validation
{
    public class CsrResourceValidator : AbstractValidator<CsrResource>
    {
        public CsrResourceValidator()
        {
            RuleFor(c => c.RequestId).NotEmpty();

            RuleFor(r => r.IssueDestination)
                .NotEmpty()
                .MaximumLength(100);
        }
    }
}