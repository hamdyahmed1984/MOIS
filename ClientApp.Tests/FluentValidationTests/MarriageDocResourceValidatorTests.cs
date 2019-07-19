using ClientApp.Validation;
using Xunit;
using FluentValidation.TestHelper;
using ClientApp.Controllers.Resources;

namespace ClientApp.Tests.FluentValidationTests
{
    public class MarriageDocResourceValidatorTests
    {
        [Fact]
        public void ShouldHaveError_WhenAnyPropertyIsNull()
        {
            //Arrange
            var validator = new MarriageDocResourceValidator();
            var marriageDocResourceIn = new MarriageDocResourceIn();

            //Act
            //Assert
            validator.ShouldHaveValidationErrorFor(a => a.Name, marriageDocResourceIn);
            validator.ShouldHaveValidationErrorFor(a => a.NID, marriageDocResourceIn);
            validator.ShouldHaveValidationErrorFor(a => a.SpouseFullName, marriageDocResourceIn);
            validator.ShouldHaveValidationErrorFor(a => a.RelationId, marriageDocResourceIn);
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
