using Hangman.Domain;
using System;
using Xunit;

namespace Hangman.Tests
{
    public class SecretWordTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("space separated words")]
        [InlineData("wordswithdigits123")]
        [InlineData("words_with_special_characters")]
        [InlineData("words\nwords")]
        public void When_Secret_Word_Is_Incorrect_Constructor_Should_Throw_Exception(string secretWord)
        {
            // Act
            Assert.ThrowsAny<ArgumentException>(() => new SecretWord(secretWord));
        }
    }
}
