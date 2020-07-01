using EnsureThat;
using Hangman.Helpers;
using Hangman.Infrastructure;
using System;
using System.Collections.Generic;

namespace Hangman.Domain
{
    public class Game
    {
        private readonly IConsoleWriter _console;
        private readonly ILogic _logic;

        public GameResult Status { get; private set; }

        public Game(IConsoleWriter console, ILogic logic)
        {
            Ensure.That(console, nameof(console)).IsNotNull();
            Ensure.That(logic, nameof(logic)).IsNotNull();

            _console = console;
            _logic = logic;
        }

        public void Play()
        {
            Status = GameResult.InProgress;

            var misses = new List<char>();
            var guess = new List<char>();

            var secretWord = EnterSecretWord();

            int guessCounter = 1;

            while (Status == GameResult.InProgress)
            {
                _console.WriteLine("############# Guess: " + guessCounter + " ########");

                var letter = GuessLetter(guess);

                if (letter == null)
                {
                    continue;
                }

                guessCounter++;

                if (!_logic.GuessChar(letter.Value))
                {
                    misses.Add(letter.Value);
                }

                if (misses.Count == ASCIIArt.HangmanStates.Length - 1)
                {
                    Status = GameResult.PlayerLost;
                }
                else if (secretWord.Value == _logic.Display)
                {
                    Status = GameResult.PlayerWon;
                }

                WriteGuessResult(misses);
            }

            WriteGameResult(secretWord);
        }

        private void WriteGameResult(SecretWord secretWord)
        {
            _console.WriteLine("Secret word: " + secretWord.Value);

            switch (Status)
            {
                case GameResult.PlayerWon:
                    _console.WriteLine("Congratulations, you found the secret word!");
                    break;
                case GameResult.PlayerLost:
                    _console.WriteLine("Game over!");
                    break;
                case GameResult.Abandoned:
                    _console.WriteLine("Good bye!");
                    break;
            }

            _console.ReadLine();
        }

        private void WriteGuessResult(List<char> misses)
        {
            _console.WriteLine();
            _console.WriteLine("Word: " + _logic.Display);
            _console.WriteLine("Misses: " + string.Join(" ", misses));
            _console.WriteLine(ASCIIArt.HangmanStates[misses.Count]);
            _console.WriteLine();
        }

        private SecretWord EnterSecretWord()
        {
            SecretWord secretWord;

            do
            {
                _console.Clear();
                _console.Write("Enter a secret word: ");
            }

            while (!SecretWord.TryParse(_console.ReadLine(), out secretWord));

            _console.Clear();

            _logic.Start(secretWord.Value);

            return secretWord;
        }

        private char? GuessLetter(List<char> guess)
        {
            char key;
            Letter letter;

            do
            {
                _console.Write("Guess a letter: ");

                key = _console.ReadKey();

                _console.WriteLine();

                if (key == (char)ConsoleKey.Escape)
                {
                    Status = GameResult.Abandoned;
                    return null;
                }
            }
            while (!Letter.TryParse(key, out letter) || guess.Contains(letter.Value));

            guess.Add(letter.Value);

            return letter.Value;
        }
    }
}
