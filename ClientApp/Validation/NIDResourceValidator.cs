using ClientApp.Controllers.Resources;
using Domain.ValueObjects;
using FluentValidation;
using System;

namespace ClientApp.Validation
{
    public class NIDResourceValidator : AbstractValidator<NIDResource>
    {
        public NIDResourceValidator()
        {
            //We should have these validation rules in order or we will get an exception in the constructor of NID in case the NId is invalid
            //And we have to set CascadeMode.StopOnFirstFailure
            RuleFor(nid => nid.NationalIdenNumber)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .Length(14)
                .Matches(@"^\d{14}$")
                .Must(nid => new NID(nid).IsNidValid());
        }
    }
}
