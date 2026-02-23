using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Otszaz
{
    internal class Functions
    {
        public static List<Dictionary<string, int>> LoadPayments(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"A '{filePath}' nevű fájl nem létezik!");
                return null;
            }
            else
            {
                Console.WriteLine("SIKERES BEOLVASÁS!");
            }

            List<Dictionary<string, int>> baskets = new List<Dictionary<string, int>>();
            Dictionary<string, int> currentBasket = new Dictionary<string, int>();

            // StreamReader: soronként tudjuk kezelni a fájl olvasását, minden ReadLine() hívás a soron következő szöveget adja vissza stringként
            // using automatikusan bezárja a streamet, ha a saját blokkja végére érünk (legtöbb esetben ez a leghatékonyabb)
            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (line == "F" && currentBasket.Count > 0)
                    {
                        baskets.Add(currentBasket);
                        currentBasket = new Dictionary<string, int>();
                    }
                    else
                    {
                        if (currentBasket.ContainsKey(line))
                        {
                            currentBasket[line]++;
                        }
                        else
                        {
                            currentBasket[line] = 1;
                        }
                    }
                }
            }
            return baskets;
        }

        public static int NumberOfItemsPurchasedByFirstCustomer(List<Dictionary<string, int>> payments)
        {
            int counter = 0;
            foreach (KeyValuePair<string, int> item in payments[0])
            {
                counter += item.Value;
            }
            return counter;
        }

        public static void GetInput(out int purchaseNumber, out string itemName, out int quantity)
        {
            Console.Write("Adja meg egy vásárlás sorszámát! ");
            if (!int.TryParse(Console.ReadLine(), out purchaseNumber))
            {
                Console.WriteLine("Helytelen a vásárlás sorszámának típusa :(");
            }

            Console.Write("\nAdja meg egy árucikk nevét! ");
            itemName = Console.ReadLine();

            Console.Write("\nAdja meg a vásárolt darabszámot! ");
            if (!int.TryParse(Console.ReadLine(), out quantity))
            {
                Console.WriteLine("Helytelen a vásárolt darabszám típusa :(");
            }
        }

        public static void CalculationsWithGivenInput(List<Dictionary<string, int>> payments, string itemName)
        {
            int firstIndex = -1;
            for (int i = 0; i < payments.Count; i++)
            {
                if (payments[i].ContainsKey(itemName))
                {
                    firstIndex = i;
                    break;
                }
            }
            Console.WriteLine($"Az első vásárlás sorszáma: {firstIndex + 1}");

            int lastIndex = -1;
            for (int i = payments.Count - 1; i >= 0; i--)
            {
                if (payments[i].ContainsKey(itemName))
                {
                    lastIndex = i;
                    break;
                }
            }
            Console.WriteLine($"Az utolsó vásárlás sorszáma: {lastIndex + 1}");

            int counter = 0;
            for (int i = 0; i < payments.Count; i++)
            {
                if (payments[i].ContainsKey(itemName))
                {
                    counter++;
                }
            }
            Console.WriteLine($"{counter} vásárlás során vettek belőle.");
        }

        public static int CalculationsWithGivenInputVALUE(int quantity)
        {
            //              UGYAN AZON AZ ÁRUCIKKEN
            //  először     500FT
            //  utána       450FT
            //  harmadjára  400FT
            //  további árucikkek 400FT
            //  ...

            int total = 0;
            for (int i = 1; i <= quantity; i++)
            {
                if (i == 1)
                {
                    total += 500;
                }
                else if (i == 2)
                {
                    total += 450;
                }
                else
                {
                    total += 400;
                }
            }
            return total;
        }

        public static void DisplayDictionary(List<Dictionary<string, int>> payments, int purchaseNumber)
        {
            foreach (KeyValuePair<string, int> keyValuePairs in payments[purchaseNumber - 1])
            {
                Console.WriteLine($"{keyValuePairs.Value} {keyValuePairs.Key}");
            }
        }

        public static void SavePrices(List<Dictionary<string, int>> payments, string filePath)
        {
            // StreamWriter: a StreamReader-hez hasonlóan soronként tudjuk kezelni a fájl írását, minden
            // WriteLine() hívás a megadott stringet fogja beleírni a file aktuális végére
            // StreamWriter második paramétere megmondja, hogy felülírjuk-e a fájl korábbi tartalmát (false),
            // vagy meghagyjuk a korábbi tartalmát, és csak a fájl végére kezdünk el további írni (true)
            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                for (int i = 0; i < payments.Count; i++)
                {
                    int totalPrice = 0;
                    foreach (KeyValuePair<string, int> item in payments[i])
                    {
                        int quantity = item.Value;
                        totalPrice += CalculationsWithGivenInputVALUE(quantity);
                    }
                    writer.WriteLine($"{i}: {totalPrice}");
                }
            }
            Console.WriteLine($"Az {filePath} fájl elkészült.");
        }

    }
}
