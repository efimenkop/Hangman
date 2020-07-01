namespace Hangman.Infrastructure
{
    public interface IConsoleWriter
    {
        void Clear();
        void Write(string value);
        void WriteLine();
        void WriteLine(string value);
        string ReadLine();
        char ReadKey();
    }
}