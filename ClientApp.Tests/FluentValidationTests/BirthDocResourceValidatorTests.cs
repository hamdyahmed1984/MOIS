using ClientApp.Validation;
using Xunit;
using FluentValidation;
using FluentValidation.TestHelper;
using ClientApp.Controllers.Resources;

namespace ClientApp.Tests.FluentValidationTests
{
    public class BirthDocResourceValidatorTests
    {
        [Fact]
        public void ShouldHaveError_WhenAnyPropertyIsNull()
        {
            //Arrange
            var validator = new BirthDocResourceValidator();
            var birthDocResourceIn = new BirthDocResourceIn();

            //Act
            //Assert
            validator.ShouldHaveValidationErrorFor(a => a.Name, birthDocResourceIn);
            validator.ShouldHaveValidationErrorFor(a => a.MotherFullName, birthDocResourceIn);
            validator.ShouldHaveValidationErrorFor(a => a.GenderId, birthDocResourceIn);
            validator.ShouldHaveValidationErrorFor(a => a.RelationId, birthDocResourceIn);
        }

        [Fact]
        public void ShouldHaveError_WhenMotherFullNameExceedsaxLength()
        {
            //Arrange
            var validator = new BirthDocResourceValidator();
            var birthDocResourceIn = new BirthDocResourceIn() { MotherFullName = StringExtensions.RandomString(101)};

            //Act
            //Assert
            validator.ShouldHaveValidationErrorFor(a => a.MotherFullName, birthDocResourceIn);
        }

        [Fact]
        public void ShouldHaveError_WhenNotFirstTimeAndNidIsNull()
        {
            //Arrange
            var validator = new BirthDocResourceValidator();
            var birthDocResourceIn = new BirthDocResourceIn()
            {
                IsFirstTime = false,
                Name = new RequesterNameResource(),
                MotherFullName = "mother",
                GenderId = 1,
                RelationId = 1
            };

            //Act
            //Assert
            var result = validator.Validate(birthDocResourceIn);
            Assert.Equal(1, result.Errors.Count);
        }

        [Fact]
        public void ShouldNotHaveError_WhenNotFirstTimeAndNidIsNotNull()
        {
            //Arrange
            var validator = new BirthDocResourceValidator();
            var birthDocResourceIn = new BirthDocResourceIn() {
                IsFirstTime = false,
                Name = new RequesterNameResource(),
                MotherFullName = "mother",
                NID = new NIDResource() { NationalIdenNumber = "28410071402991"},
                GenderId = 1,
                RelationId = 1
            };

            //Act
            //Assert
            var result = validator.Validate(birthDocResourceIn);
            Assert.Equal(0, result.Errors.Count);
        }
    }
}
