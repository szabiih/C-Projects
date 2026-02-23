using System;
namespace Otszaz
{
    internal class Program
    {
        private static readonly string FILE_PATH = "penztar.txt";
        private static readonly string FILE_SAVE = "osszeg.txt";
        static void Main(string[] args)
        {
            //  1. Feladat
            Console.WriteLine("1. Feladat");
            List<Dictionary<string, int>> payments = Functions.LoadPayments(FILE_PATH);
            Console.WriteLine();

            //  2. Feladat
            Console.WriteLine("2. Feladat");
            Console.WriteLine($"A fizetések száma: {payments.Count}");
            Console.WriteLine();

            //  3. Feladat
            Console.WriteLine("3. Feladat");
            Console.WriteLine($"Az első vásárló {Functions.NumberOfItemsPurchasedByFirstCustomer(payments)} darab árucikket vásárolt.");
            Console.WriteLine();

            //  4. Feladat
            Console.WriteLine("4. Feladat");
            Functions.GetInput(out int purchaseNumber, out string itemName, out int quantity);
            Console.WriteLine();

            //  5. Feladat
            Console.WriteLine("5. Feladat");
            Functions.CalculationsWithGivenInput(payments, itemName);
            Console.WriteLine();

            //  6. Feladat
            Console.WriteLine("6. Feladat");
            int value = Functions.CalculationsWithGivenInputVALUE(quantity);
            Console.WriteLine($"{quantity} darab vételekor fizetendő: {value}");
            Console.WriteLine();

            //  7. Feladat
            Console.WriteLine("7. Feladat");
            Functions.DisplayDictionary(payments, purchaseNumber);
            Console.WriteLine();

            //  8. Feladat
            Console.WriteLine("8. Feladat");
            Functions.SavePrices(payments, FILE_SAVE);
            Console.WriteLine();
        }
    }
}
