using System;
using FluentAssertions;
using Hangman.Lib;
using Xunit;

namespace Hangman.Game.Tests
{
    public class TestLogic
    {
        [Theory]
        [InlineData("Test")]
        [InlineData("Kantine")]
        [InlineData("Donaudampfschifffahrtskapitän")]
        [InlineData("müde")]
        [InlineData("schön")]
        [InlineData("Fuß")]
        public void Testen_ob_mit_dem_Wort_gestartet_werden_kann(string wort)
        {
            var sut = new Logic();

            sut.Start(wort);

            sut.Should().NotBeOfType<ILogic>();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("123")]
        [InlineData("Route66")]
        [InlineData("HelloWorld!")]
        [InlineData("Hello World")]
        public void Testen_ob_das_Wort_beim_Start_abgelehnt_wird(string wort)
        {
            var sut = new Logic();

            Action act = () => { sut.Start(wort); };

            act.Should().Throw<Exception>();
        }

        [Theory]
        [InlineData("Test", new char[0], "----")]
        [InlineData("Test", new[] {'t'}, "T--t")]
        [InlineData("Test", new[] {'t', 'e', 's'}, "Test")]
        [InlineData("Hallo", new[] {'l'}, "--ll-")]
        [InlineData("Hallo", new[] {'l', 'h'}, "H-ll-")]
        [InlineData("Test", new[] {'l', 'h'}, "----")]
        public void Testen_ob_die_Anzeige_korrekt_maskiert(string wort, char[] buchstaben, string anzeige)
        {
            var sut = new Logic();

            sut.Start(wort);

            foreach (var c in buchstaben) sut.GuessChar(c);

            sut.Display.Should().Be(anzeige);
        }

        [Theory]
        [InlineData("Test", 'e', true)]
        [InlineData("Hallo", 'h', true)]
        [InlineData("Hallo", 'A', true)]
        [InlineData("Hallo", 'b', false)]
        [InlineData("Styx", 'ä', false)]
        [InlineData("Häuser", 'ä', true)]
        public void Testen_ob_ein_Buchstabe_gefunden_wird(string wort, char c, bool success)
        {
            var sut = new Logic();

            sut.Start(wort);

            sut.GuessChar(c).Should().Be(success);
        }

        [Fact]
        public void Testen_ob_ein_Spiel_erneut_gestartet_werden_kann()
        {
            var sut = new Logic();

            sut.Start("Test");
            sut.GuessChar('t');

            sut.Start("Test");

            sut.Display.Should().Be("----");
        }
    }
}