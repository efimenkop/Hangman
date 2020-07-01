namespace Hangman.Helpers
{
    public static class ASCIIArt
    {

        public static readonly string[] HangmanStates = new string[] {
@"+---+
  |   |
      |
      |
      |
      |
=========",

@"+---+
  |   |
  O   |
      |
      |
      |
=========",

@"+---+
  |   |
  O   |
  |   |
      |
      |
=========",

@"+---+
  |   |
  O   |
 /|   |
      |
      |
=========",

@"+---+
  |   |
  O   |
 /|\  |
      |
      |
=========",

@"+---+
  |   |
  O   |
 /|\  |
 /    |
      |
=========",

@"+---+
  |   |
  O   |
 /|\  |
 / \  |
      |
=========" };
    }
}
