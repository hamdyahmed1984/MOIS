using ClientApp.Validation;
using Xunit;
using FluentValidation.TestHelper;
using ClientApp.Controllers.Resources;

namespace ClientApp.Tests.FluentValidationTests
{
    public class RequesterNameResourceValidatorTests
    {
        [Fact]
        public void ShouldHaveError_WhenAnyPropertyIsNull()
        {
            //Arrange
            var requesterNameValidator = new RequesterNameResourceValidator();
            var requesterNameResource = new RequesterNameResource();

            //Act
            //Assert
            requesterNameValidator.ShouldHaveValidationErrorFor(a => a.FirstName, requesterNameResource);
            requesterNameValidator.ShouldHaveValidationErrorFor(a => a.FatherName, requesterNameResource);
            requesterNameValidator.ShouldHaveValidationErrorFor(a => a.GrandFatherName, requesterNameResource);
            requesterNameValidator.ShouldHaveValidationErrorFor(a => a.FamilyName, requesterNameResource);
        }

        [Fact]
        public void ShouldHaveError_WhenAnyPropertyExceedsMaxLength()
        {
            //Arrange
            var requesterNameValidator = new RequesterNameResourceValidator();
            var requesterNameResource = new RequesterNameResource
            {
                FirstName = StringExtensions.RandomString(21),
                FatherName = StringExtensions.RandomString(21),
                GrandFatherName = StringExtensions.RandomString(21),
                FamilyName = StringExtensions.RandomString(21)
            };

            //Act
            //Assert
            requesterNameValidator.ShouldHaveValidationErrorFor(a => a.FirstName, requesterNameResource);
            requesterNameValidator.ShouldHaveValidationErrorFor(a => a.FatherName, requesterNameResource);
            requesterNameValidator.ShouldHaveValidationErrorFor(a => a.GrandFatherName, requesterNameResource);
            requesterNameValidator.ShouldHaveValidationErrorFor(a => a.FamilyName, requesterNameResource);
        }
    }
}
