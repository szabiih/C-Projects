using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Tarsalgo
{
    internal class Event
    {
        // Properties
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Identifier { get; set; }
        public string Direction { get; set; }

        //  Konstruktor
        public Event(int hour, int minute, int identifier, string direction)
        {
            this.Hour = hour;
            this.Minute = minute;
            this.Identifier = identifier;
            this.Direction = direction;
        }

        //  Függvények (Methods)    -   ki lehetne szervezni egy külön osztályba, viszont egyenlőre ezzel a megoldással dolgozok (nekem átláthatóbb)
        public static List<Event> LoadEvents(string filePath)
        {
            List<Event> events = new List<Event>();

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"A '{filePath}' nevű fájl nem létezik!");
                return events;
            }
            else
            {
                Console.WriteLine("SIKERES BEOLVASÁS!");
            }

            // StreamReader: soronként tudjuk kezelni a fájl olvasását, minden ReadLine() hívás a soron következő szöveget adja vissza stringként
            // using automatikusan bezárja a streamet, ha a saját blokkja végére érünk (legtöbb esetben ez a leghatékonyabb)
            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] parts = line.Split(' ');

                    int hour = int.Parse(parts[0]);
                    int minute = int.Parse(parts[1]);
                    int identifier = int.Parse(parts[2]);
                    string direction = parts[3];

                    events.Add(new Event(hour, minute, identifier, direction));
                }
            }

            return events;
        }

        public static void DisplayFirstAndLastEventID(List<Event> events)
        {
            int? firstEntry = null;
            int? lastExit = null;

            foreach (Event ev in events)
            {
                if (ev.Direction == "be")
                {
                    firstEntry = ev.Identifier;
                    break;
                }
            }

            for (int i = events.Count - 1; i >= 0; i--)
            {
                if (events[i].Direction == "ki")
                {
                    lastExit = events[i].Identifier;
                    break;
                }
            }

            Console.WriteLine($"Az első belépő: {firstEntry}");
            Console.WriteLine($"Az utolsó kilépő: {lastExit}");
        }

        public static void SaveNumberOfPasses(List<Event> events, string filePath)
        {
            Dictionary<int, int> passes = new Dictionary<int, int>();

            foreach (Event ev in events)
            {
                if (passes.ContainsKey(ev.Identifier))
                {
                    passes[ev.Identifier]++;
                }
                else
                {
                    passes[ev.Identifier] = 1;
                }
            }

            // A dictionary elemeit (KeyValuePair<int,int>) az azonosító (Key) alapján
            // növekvő sorrendbe rendezzük, hogy a fájlba rendezve tudjuk kiírni
            var sorted = passes.OrderBy(x => x.Key);

            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                foreach (KeyValuePair<int, int> item in sorted)
                {
                    writer.WriteLine($"{item.Key} {item.Value}");
                }
            }
            Console.WriteLine($"Az {filePath} fájl elkészült.");
        }

        public static List<int> RemainedInsideAtTheEndOfThePeriod(List<Event> events)
        {
            List<int> inside = new List<int>();

            foreach (Event ev in events)
            {
                if (ev.Direction == "be" && !inside.Contains(ev.Identifier))
                {
                    inside.Add(ev.Identifier);
                }
                else if (ev.Direction == "ki")
                {
                    inside.Remove(ev.Identifier);
                }
            }

            return inside;
        }

        public static void MostPeopleInTheRoom(List<Event> events, out int hour, out int minute)
        {
            int currentCount = 0;
            int maxCount = 0;
            hour = 0;
            minute = 0;

            foreach (Event ev in events)
            {
                if (ev.Direction == "be")
                {
                    currentCount++;
                }

                else if (ev.Direction == "ki")
                {
                    currentCount--;
                }

                if (currentCount > maxCount)
                {
                    maxCount = currentCount;
                    hour = ev.Hour;
                    minute = ev.Minute;
                }
            }
        }

        public static int GetInput()
        {
            //  Zavart, hogy ha nem írunk be semmit exception dob a program
            int input;
            string line;
            do
            {
                Console.Write("Adja meg a személy azonosítóját (1-100)! ");
                line = Console.ReadLine();
            }
            while (string.IsNullOrWhiteSpace(line) || !int.TryParse(line, out input));
            return input;
        }

        public static void DisplayRequestedIDResidenceTime(List<Event> events, int input)
        {
            //  HasValue tulajdonsággal ellenőrizhetjük, hogy van-e értékünk (nem null) - nullable típusok esetén használható
            int? entryHour = null;
            int? entryMinute = null;

            foreach (Event ev in events)
            {
                if (ev.Identifier == input && ev.Direction == "be")
                {
                    entryHour = ev.Hour;
                    entryMinute = ev.Minute;
                }
                else if (ev.Identifier == input && ev.Direction == "ki" && entryHour.HasValue && entryMinute.HasValue)    // csak akkor számoljuk ki a tartózkodási időt, ha van érvényes belépési időpontunk (null értékek ellenőrzése, nem kötelező)
                {
                    //  A :D2 formázás azt jelenti, hogy az egész számot legalább 2 számjeggyel írja ki, szükség esetén vezető nullával (pl. 5 -> 05)
                    Console.WriteLine($"{entryHour.Value:D2}:{entryMinute.Value:D2}-{ev.Hour:D2}:{ev.Minute:D2}");
                    entryHour = null;
                    entryMinute = null;
                }
            }

            if (entryHour.HasValue && entryMinute.HasValue)
            {
                Console.WriteLine($"{entryHour.Value:D2}:{entryMinute.Value:D2}-");
            }
        }





    }
}
