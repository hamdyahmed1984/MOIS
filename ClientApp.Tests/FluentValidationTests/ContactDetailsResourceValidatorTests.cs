using ClientApp.Validation;
using Xunit;
using FluentValidation.TestHelper;
using ClientApp.Controllers.Resources;

namespace ClientApp.Tests.FluentValidationTests
{
    public class ContactDetailsResourceValidatorTests
    {
        [Fact]
        public void ShouldHaveError_WhenAnyPropertyIsNull()
        {
            //Arrange
            var validator = new ContactDetailsResourceValidator();
            var contactDetailsResource = new ContactDetailsResource();

            //Act
            //Assert
            validator.ShouldHaveValidationErrorFor(a => a.Email, contactDetailsResource);
            validator.ShouldHaveValidationErrorFor(a => a.Mobile1, contactDetailsResource);
        }

        [Fact]
        public void ShouldHaveError_WhenAnyPropertyExceedsMaxLength()
        {
            //Arrange
            var validator = new ContactDetailsResourceValidator();
            var contactDetailsResource = new ContactDetailsResource
            {
                Email = StringExtensions.RandomString(51)+"@h.h",
                Mobile1="0100986873422",
                Mobile2 = "0100986873422",
                PhoneHome = StringExtensions.RandomString(21),
                PhoneWork = StringExtensions.RandomString(21)
            };

            //Act
            //Assert
            validator.ShouldHaveValidationErrorFor(a => a.Email, contactDetailsResource);
            validator.ShouldHaveValidationErrorFor(a => a.Mobile1, contactDetailsResource);
            validator.ShouldHaveValidationErrorFor(a => a.Mobile2, contactDetailsResource);
            validator.ShouldHaveValidationErrorFor(a => a.PhoneHome, contactDetailsResource);
            validator.ShouldHaveValidationErrorFor(a => a.PhoneWork, contactDetailsResource);
        }

        [Fact]
        public void ShouldHaveError_WhenMobile1OrMobile2NotMatchedTheFormat()
        {
            //Arrange
            var validator = new ContactDetailsResourceValidator();
            var contactDetailsResource = new ContactDetailsResource
            {
                Mobile1 = "0100986873422",
                Mobile2 = "0100986873422"
            };

            //Act
            //Assert
            validator.ShouldHaveValidationErrorFor(a => a.Mobile1, contactDetailsResource);
            validator.ShouldHaveValidationErrorFor(a => a.Mobile2, contactDetailsResource);
        }

        [Fact]
        public void ShouldNotHaveError_WhenOptionalPropertiesAreNull()
        {
            //Arrange
            var validator = new ContactDetailsResourceValidator();
            var contactDetailsResource = new ContactDetailsResource
            {
                Mobile2 = null,
                PhoneHome = "",
                PhoneWork = null
            };

            //Act
            //Assert
            validator.ShouldNotHaveValidationErrorFor(a => a.Mobile2, contactDetailsResource);
            validator.ShouldNotHaveValidationErrorFor(a => a.PhoneHome, contactDetailsResource);
            validator.ShouldNotHaveValidationErrorFor(a => a.PhoneWork, contactDetailsResource);
        }
    }
}
