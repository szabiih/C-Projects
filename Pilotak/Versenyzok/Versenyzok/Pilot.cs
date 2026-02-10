using System;
using System.Collections.Generic;
using System.Text;

namespace Versenyzok
{
    internal class Pilot
    {
        // Properties   -   A property egy olyan publikus tulajdonság, amelyen keresztül biztonságosan érjük el és módosítjuk az osztály belső (privát) adatait get és set segítségével.
        //                  (A C# fordító automatikusan létrehoz egy privát mezőt)
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public int? StartNumber { get; set; }       //  lehet szám vagy null

        //  Konstruktor
        public Pilot(string name, DateTime dateOfBirth, string nationality, int? startNumber)
        {
            //  Bal oldalon: a property-k, Jobb oldalon: a konstruktor paraméterei
            //  A this kulcsszó az osztály aktuális példányára (objektumra) való hivatkozásra szolgál.
            this.Name = name;
            this.DateOfBirth = dateOfBirth;
            this.Nationality = nationality;
            this.StartNumber = startNumber;
        }

        //  Függvények (Methods)
        public static List<Pilot> LoadPilots(string filePath, out string[] header)
        {
            List<Pilot> pilots = new List<Pilot>();
            header = null;

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"A '{filePath}' nevű fájl nem létezik!");
                return pilots;
            }
            else
            {
                Console.WriteLine("SIKERES BEOLVASÁS!");
            }

            // StreamReader: soronként tudjuk kezelni a fájl olvasását, minden ReadLine() hívás a soron következő szöveget adja vissza stringként
            // using automatikusan bezárja a streamet, ha a saját blokkja végére érünk (legtöbb esetben ez a leghatékonyabb)
            using (StreamReader reader = new StreamReader(filePath))
            {
                header = reader.ReadLine().Split(';');

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] parts = line.Split(';');

                    string name = parts[0];
                    DateTime dateOfBirth = DateTime.Parse(parts[1]);
                    string nationality = parts[2];

                    int? startNumber = null;
                    if (!string.IsNullOrEmpty(parts[3]))
                    {
                        startNumber = int.Parse(parts[3]);
                    }

                    pilots.Add(new Pilot(name, dateOfBirth, nationality, startNumber));
                }
            }

            return pilots;
        }




    }
}
