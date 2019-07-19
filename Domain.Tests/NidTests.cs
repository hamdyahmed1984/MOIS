using Domain.Exceptions;
using Domain.ValueObjects;
using System;
using Xunit;

namespace Domain.Tests
{
    public class NidTests
    {
        [Fact]
        public void ToString_ReturnNidString_WhenValid()
        {
            //Arrange
            var nidString = "11111111111111";
            NID nid = new NID(nidString);

            //Act
            var actual = nid.ToString();

            //Assert
            Assert.Equal(nidString, actual);
        }

        [Fact]
        public void NID_ThrouwsShouldNotBeEmptyException_WhenEmpty()
        {
            //Arrange
            var nidString = string.Empty;

            //Act
            //Assert
            Assert.Throws<ShouldNotBeEmptyException>(() => new NID(nidString));
        }

        [Fact]
        public void NID_InvalidFormatException_WhenNotMatchedRegex()
        {
            //Arrange
            var nidString = "9898989";

            //Act
            //Assert
            Assert.Throws<InvalidFormatException>(() => new NID(nidString));
        }

        [Fact]
        public void IsNidValid_ReturnsTrue_WhenValidNid()
        {
            //Arrange
            var nidString = "28410071402991";
            var nid = new NID(nidString);

            //Act
            var actual = nid.IsNidValid();

            //Assert
            Assert.True(actual);
        }

        [Fact]
        public void IsNidValid_ReturnsFalse_WhenInvalidNid()
        {
            //Arrange
            var nidString = "28410071402901";
            var nid = new NID(nidString);

            //Act
            var actual = nid.IsNidValid();

            //Assert
            Assert.False(actual);
        }

        [Fact]
        public void GetGender_ReturnaMale_IfMale()
        {
            //Arrange
            var nidString = "28410071402991";
            var nid = new NID(nidString);

            //Act
            var actual = nid.GetGender();

            //Assert
            Assert.Equal("ذكر", actual);
        }

        [Fact]
        public void GetGender_ReturnaFemMale_IfFemMale()
        {
            //Arrange
            var nidString = "28410071402981";
            var nid = new NID(nidString);

            //Act
            var actual = nid.GetGender();

            //Assert
            Assert.Equal("أنثى", actual);
        }

        [Fact]
        public void GetDateOfBirth_ReturnsCorrectBirthDate()
        {
            //Arrange
            var nidString = "28410071402991";
            var nid = new NID(nidString);

            //Act
            var actual = nid.GetDateOfBirth();

            //Assert
            Assert.Equal(new DateTime(1984, 10, 07), actual);
        }

        [Fact]
        public void GetGovernorate_ReturnsCorrectGovernorate()
        {
            //Arrange
            var nidString = "28410071402991";
            var nid = new NID(nidString);

            //Act
            var actual = nid.GetGovernorate();

            //Assert
            Assert.Equal("محافظة القليوبية", actual);
        }

        [Fact]
        public void Equals_ReturnsTrue_IfThe2InstancesAreEqual()
        {
            //Arrange
            var firstNid = new NID("28410071402991");
            var secondNid = new NID("28410071402991");

            //Act
            var result = firstNid == secondNid;

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void Equals_ReturnsFalse_IfThe2InstancesAreNotEqual()
        {
            //Arrange
            var firstNid = new NID("28410071402991");
            var secondNid = new NID("38410071402991");

            //Act
            var result = firstNid == secondNid;

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void Equals_ReturnsFalse_IfOneInstanceIsNull()
        {
            //Arrange
            NID firstNid = null;
            var secondNid = new NID("28410071402991");

            //Act
            var result = firstNid == secondNid;

            //Assert
            Assert.False(result);
        }
    }
}
