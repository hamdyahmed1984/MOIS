
using ClientApp.Validation;
using Xunit;
using FluentValidation.TestHelper;
using ClientApp.Controllers.Resources;

namespace ClientApp.Tests.FluentValidationTests
{
    public class RequesterResourceInValidatorTests
    {
        [Fact]
        public void ShouldHaveError_WhenAnyPropertyIsNull()
        {
            //Arrange
            var requesterValidator = new RequestResourceInValidator();
            var requesterResourceIn = new RequestResourceIn();

            //Act
            //Assert
            requesterValidator.ShouldHaveValidationErrorFor(a => a.GenderId, requesterResourceIn);
            requesterValidator.ShouldHaveValidationErrorFor(a => a.Name, requesterResourceIn);
            requesterValidator.ShouldHaveValidationErrorFor(a => a.MotherFullName, requesterResourceIn);
            requesterValidator.ShouldHaveValidationErrorFor(a => a.ContactDetails, requesterResourceIn);
            requesterValidator.ShouldHaveValidationErrorFor(a => a.ResidencyAddress, requesterResourceIn);
            requesterValidator.ShouldHaveValidationErrorFor(a => a.DeliveryAddress, requesterResourceIn);
        }

        [Fact]
        public void ShouldHaveError_WhenMotherFullNameExceedsMaxLength()
        {
            //Arrange
            var requesterValidator = new RequestResourceInValidator();
            var requesterResourceIn = new RequestResourceIn
            {
                MotherFullName = StringExtensions.RandomString(51)
            };

            //Act
            //Assert
            requesterValidator.ShouldHaveValidationErrorFor(a => a.MotherFullName, requesterResourceIn);
        }
    }
}
