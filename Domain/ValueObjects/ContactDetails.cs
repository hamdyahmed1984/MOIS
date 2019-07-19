using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Domain.ValueObjects
{
    public sealed class ContactDetails : ValueObject
    {
        public string Mobile1 { get; private set; }
        public string Mobile2 { get; private set; }
        public string PhoneHome { get; private set; }
        public string PhoneWork { get; private set; }
        public string Email { get; private set; }

        const string RegExForMobileValidation = @"^01\d{9}$";
        const string RegExForEmailValidation = @"^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$";

        private ContactDetails() { }
        public ContactDetails(string mobile1, string mobile2, string phoneHome, string phoneWork, string email)
        {
            if (string.IsNullOrWhiteSpace(mobile1))
                throw new ShouldNotBeEmptyException("The 'mobile1' field is required");
            if (string.IsNullOrWhiteSpace(email))
                throw new ShouldNotBeEmptyException("The 'email' field is required");

            Regex regex = new Regex(RegExForMobileValidation);
            Match match = regex.Match(mobile1);
            if (!match.Success)
                throw new InvalidFormatException("Invalid Mobile1 format. Use 11 digits.");

            if (!string.IsNullOrWhiteSpace(mobile2))
            {
                match = regex.Match(mobile2);
                if (!match.Success)
                    throw new InvalidFormatException("Invalid Mobile2 format. Use 11 digits.");
            }

            regex = new Regex(RegExForEmailValidation);
            match = regex.Match(email);
            if (!match.Success)
                throw new InvalidFormatException("Invalid email format.");

            Mobile1 = mobile1;
            Mobile2 = mobile2;
            PhoneHome = phoneHome;
            PhoneWork = phoneWork;
            Email = email;
        }

        public override string ToString()
        {
            return $"Email: {Email}, Mobile1: {Mobile1}, Mobile2: {Mobile2}, Home Phone: {PhoneHome}, Work Phone: {PhoneWork}";
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Mobile1;
            yield return Mobile2;
            yield return PhoneHome;
            yield return PhoneWork;
            yield return Email;
        }
    }
}
