using ClientApp.Validation;
using Xunit;
using FluentValidation.TestHelper;
using ClientApp.Controllers.Resources;

namespace ClientApp.Tests.FluentValidationTests
{
    public class DivorceDocResourceValidatorTests
    {
        [Fact]
        public void ShouldHaveError_WhenAnyPropertyIsNull()
        {
            //Arrange
            var validator = new DivorceDocResourceValidator();
            var divorceDocResourceIn = new DivorceDocResourceIn();

            //Act
            //Assert
            validator.ShouldHaveValidationErrorFor(a => a.Name, divorceDocResourceIn);
            validator.ShouldHaveValidationErrorFor(a => a.NID, divorceDocResourceIn);
            validator.ShouldHaveValidationErrorFor(a => a.SpouseFullName, divorceDocResourceIn);
            validator.ShouldHaveValidationErrorFor(a => a.RelationId, divorceDocResourceIn);
        }

        [Fact]
        public void ShouldHaveError_WhenSpouseFullNameExceedsaxLength()
        {
            //Arrange
            var validator = new DivorceDocResourceValidator();
            var divorceDocResourceIn = new DivorceDocResourceIn() { SpouseFullName = StringExtensions.RandomString(101) };

            //Act
            //Assert
            validator.ShouldHaveValidationErrorFor(a => a.SpouseFullName, divorceDocResourceIn);
        }
    }
}
