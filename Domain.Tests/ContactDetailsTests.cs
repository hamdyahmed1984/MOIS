using Xunit;
using Domain.ValueObjects;
using Domain.Exceptions;

namespace Domain.Tests
{
    public class ContactDetailsTests
    {
        [Fact]
        public void ContactDetails_ThrowsShouldNotBeEmptyException_IfEmailIsNull()
        {
            //Arrange
            //Act
            //Assert
            Assert.Throws<ShouldNotBeEmptyException>(() => new ContactDetails("01009868724", null, null, null, null));
        }

        [Fact]
        public void ContactDetails_ThrowsShouldNotBeEmptyException_IfMobile1IsNull()
        {
            //Arrange
            //Act
            //Assert
            Assert.Throws<ShouldNotBeEmptyException>(() => new ContactDetails(null, null, null, null, "h@h.h"));
        }

        [Fact]
        public void ContactDetails_InvalidFormatException_IfEmailIsInvalidFormat()
        {
            //Arrange
            var email = "hamada";
            //Act
            //Assert
            Assert.Throws<InvalidFormatException>(() => new ContactDetails("01009868724", null, null, null, email));
        }

        [Fact]
        public void ContactDetails_InvalidFormatException_IfMobile1IsInvalidFormat()
        {
            //Arrange
            var mobile1 = "11223";
            //Act
            //Assert
            Assert.Throws<InvalidFormatException>(() => new ContactDetails(mobile1, null, null, null, "h@h.h"));
        }

        [Fact]
        public void ContactDetails_InvalidFormatException_IfMobile2NotNullAndIsInvalidFormat()
        {
            //Arrange
            string mobile1 = "01009868724";
            string mobile2 = "1234";
            string email = "h@hh.h";
            //Act
            //Assert
            Assert.Throws<InvalidFormatException>(() => new ContactDetails(mobile1, mobile2, null, null, email));
        }

        [Fact]
        public void ToString_ReturnsFullContactDetails_IfValid()
        {
            //Arrange
            string mobile1 = "01009868724";
            string email = "h@hh.h";

            //Act
            var contactDetails = new ContactDetails(mobile1, null, null, null, email);
            var expectedContactDetailsString = $"Email: {email}, Mobile1: {mobile1}, Mobile2: , Home Phone: , Work Phone: ";

            //Assert
            Assert.Equal(expectedContactDetailsString, contactDetails.ToString());
        }

        [Fact]
        public void ToString_ReturnsFullContactDetails_IfValidAndMobile2NotNull()
        {
            //Arrange
            string mobile1 = "01009868724";
            string mobile2 = "01002861237";
            string email = "h@hh.h";

            //Act
            var contactDetails = new ContactDetails(mobile1, mobile2, null, null, email);
            var expectedContactDetailsString = $"Email: {email}, Mobile1: {mobile1}, Mobile2: {mobile2}, Home Phone: , Work Phone: ";

            //Assert
            Assert.Equal(expectedContactDetailsString, contactDetails.ToString());
        } 
        
        [Fact]
        public void Equals_ReturnsTrue_IfThe2InstancesAreEqual()
        {
            //Arrange
            string firstEmail = "h@h.h";
            string firstMobile1 = "01009868724";
            var firstContactDetails = new ContactDetails(firstMobile1, null, "02", null, firstEmail);
            string secondEmail = "h@h.h";
            string secondMobile1 = "01009868724";
            var secondContactDetails = new ContactDetails(secondMobile1, null, "02", null, secondEmail);

            //Act
            var result = firstContactDetails == secondContactDetails;

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void Equals_ReturnsFalse_IfThe2InstancesAreNotEqual()
        {
            //Arrange
            string firstEmail = "h@h.h";
            string firstMobile1 = "01009868724";
            var firstContactDetails = new ContactDetails(firstMobile1, null, "02", null, firstEmail);
            string secondEmail = "h@h.h";
            string secondMobile1 = "01009868724";
            var secondContactDetails = new ContactDetails(secondMobile1, null, "03", null, secondEmail);

            //Act
            var result = firstContactDetails == secondContactDetails;

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void Equals_ReturnsFalse_IfOneInstanceIsNull()
        {
            //Arrange
            string firstEmail = "h@h.h";
            string firstMobile1 = "01009868724";
            var firstContactDetails = new ContactDetails(firstMobile1, null, "02", null, firstEmail); 
            ContactDetails secondContactDetails = null;

            //Act
            var result = firstContactDetails == secondContactDetails;

            //Assert
            Assert.False(result);
        }
    }
}
