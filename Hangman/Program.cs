using System;

namespace Hangman
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var spiel = new Gameplay(
                Console.WriteLine, 
                Console.ReadLine,
                () => Console.ReadKey().KeyChar,
                Console.Clear);

            spiel.Start();

            Console.ReadLine();
        }
    }
}