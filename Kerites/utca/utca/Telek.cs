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
            return telekLista.Count;
        }

        public static void UtolsoTelek(List<Telek> telekLista, List<Telek> parosTelkek, List<Telek> paratlanTelkek)
        {
            //  először return-öt és out paramétert használtam, hogy a Program.cs-ben irassam ki az értékeket a Console.WriteLine() metódus segítségével, viszont végül úgy döntöttem, hogy itt oldom meg a kiíratást (azaz void a függvény)

            Telek utolsoTelek = telekLista[telekLista.Count - 1];
            int oldal = utolsoTelek.Oldal;

            foreach (Telek telek in telekLista)
            {
                if (telek.Oldal % 2 == 0)
                {
                    parosTelkek.Add(telek);
                }
                else
                {
                    paratlanTelkek.Add(telek);
                }
            }

            if (oldal % 2 == 0)
            {
                Console.WriteLine("A páros oldalon adták el az utolsó telket.");
                Console.WriteLine($"Az utolsó telek házszáma: {parosTelkek.Count * 2}");
            }
            else
            {
                Console.WriteLine("A páratlan oldalon adták el az utolsó telket.");
                Console.WriteLine($"Az utolsó telek házszáma: {paratlanTelkek.Count * 2 - 1}");
            }
        }

        public static void UgyanOlyanSzinuTelekKerites(List<Telek> paratlanTelkek)
        {
            char elozoSzin = ' ';
            int hazszam = -1;

            foreach (Telek telek in paratlanTelkek)
            {
                char mostaniSzin = telek.Kerites;

                if (elozoSzin == mostaniSzin && mostaniSzin != ':' && mostaniSzin != '#' && elozoSzin != ':' && elozoSzin != '#')
                {
                    Console.WriteLine($"A szomszédossal egyezik a kerítés színe: {hazszam}");
                    break;
                }

                hazszam += 2;
                elozoSzin = telek.Kerites;
            }
        }

        public static void TelekKeresese(List<Telek> parosTelkek, List<Telek> paratlanTelkek)
        {
            Console.WriteLine("Adjon meg egy házszámot!");
            int input = int.Parse(Console.ReadLine());

            Telek keresettTelek = null;

            if (input % 2 == 0)
            {
                int index = input / 2 - 1;
                if (index >= 0 && index < parosTelkek.Count)
                {
                    keresettTelek = parosTelkek[index];
                }
            }
            else
            {
                int index = 0;  //  ide kell írni
                if (index >= 0 && index < paratlanTelkek.Count)
                {
                    keresettTelek= paratlanTelkek[index];
                }
            }

            //  ide kell írni

        }

        //  egyedül csináltam meg az egészet xDD
    }
}
