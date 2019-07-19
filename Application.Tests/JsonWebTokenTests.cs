using Xunit;
using System;
using Application.Security.Tokens;

namespace Application.Tests
{
    public class JsonWebTokenTests
    {

        [Fact]
        public void IsExpired_ReturnsTrue_WhenTokenIsExpired()
        {
            //Arrange
            JsonWebToken token = new RefreshToken("token", 100);

            //Act
            var result = token.IsExpired();

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void IsExpired_ReturnsFalse_WhenTokenIsNotExpired()
        {
            //Arrange
            JsonWebToken token = new RefreshToken("token", DateTime.Now.AddSeconds(60).Ticks);

            //Act
            var result = token.IsExpired();

            //Assert
            Assert.False(result);
        }

    }
}
