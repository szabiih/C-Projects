using System;
namespace Versenyzok
{
    internal class Program
    {
        private static readonly string FILE_PATH = "pilotak.csv";
        static void Main(string[] args)
        {
            //  1. Feladat
            Console.WriteLine("1. Feladat");
            List<Pilot> pilots = Pilot.LoadPilots(FILE_PATH, out string[] header);
            Console.WriteLine();

            //  2. Feladat
            Console.WriteLine("2. Feladat");
            Console.WriteLine($"A sorok száma a fájlban: {pilots.Count}");
            Console.WriteLine();

            //  3. Feladat
            Console.WriteLine("3. Feladat");

            Console.WriteLine();

            //  4. Feladat
            Console.WriteLine("4. Feladat");

            Console.WriteLine();

            //  5. Feladat
            Console.WriteLine("5. Feladat");

            Console.WriteLine();

            //  6. Feladat
            Console.WriteLine("6. Feladat");

            Console.WriteLine();
        }
    }
}
