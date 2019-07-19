using ClientApp.Validation;
using Xunit;
using FluentValidation.TestHelper;
using ClientApp.Controllers.Resources;

namespace ClientApp.Tests.FluentValidationTests
{
    public class AddressResourceInValidatorTests
    {
        [Fact]
        public void ShouldHaveError_WhenAnyPropertyIsNull()
        {
            //Arrange
            var validator = new AddressResourceInValidator();
            var addressResourceIn = new AddressResourceIn();

            //Act
            //Assert
            validator.ShouldHaveValidationErrorFor(a => a.BuildingNumber, addressResourceIn);
            validator.ShouldHaveValidationErrorFor(a => a.DistrictName, addressResourceIn);
            validator.ShouldHaveValidationErrorFor(a => a.FlatNumber, addressResourceIn);
            validator.ShouldHaveValidationErrorFor(a => a.FloorNumber, addressResourceIn);
            validator.ShouldHaveValidationErrorFor(a => a.GovernorateId, addressResourceIn);
            validator.ShouldHaveValidationErrorFor(a => a.PostalCodeId, addressResourceIn);
            validator.ShouldHaveValidationErrorFor(a => a.PoliceDepartmentId, addressResourceIn);
            validator.ShouldHaveValidationErrorFor(a => a.StreetName, addressResourceIn);
        }

        [Fact]
        public void ShouldHaveError_WhenAnyPropertyExceedsMaxLength()
        {
            //Arrange
            var validator = new AddressResourceInValidator();
            var addressResourceIn = new AddressResourceIn
            {
                BuildingNumber = StringExtensions.RandomString(21),
                StreetName = StringExtensions.RandomString(51),
                DistrictName = StringExtensions.RandomString(51)
            };

            //Act
            //Assert
            validator.ShouldHaveValidationErrorFor(a => a.BuildingNumber, addressResourceIn);
            validator.ShouldHaveValidationErrorFor(a => a.StreetName, addressResourceIn);
            validator.ShouldHaveValidationErrorFor(a => a.DistrictName, addressResourceIn);
        }
    }
}
