using ClientApp.Validation;
using Xunit;
using FluentValidation.TestHelper;
using ClientApp.Controllers.Resources;

namespace ClientApp.Tests.FluentValidationTests
{
    public class DeathDocResourceValidatorTests
    {
        [Fact]
        public void ShouldHaveError_WhenAnyPropertyIsNull()
        {
            //Arrange
            var validator = new DeathDocResourceValidator();
            var deathDocResourceIn = new DeathDocResourceIn();

            //Act
            //Assert
            validator.ShouldHaveValidationErrorFor(a => a.Name, deathDocResourceIn);
            validator.ShouldHaveValidationErrorFor(a => a.MotherFullName, deathDocResourceIn);
            validator.ShouldHaveValidationErrorFor(a => a.GenderId, deathDocResourceIn);
            validator.ShouldHaveValidationErrorFor(a => a.RelationId, deathDocResourceIn);
        }

        [Fact]
        public void ShouldHaveError_WhenMotherFullNameExceedsaxLength()
        {
            //Arrange
            var validator = new DeathDocResourceValidator();
            var deathDocResourceIn = new DeathDocResourceIn() { MotherFullName = StringExtensions.RandomString(101) };

            //Act
            //Assert
            validator.ShouldHaveValidationErrorFor(a => a.MotherFullName, deathDocResourceIn);
        }
    }
}
