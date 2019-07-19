using Xunit;
using Domain.ValueObjects;
using Domain.Exceptions;

namespace Domain.Tests
{
    public class RequesterNameTests
    {
        [Fact]
        public void RequesterName_ThrowsShouldNotBeEmptyException_IfFirstNameNull()
        {
            //Arrange
            //Act
            //Assert
            Assert.Throws<ShouldNotBeEmptyException>(() => new RequesterName(null, "father", "grandfather", "family"));
        }

        [Fact]
        public void RequesterName_ThrowsShouldNotBeEmptyException_IfFatherNameNull()
        {
            //Arrange
            //Act
            //Assert
            Assert.Throws<ShouldNotBeEmptyException>(() => new RequesterName("first", "", "grandfather", "family"));
        }

        [Fact]
        public void RequesterName_ThrowsShouldNotBeEmptyException_IfGrandFatherNameNull()
        {
            //Arrange
            //Act
            //Assert
            Assert.Throws<ShouldNotBeEmptyException>(() => new RequesterName("first", "father", null, "family"));
        }

        [Fact]
        public void RequesterName_ThrowsShouldNotBeEmptyException_IfFamilyNameNull()
        {
            //Arrange
            //Act
            //Assert
            Assert.Throws<ShouldNotBeEmptyException>(() => new RequesterName("first", "father", "grandfather", null));
        }

        [Fact]
        public void RequesterName_ReturnsCorrectFullName_IfValid()
        {
            //Arrange
            var fullName = "Hamdy Ahmed AbdulGalil AbdulFatah";
            var requesterName= new RequesterName("Hamdy", "Ahmed", "AbdulGalil", "AbdulFatah");

            //Act
            var actualFullName = requesterName.FullName;

            //Assert
            Assert.Equal(fullName, actualFullName);
        }

        [Fact]
        public void Equals_ReturnsTrue_IfThe2InstancesAreEqual()
        {
            //Arrange
            var firstName = new RequesterName("hamdy", "ahmed", "abdulgalil", "abdulfatah");
            var secondName = new RequesterName("hamdy", "ahmed", "abdulgalil", "abdulfatah");

            //Act
            var result = firstName == secondName;

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void Equals_ReturnsFalse_IfThe2InstancesAreNotEqual()
        {
            //Arrange
            var firstName = new RequesterName("hamdy", "ahmed", "abdulgalil", "abdulfatah");
            var secondName = new RequesterName("hamdy", "sssss", "abdulgalil", "abdulfatah");

            //Act
            var result = firstName == secondName;

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void Equals_ReturnsFalse_IfOneInstanceIsNull()
        {
            //Arrange
            var firstName = new RequesterName("hamdy", "ahmed", "abdulgalil", "abdulfatah");
            RequesterName secondName = null;

            //Act
            var result = firstName == secondName;

            //Assert
            Assert.False(result);
        }
    }
}
