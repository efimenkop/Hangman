using EnsureThat;
using System.Text.RegularExpressions;

namespace Hangman.Domain
{
    public class Letter
    {
        private static readonly Regex CharRegex = new Regex("^[a-zäöüß]$", RegexOptions.IgnoreCase);

        public static bool TryParse(char c, out Letter letter)
        {
            letter = null;

            try
            {
                letter = new Letter(c);
                return true;
            }
            catch
            {
                // ignored
            }

            return false;
        }

        public char Value { get; }

        public Letter(char character)
        {
            Ensure.That(character.ToString(), nameof(character)).Matches(CharRegex);

            Value = char.ToUpperInvariant(character);
        }

        protected bool Equals(Letter other)
        {
            return Value == other.Value;
        }
    }
}