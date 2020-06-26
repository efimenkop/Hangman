using System;
using Xunit;

namespace Hangman.Lib.Tests
{
    public class TestLogic
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("space separated words")]
        [InlineData("wordswithdigits123")]
        [InlineData("words_with_special_characters")]
        [InlineData("words\nwords")]
        public void When_Secret_Word_Is_Incorrect_Start_Should_Throw_Exception(string secretWord)
        {
            // Arrange
            var sut = new Logic();

            // Act
            Assert.ThrowsAny<ArgumentException>(() => sut.Start(secretWord));
        }

        [Theory]
        [InlineData('1')]
        [InlineData(',')]
        [InlineData('\n')]
        [InlineData(' ')]
        [InlineData((char)13)]
        public void When_Character_Is_Incorrect_GuessChar_Should_Throw_Exception(char character)
        {
            // Arrange
            var sut = new Logic();

            // Act
            Assert.Throws<ArgumentException>(() => sut.GuessChar(character));
        }

        [Theory]
        [InlineData("kitty", 'k', true)]
        [InlineData("kitty", 'K', true)]
        [InlineData("kitty", 'a', false)]
        [InlineData("Über", 'ü', true)]
        public void GuessChar_Should_Return_Correct_Result(string secretWord, char character, bool expectedResult)
        {
            // Arrange
            var sut = new Logic();

            // Act
            sut.Start(secretWord);
            var result = sut.GuessChar(character);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("kitty", "kzTa", "k-tt-")]
        [InlineData("Über", "oÜcE", "Ü-e-")]
        public void Display_Should_Return_Correct_Result(string secretWord, string guess, string expectedResult)
        {
            // Arrange
            var sut = new Logic();

            // Act
            sut.Start(secretWord);
            foreach (char character in guess)
            {
                sut.GuessChar(character);
            }

            var result = sut.Display;

            // Assert
            Assert.Equal(expectedResult, result);
        }

    }
}
