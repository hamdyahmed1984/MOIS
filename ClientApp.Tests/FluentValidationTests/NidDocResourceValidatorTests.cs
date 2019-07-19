using ClientApp.Validation;
using Xunit;
using FluentValidation.TestHelper;
using ClientApp.Controllers.Resources;

namespace ClientApp.Tests.FluentValidationTests
{
    public class NidDocResourceValidatorTests
    {
        [Fact]
        public void ShouldHaveError_WhenAnyPropertyIsNull()
        {
            //Arrange
            var validator = new NidDocResourceValidator();
            var nidDocResourceIn = new NidDocResourceIn();

            //Act
            //Assert
            validator.ShouldHaveValidationErrorFor(a => a.Name, nidDocResourceIn);
            validator.ShouldHaveValidationErrorFor(a => a.JobName, nidDocResourceIn);
            validator.ShouldHaveValidationErrorFor(a => a.JobTypeNIDId, nidDocResourceIn);
            validator.ShouldHaveValidationErrorFor(a => a.NidIssueReasonId, nidDocResourceIn);
        }

        [Fact]
        public void ShouldHaveError_WhenJobNameExceedsaxLength()
        {
            //Arrange
            var validator = new NidDocResourceValidator();
            var nidDocResourceIn = new NidDocResourceIn() { JobName = StringExtensions.RandomString(101) };

            //Act
            //Assert
            validator.ShouldHaveValidationErrorFor(a => a.JobName, nidDocResourceIn);
        }
    }
}
