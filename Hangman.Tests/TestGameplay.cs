using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Hangman.Tests
{
    public class TestGameplay
    {
        private const char Esc = (char) ConsoleKey.Escape;

        [Fact]
        public void Testen_ob_das_Spiel_erfolgreich_durchgespielt_werden_kann()
        {
            var gesuchtesWort = "Test";
            var output = new List<string>();
            var keys = new[] {'t', 's', 'e'};
            var key = 0;

            var sf = new Gameplay(
                s => output.Add(s),
                () => gesuchtesWort,
                () => keys[key++],
                () => output.Clear());

            sf.Start();

            output.Count.Should().Be(4);
            output[0].Should().Contain("T--t");
            output[1].Should().Contain("T-st");
            output[2].Should().Contain("Test");
            output.Last().Should().Contain("Glückwunsch");
        }

        [Fact]
        public void Testen_ob_das_Spiel_gestartet_und_abgebrochen_werden_kann()
        {
            var gesuchtesWort = "Test";
            var output = new List<string>();
            var keys = new[] {'t', Esc};
            var key = 0;

            var sf = new Gameplay(
                s => output.Add(s),
                () => gesuchtesWort,
                () => keys[key++],
                () => output.Clear());

            sf.Start();

            output.Count.Should().Be(2);
            output.Last().Should().Contain("Schade");
        }

        [Fact]
        public void Testen_ob_das_Spiel_unerlaubte_Zeichen_abweist()
        {
            var gesuchtesWort = "Test";
            var output = new List<string>();
            var keys = new[] {'t', '1', 'e', Esc};
            var key = 0;

            var sf = new Gameplay(
                s => output.Add(s),
                () => gesuchtesWort,
                () => keys[key++],
                () => output.Clear());

            sf.Start();

            output.Count.Should().Be(3);
            output[0].Should().Contain("T--t");
            output[1].Should().Contain("Te-t");
            output.Last().Should().Contain("Schade");
        }

        [Fact]
        public void Testen_ob_das_Spiel_ungültige_Worte_ablehnt()
        {
            var gesuchteWorte = new[] {"Hallo Welt!", "Test"};
            var gesuchtesWort = 0;
            var output = new List<string>();
            var keys = new[] {'t', Esc};
            var key = 0;

            var sf = new Gameplay(
                s => output.Add(s),
                () => gesuchteWorte[gesuchtesWort++],
                () => keys[key++],
                () => output.Clear());

            sf.Start();

            output.Count.Should().Be(2);
            output[0].Should().Contain("T--t");
            output.Last().Should().Contain("Schade");
        }
    }
}