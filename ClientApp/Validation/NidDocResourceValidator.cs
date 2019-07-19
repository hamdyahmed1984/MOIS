using System;
using ClientApp.Controllers.Resources;
using FluentValidation;

namespace ClientApp.Validation
{
    public class NidDocResourceValidator : AbstractValidator<NidDocResourceIn>
    {
        public NidDocResourceValidator()
        {
            /*We need to add this validation rule when we allow creating birth docs directly*/
            //RuleFor(c => c.RequestId).NotEmpty();
            //RuleFor(c => c.NumberOfCopies).NotEmpty();

            RuleFor(c => c.Name).NotEmpty();
            
            RuleFor(c => c.JobTypeNIDId).NotEmpty();
            RuleFor(c => c.NidIssueReasonId).NotEmpty();
            RuleFor(c => c.JobName).NotEmpty().MaximumLength(100);
        }
    }
}