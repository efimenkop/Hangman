using System;

namespace Hangman.Infrastructure
{
    public class ConsoleWriter : IConsoleWriter
    {
        public void Clear()
        {
            Console.Clear();
        }

        public char ReadKey()
        {
            return Console.ReadKey().KeyChar;
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void Write(string value)
        {
            Console.Write(value);
        }

        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }

        public void WriteLine()
        {
            Console.WriteLine();
        }
    }
}
