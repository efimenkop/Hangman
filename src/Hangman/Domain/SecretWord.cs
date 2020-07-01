using EnsureThat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Hangman.Domain
{
    public class SecretWord
    {
        private static readonly Regex WordRegex = new Regex("^[a-zäöüß]+$", RegexOptions.IgnoreCase);

        public static bool TryParse(string s, out SecretWord secretWord)
        {
            secretWord = null;

            try
            {
                secretWord = new SecretWord(s);
                return true;
            }
            catch
            {
                // ignored
            }

            return false;
        }

        public string Value { get; }

        public SecretWord(string word)
        {
            Ensure.That(word, nameof(word)).Matches(WordRegex);

            Value = word.ToUpperInvariant();
        }

        public string GetMasked(IEnumerable<Letter> guessChars)
        {
            var regexReplacement = new string(guessChars.Select(l => l.Value).ToArray());

            return Regex.Replace(Value.ToString(), $"[^-{regexReplacement}]", "-", RegexOptions.IgnoreCase);
        }

        public bool Contains(Letter guessChar)
        {
            return Value.Contains(guessChar.Value, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}