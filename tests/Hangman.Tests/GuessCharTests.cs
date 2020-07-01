using Hangman.Domain;
using System;
using Xunit;

namespace Hangman.Tests
{
    public class GuessCharTests
    {
        [Theory]
        [InlineData('1')]
        [InlineData(',')]
        [InlineData('\n')]
        [InlineData(' ')]
        [InlineData((char)13)]
        public void When_Character_Is_Incorrect_Constructor_Should_Throw_Exception(char character)
        {
            // Act
            Assert.Throws<ArgumentException>(() => new Letter(character));
        }
    }
}
