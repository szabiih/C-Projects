using System;
namespace utca
{
    internal class Program
    {
        public static readonly string FAJLNEV = "kerites.txt";
        private static List<Telek> parosTelkek = new List<Telek>();
        private static List<Telek> paratlanTelkek = new List<Telek>();

        static void Main(string[] args)
        {
            //  1. Feladat
            Console.WriteLine("1. Feladat");
            List<Telek> telkek = Telek.Beolvasas(FAJLNEV);
            Console.WriteLine();

            //  2. Feladat
            Console.WriteLine("2. Feladat");
            //int szam01 = Telek.EladottTelkekSzama(telkek);
            Console.WriteLine($"Az eladott telkek száma: {telkek.Count}");
            Console.WriteLine();

            //  3. Feladat
            Console.WriteLine("3. Feladat");
            Telek.UtolsoTelek(telkek, parosTelkek, paratlanTelkek);     //  mivel referencia típus feltölti a páros és páratlan listát
            Console.WriteLine();

            //  4. Feladat
            Console.WriteLine("4. Feladat");
            Telek.UgyanOlyanSzinuTelekKerites(paratlanTelkek);
            Console.WriteLine();

            //  5. Feladat
            Console.WriteLine("5. Feladat");
            Telek.TelekKeresese(parosTelkek, paratlanTelkek);
            Console.WriteLine();

            //  6. Feladat
            Console.WriteLine("6. Feladat");

            Console.WriteLine();
        }
    }
}
