using Hangman.Domain;
using Hangman.Helpers;
using FluentAssertions;
using System.Linq;
using Xunit;

namespace Hangman.Tests
{
    public partial class GameTests
    {
        [Theory]
        [InlineData("kitty", "yaitk")]
        [InlineData("KiTTy", "YaItK")]
        public void When_Guessed_Secret_Word_Then_Should_Write_Correct_Output(string secretWord, string guess)
        {
            // Arrange
            var consoleWriter = new StubConsoleWriter(secretWord, guess);

            var sut = new Game(consoleWriter, new Logic());

            // Act
            sut.Play();

            // Assert
            consoleWriter.WordOutput.Should().BeEquivalentTo(new[] { "----Y", "----Y", "-I--Y", "-ITTY", "KITTY" });
            consoleWriter.MissesOutput.Should().BeEquivalentTo(new[] { "", "A", "A", "A", "A" });
            consoleWriter.HangmanOutput.Last().Should().Be(ASCIIArt.HangmanStates[1]);
            sut.Status.Should().Be(GameResult.PlayerWon);
        }

        [Theory]
        [InlineData("kitty", "abcdef")]
        [InlineData("KiTTy", "aBcDeF")]
        public void When_Failed_To_Guess_Secret_Word_Then_Should_Write_Correct_Output(string secretWord, string guess)
        {
            // Arrange
            var consoleWriter = new StubConsoleWriter(secretWord, guess);

            var sut = new Game(consoleWriter, new Logic());

            // Act
            sut.Play();

            // Assert
            consoleWriter.WordOutput.Should().BeEquivalentTo(new[] { "-----", "-----", "-----", "-----", "-----", "-----" });
            consoleWriter.MissesOutput.Should().BeEquivalentTo(new[] { "A", "A B", "A B C", "A B C D", "A B C D E", "A B C D E F" });
            consoleWriter.HangmanOutput.Last().Should().Be(ASCIIArt.HangmanStates[6]);
            sut.Status.Should().Be(GameResult.PlayerLost);
        }

        [Theory]
        [InlineData("kitty", "ya\u001b")]
        [InlineData("KiTTy", "yA\u001b")]
        public void When_User_Hit_Escape_Then_Game_Closes(string secretWord, string guess)
        {
            // Arrange
            var consoleWriter = new StubConsoleWriter(secretWord, guess);

            var sut = new Game(consoleWriter, new Logic());

            // Act
            sut.Play();

            // Assert
            consoleWriter.WordOutput.Should().BeEquivalentTo(new[] { "----Y", "----Y" });
            consoleWriter.MissesOutput.Should().BeEquivalentTo(new[] { "", "A" });
            consoleWriter.HangmanOutput.Last().Should().Be(ASCIIArt.HangmanStates[1]);
            sut.Status.Should().Be(GameResult.Abandoned);
        }
    }
}
