using Hangman.Infrastructure;
using System.Collections.Generic;

namespace Hangman.Tests
{
    class StubConsoleWriter : IConsoleWriter
    {
        public readonly List<string> WordOutput = new List<string>();
        public readonly List<string> MissesOutput = new List<string>();
        public readonly List<string> HangmanOutput = new List<string>();

        private readonly string _secretWord;
        private readonly string _guess;
        private int currentGuess = 0;

        public StubConsoleWriter(string secretWord, string guess)
        {
            _secretWord = secretWord;
            _guess = guess;
        }

        public void Clear()
        {
        }

        public void ClearCurrentConsoleLine()
        {
        }

        public char ReadKey()
        {
            var letter = _guess[currentGuess];
            currentGuess++;

            return letter;
        }

        public string ReadLine()
        {
            return _secretWord;
        }

        public void Write(string value)
        {
        }

        public void WriteLine()
        {
        }

        public void WriteLine(string value)
        {
            if (value.StartsWith("Word: "))
            {
                WordOutput.Add(value.Substring(value.IndexOf(" ") + 1));
            }
            else if (value.StartsWith("Misses: "))
            {
                MissesOutput.Add(value.Substring(value.IndexOf(" ") + 1));
            }
            else if (value.StartsWith("+---+"))
            {
                HangmanOutput.Add(value);
            }
        }
    }
}
