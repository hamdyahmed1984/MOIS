using ClientApp.Validation;
using Xunit;
using FluentValidation.TestHelper;
using ClientApp.Controllers.Resources;

namespace ClientApp.Tests.FluentValidationTests
{
    public class NIDResourceValidatorTests
    {
        [Fact]
        public void ShouldHaveError_WhenNationalIdenNumberIsNull()
        {
            //Arrange
            var validator = new NIDResourceValidator();
            var nIDResource = new NIDResource();

            //Act
            //Assert
            validator.ShouldHaveValidationErrorFor(a => a.NationalIdenNumber, nIDResource);
        }

        [Fact]
        public void ShouldHaveError_WhenNationalIdenNumberExceedsMaxLength()
        {
            //Arrange
            var validator = new NIDResourceValidator();
            var nIDResource = new NIDResource() { NationalIdenNumber = StringExtensions.RandomString(15)};

            //Act
            //Assert
            validator.ShouldHaveValidationErrorFor(a => a.NationalIdenNumber, nIDResource);
        }

        [Fact]
        public void ShouldHaveError_WhenNationalIdenNumberDoesNotMatchExpression()
        {
            //Arrange
            var validator = new NIDResourceValidator();
            var nIDResource = new NIDResource() { NationalIdenNumber = "123" };

            //Act
            //Assert
            validator.ShouldHaveValidationErrorFor(a => a.NationalIdenNumber, nIDResource);
        }

        [Fact]
        public void ShouldHaveError_WhenNationalIdenNumberIsNotValod()
        {
            //Arrange
            var validator = new NIDResourceValidator();
            var nIDResource = new NIDResource() { NationalIdenNumber = "12345678912345" };

            //Act
            //Assert
            validator.ShouldHaveValidationErrorFor(a => a.NationalIdenNumber, nIDResource);
        }
    }
}
