using System.Collections.Generic;

namespace Hangman.Domain
{
    public class Logic : ILogic
    {
        private readonly List<Letter> _letters = new List<Letter>();
        private SecretWord _secretWord;

        public void Start(string secretWord)
        {
            _secretWord = new SecretWord(secretWord);
            _letters.Clear();
        }

        public bool GuessChar(char character)
        {
            var guessChar = new Letter(character);
            _letters.Add(guessChar);
            Display = _secretWord.GetMasked(_letters);

            return _secretWord.Contains(guessChar);
        }

        public string Display { get; private set; }
    }
}
