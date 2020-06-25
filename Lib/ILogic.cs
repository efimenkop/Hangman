﻿namespace Hangman.Lib
{
    public interface ILogic
    {
        void Start(string secretWord);

        bool GuessChar(char character);

        string Display { get; }
    }
}
