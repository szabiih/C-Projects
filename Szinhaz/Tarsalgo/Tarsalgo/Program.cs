using System;
namespace Tarsalgo
{
    internal class Program
    {
        private static readonly string FILE_PATH = "ajto.txt";
        private static readonly string FILE_SAVE = "athaladas.txt";
        static void Main(string[] args)
        {
            //  1. Feladat
            Console.WriteLine("1. Feladat");
            List<Event> events = Event.LoadEvents(FILE_PATH);
            Console.WriteLine();

            //  2. Feladat
            Console.WriteLine("2. Feladat");
            Event.DisplayFirstAndLastEventID(events);
            Console.WriteLine();

            //  3. Feladat
            Console.WriteLine("3. Feladat");
            Event.SaveNumberOfPasses(events, FILE_SAVE);
            Console.WriteLine();

            //  4. Feladat
            Console.WriteLine("4. Feladat");
            List<int> inside = Event.RemainedInsideAtTheEndOfThePeriod(events);
            inside.Sort();
            Console.WriteLine($"A végén a társalgóban voltak: {string.Join(' ', inside)}");
            Console.WriteLine();

            //  5. Feladat
            Console.WriteLine("5. Feladat");
            Event.MostPeopleInTheRoom(events, out int hour, out int minute);
            Console.WriteLine($"Például {hour}:{minute}-kor voltak a legtöbben a társalgóban.");
            Console.WriteLine();

            //  6. Feladat
            Console.WriteLine("6. Feladat");
            int input = Event.GetInput();
            Console.WriteLine();

            //  7. Feladat
            Console.WriteLine("7. Feladat");
            Event.DisplayRequestedIDResidenceTime(events, input);
            Console.WriteLine();

            //  8. Feladat
            Console.WriteLine("8. Feladat");
            //  ezt túl bonyolult és nem maradt rá idő inkább
            Console.WriteLine();
        }
    }
}
