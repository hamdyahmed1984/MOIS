using System;
using ClientApp.Controllers.Resources;
using FluentValidation;

namespace ClientApp.Validation
{
    public class MarriageDocResourceValidator : AbstractValidator<MarriageDocResourceIn>
    {
        public MarriageDocResourceValidator()
        {
            /*We need to add this validation rule when we allow creating birth docs directly*/
            //RuleFor(c => c.RequestId).NotEmpty();

            //RuleFor(c => c.NumberOfCopies).NotEmpty();

            RuleFor(c => c.Name).NotEmpty();

            RuleFor(c => c.NID).NotEmpty();

            RuleFor(n => n.SpouseFullName)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(c => c.RelationId).NotEmpty();
        }
    }
}