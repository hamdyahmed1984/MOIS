using Domain.Exceptions;
using System;
using System.Collections.Generic;

namespace Domain.ValueObjects
{
    public sealed class RequesterName: ValueObject
    {

        public string FirstName { get; private set; }
        public string FatherName { get; private set; }
        public string GrandFatherName { get; private set; }
        public string FamilyName { get; private set; }
        public string FullName { get; private set; }

        private RequesterName() { }
        public RequesterName(string firstName, string fatherName, string grandfatherName, string familyName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ShouldNotBeEmptyException("The 'firstName' field is required");
            if (string.IsNullOrWhiteSpace(fatherName))
                throw new ShouldNotBeEmptyException("The 'fatherName' field is required");
            if (string.IsNullOrWhiteSpace(grandfatherName))
                throw new ShouldNotBeEmptyException("The 'grandfatherName' field is required");
            if (string.IsNullOrWhiteSpace(familyName))
                throw new ShouldNotBeEmptyException("The 'familyName' field is required");

            FirstName = firstName;
            FatherName = fatherName;
            GrandFatherName = grandfatherName;
            FamilyName = familyName;
            FullName = this.ToString();
        }

        public override string ToString()
        {
            return $"{FirstName} {FatherName} {GrandFatherName} {FamilyName}";
        }      

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return FirstName;
            yield return FatherName;
            yield return GrandFatherName;
            yield return FamilyName;
        }
    }
}
