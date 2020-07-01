using Hangman.Domain;
using Hangman.Infrastructure;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game(new ConsoleWriter(), new Logic());

            game.Play();
        }
    }
}
