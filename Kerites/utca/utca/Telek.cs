using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace utca
{
    internal class Telek
    {
        // Properties   -   A property egy olyan publikus tulajdonság, amelyen keresztül biztonságosan érjük el és módosítjuk az osztály belső (privát) adatait get és set segítségével.
        //                  (A C# fordító automatikusan létrehoz egy privát mezőt)
        public int Oldal { get; set; }
        public int Szelesseg { get; set; }
        public char Kerites { get; set; }

        //  Konstruktor
        public Telek(int oldal, int szelesseg, char kerites)
        {
            //  Bal oldalon: a property-k, Jobb oldalon: a konstruktor paraméterei
            //  A this kulcsszó az osztály aktuális példányára (objektumra) való hivatkozásra szolgál.
            this.Oldal = oldal;
            this.Szelesseg = szelesseg;
            this.Kerites = kerites;
        }

        //  Függvények (Methods)
        public static List<Telek> Beolvasas(string fajlNev)
        {
            List<Telek> telekLista = new List<Telek>();

            // StreamReader: soronként tudjuk kezelni a fájl olvasását, minden ReadLine() hívás a soron következő szöveget adja vissza stringként
            // using automatikusan bezárja a streamet, ha a saját blokkja végére érünk (legtöbb esetben ez a leghatékonyabb)
            using (StreamReader reader = new StreamReader(fajlNev))
            {
                if (!File.Exists(Program.FAJLNEV))
                {
                    Console.WriteLine("A 'kerites.txt' nevű fájl nem létezik!");
                }
                else
                {
                    Console.WriteLine("SIKERES BEOLVASÁS!");
                }

                while (!reader.EndOfStream)
                {
                    string sor = reader.ReadLine();
                    string[] adatok = sor.Split(' ');

                    int oldal = int.Parse(adatok[0]);
                    int szelesseg = int.Parse(adatok[1]);
                    char kerites = char.Parse(adatok[2]);

                    telekLista.Add(new Telek(oldal, szelesseg, kerites));
                }
            }

            return telekLista;
        }

        public static int EladottTelkekSzama(List<Telek> telekLista)
        {
            return telekLista.Count();
        }


    }
}
