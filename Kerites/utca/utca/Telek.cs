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
        public int Kerites { get; set; }

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

    }
}
