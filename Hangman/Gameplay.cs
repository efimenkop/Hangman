using Hangman.Lib;
using System;
using System.Text.RegularExpressions;

namespace Hangman
{
    public sealed class Gameplay
    {
        private readonly Action _clearOutput;
        private readonly Func<char> _readKey;
        private readonly Func<string> _readLine;
        private readonly Action<string> _writeLine;

        public Gameplay(Action<string> writeLine, Func<string> readLine, Func<char> readKey, Action clearOutput)
        {
            _writeLine = writeLine;
            _readLine = readLine;
            _readKey = readKey;
            _clearOutput = clearOutput;
        }

        public void Start()
        {
            ILogic logic = new Logic();

            _clearOutput();

            _writeLine("Bitte gib das gesuchte Wort ein:");

            var gesuchtesWort = string.Empty;

            while (!Regex.IsMatch(gesuchtesWort, @"^[a-zäöüß]+$", RegexOptions.IgnoreCase))
                gesuchtesWort = _readLine();

            logic.Start(gesuchtesWort);

            _clearOutput();

            while (logic.Display != gesuchtesWort)
            {
                var buchstabe = _readKey();

                if (buchstabe == (char)ConsoleKey.Escape)
                    break;

                if (!char.IsLetter(buchstabe))
                    continue;

                logic.GuessChar(buchstabe);

                _writeLine("          " + logic.Display);
            }

            _writeLine(logic.Display == gesuchtesWort
                ? "Herzlichen Glückwunsch!!!"
                : "Schade, vielleicht klappt es das nächste Mal.");
        }
    }
}