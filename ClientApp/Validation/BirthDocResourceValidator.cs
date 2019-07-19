using System;
using ClientApp.Controllers.Resources;
using FluentValidation;

namespace ClientApp.Validation
{
    public class BirthDocResourceValidator : AbstractValidator<BirthDocResourceIn>
    {
        public BirthDocResourceValidator()
        {
            /*We need to add this validation rule when we allow creating birth docs directly*/
            //RuleFor(c => c.RequestId).NotEmpty();

            //RuleFor(c => c.NumberOfCopies).NotEmpty();

            RuleFor(c => c.GenderId).NotEmpty();
            RuleFor(c => c.RelationId).NotEmpty();
            RuleFor(c => c.Name).NotEmpty();            

            RuleFor(n => n.MotherFullName)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(birthDoc => birthDoc).Must(x => ValidateNidFirstTime(x)).WithMessage("If the birth doc is not for first time, you have to provide the NID");

            //RuleFor(b => b).Must(x => ValidateGenderIdAndCode(x.GenderId, x.GenderCode));

            //RuleFor(b => b).Must(x => ValidateRelationIdAndCode(x.RelationId, x.RelationCode));                   
    }

        private bool ValidateNidFirstTime(BirthDocResource birthDoc)
        {
            return birthDoc.IsFirstTime || !birthDoc.IsFirstTime && birthDoc.NID != null;
        }

        //private bool ValidateRelationIdAndCode(int relationId, string relationCode) => relationId != 0 || !string.IsNullOrWhiteSpace(relationCode);

        //private bool ValidateGenderIdAndCode(int genderId, string genderCode) => genderId != 0 || !string.IsNullOrWhiteSpace(genderCode);
    }
}