# Coding Challenge DB Zeitarbeit IT department

## English Version

Hello,

we are happy, that you would like to solve our small coding challenge!

This piece of programming work will give us an impression of how you develop software.

The task should not require more then half a day of your time, and hopefully bring you a little bit of fun ;-)

The following task serves this purpose:

### Task

Please fill out the class "Logic", which implements the interface ILogic.

Develop a game logic for a little guessing game, in the style of ["hangman"](https://en.wikipedia.org/wiki/Hangman_(game)).

The solution file is already provided.

Even if it is only a little game, your results should be "production ready",

I.e. being professionally developed.

We are excited and looking forward what "production ready" means for you.

```
namespace hangman.Lib
{
    public interface ILogic
    {
        void Start(string secretWord);

        bool GuessChar(char character);

        string Display { get; }
    }
}
```

The class receives the searched word through the method "start", which has to consist of characters only.

"GuessCharacter" gets only single characters and returns, if they are contained in the word.

The property "Display" returns the part of the word which already matched at this point in time.

I.e. all not yet found characters are substituted with a "-" character.

The logic is case insensitive.

Enjoy, have fun, and good succed!

## Deutsche Version

Hallo,

wir freuen uns, dass Du unsere kleine Testaufgabe lösen möchtest!

Diese kleine Programmierarbeit soll uns einen Eindruck verschaffen, wie Du Software entwickelst.

Die Aufgabe sollte nicht mehr als ca. einen Tag in Anspruch nehmen und dabei vielleicht sogar Spaß machen. ;-)

Dafür soll diese Aufgabe dienen:

### Aufgabe

Programmiere die Spiellogik für ein kleines Wort-Rate-Spiel. 

Die Solution ist bereits gegeben.

Auch wenn es nur ein kleines Spiel ist, sollte das Ergebnis "produktionsreif" sein, 

das heißt professionell entwickelt worden sein.

Wir sind gespannt, was das für Dich bedeutet.

Programmiere dazu die Klasse Logik aus, die die Schnittstelle ILogik implementiert.

```
namespace hangman.Lib
{
    public interface ILogic
    {
        void Start(string secretWord);

        bool GuessChar(char character);

        string Display { get; }
    }
}
```

Über die Methode Start bekommt die Klasse das gesuchte Wort, das nur aus Buchstaben bestehen darf.

RateBuchstaben erhält einen einzelnen Buchstaben und gibt zurück, ob er im Wort gefunden wurde. 

Die Eigenschaft Anzeige gibt jeweils den bis zu diesem Zeitpunkt erratenen Bestandteil des Worts zurück.

Das heißt alle noch nicht erratenen Buchstaben sind durch ein "-" ersetzt.

Es wird nicht zwischen Groß- und Kleinschreibung unterschieden.

Viel Spaß und Gutes Gelingen!
