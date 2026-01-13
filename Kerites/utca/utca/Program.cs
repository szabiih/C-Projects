using System;
namespace utca
{
    internal class Program
    {
        public static readonly string FAJLNEV = "kerites.txt";

        static void Main(string[] args)
        {
            //  1. Feladat
            Console.WriteLine("1. Feladat");
            List<Telek> telkek = Telek.Beolvasas(FAJLNEV);
            Console.WriteLine();

            //  2. Feladat
            Console.WriteLine("2. Feladat");
            int szam01 = Telek.EladottTelkekSzama(telkek);
            Console.WriteLine($"Az eladott telkek száma: {szam01}");
            Console.WriteLine();

            //  3. Feladat
            Console.WriteLine("3. Feladat");
            Telek.UtolsoTelek(telkek);
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
