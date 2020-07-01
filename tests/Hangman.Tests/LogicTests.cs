using Hangman.Domain;
using Xunit;

namespace Hangman.Tests
{
    public class LogicTests
    {
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
        [InlineData("kitty", "kzTa", "K-TT-")]
        [InlineData("Über", "oücE", "Ü-E-")]
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
