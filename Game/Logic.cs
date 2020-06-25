using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Hangman.Lib;

namespace Hangman.Game
{
    public class Logic : ILogic
    {
        private string _gesuchtesWort;
        private readonly List<char> _buchstaben = new List<char>();

        public void Start(string secretWord)
        {
            if (! Regex.IsMatch(secretWord, @"^[a-zäöüß]+$", RegexOptions.IgnoreCase))
                throw new Exception();

            _gesuchtesWort = secretWord;
            _buchstaben.Clear();
        }

        public bool GuessChar(char character)
        {
            if (_gesuchtesWort.Contains(character, StringComparison.InvariantCultureIgnoreCase))
            {
                _buchstaben.Add(character);

                return true;
            }

            return false;
        }

        public string Display => Regex.Replace(_gesuchtesWort, $"[^-{new string(_buchstaben.ToArray())}]", "-", RegexOptions.IgnoreCase);
    }
}