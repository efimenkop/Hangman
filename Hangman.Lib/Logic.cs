using EnsureThat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Hangman.Lib
{
    public class Logic : ILogic
    {
        private readonly HashSet<char> _knownChars = new HashSet<char>();
        private string _secretWord;

        public void Start(string secretWord)
        {
            Ensure.That(secretWord, nameof(secretWord)).IsNotNullOrWhiteSpace();
            Ensure.That(secretWord, nameof(secretWord)).Matches(new Regex("^[a-zäöüß]+$", RegexOptions.IgnoreCase));

            _secretWord = secretWord;
            _knownChars.Clear();
        }

        public bool GuessChar(char character)
        {
            Ensure.That(character.ToString(), nameof(character)).Matches(new Regex("^[a-zäöüß]$", RegexOptions.IgnoreCase));

            _knownChars.Add(char.ToUpperInvariant(character));

            return _secretWord.Contains(character, StringComparison.CurrentCultureIgnoreCase);
        }

        public string Display => Regex.Replace(_secretWord, $"[^-{new string(_knownChars.ToArray())}]", "-", RegexOptions.IgnoreCase);
    }
}
