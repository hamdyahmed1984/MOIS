using System;
using System.Linq;

namespace ClientApp.Tests.FluentValidationTests
{
    public static class StringExtensions
    {
        //Generates a random alpha-numeric string of a specified length
        public static string RandomString(int length)
        {
            Random random = new Random();
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
