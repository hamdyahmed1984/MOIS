using System;
using ClientApp.Controllers.Resources;
using FluentValidation;

namespace ClientApp.Validation
{
    public class DeathDocResourceValidator : AbstractValidator<DeathDocResourceIn>
    {
        public DeathDocResourceValidator()
        {
            /*We need to add this validation rule when we allow creating birth docs directly*/
            //RuleFor(c => c.RequestId).NotEmpty();

            //RuleFor(c => c.NumberOfCopies).NotEmpty();            

            RuleFor(c => c.Name).NotEmpty();

            //NID in death record is not mandatory
            //RuleFor(c => c.NID).NotEmpty();

            RuleFor(n => n.MotherFullName)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(c => c.GenderId).NotEmpty();
            RuleFor(c => c.RelationId).NotEmpty();

            //RuleFor(b => b).Must(x => ValidateGenderIdAndCode(x.GenderId, x.GenderCode));

            //RuleFor(b => b).Must(x => ValidateRelationIdAndCode(x.RelationId, x.RelationCode));
        }

        //private bool ValidateRelationIdAndCode(int relationId, string relationCode) => relationId != 0 || !string.IsNullOrWhiteSpace(relationCode);

        //private bool ValidateGenderIdAndCode(int genderId, string genderCode) => genderId != 0 || !string.IsNullOrWhiteSpace(genderCode);
    }
}