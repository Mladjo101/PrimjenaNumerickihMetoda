using System;

namespace PrimjenaNumerickih
{
    public class Menu
    {
        static void Main()
        {
            {
                //Zadaci rađeni su grupa B
                //Zadaća se sastoji od 4 file-a: main gdje su meniji te file za svaku od traženih metoda
                //Prve tri jednačine su kocipirane kao dio 4. zadatka dakle nekoliko zadataka za testiranje metoda
                //Četvrta jednačina predstavlja rješenje 5. zadatka zadaće

                //while petlja koja služi kao početni meni
                //kroz ovu petlju se vrši odabir funkcije koju korisnik želi rješavati
                //za odabranu funkciju se uzima i iterativna funkcija, ali ona služi samo za rješavanje metodom proste iteracije
                while (true)
                {
                    //ispis menija
                    Console.WriteLine("Odaberite funkciju za rješavanje:");
                    Console.WriteLine("1 - f(x) = x^2 - x - 2");
                    Console.WriteLine("2 - f(x) = x^2 - 2");
                    Console.WriteLine("3 - f(x) = x^3 - 3x");
                    Console.WriteLine("4 - f(x) = sin(x) - (3x / 4)");
                    Console.WriteLine("0 - Izlaz");
                    Console.Write("Vaš izbor: ");

                    //unos odabira korisnika
                    string izbor = Console.ReadLine();
                    Func<double, double> odabranaFunkcija = null;
                    Func<double, double> iterativnaFunkcija = null;

                    //switch case koji obrađuje odabir
                    switch (izbor)
                    {
                        case "1":
                            odabranaFunkcija = x => x * x - x - 2;
                            iterativnaFunkcija = x => Math.Sqrt(x + 2);
                            break;
                        case "2":
                            odabranaFunkcija = x => x * x - 2;
                            iterativnaFunkcija = x => 0.5 * (x + 2 / x);
                            break;
                        case "3":
                            odabranaFunkcija = x => x * x * x - 3 * x;
                            iterativnaFunkcija = x => Math.Cbrt(3 * x);
                            break;
                        case "4":
                            odabranaFunkcija = x => Math.Sin(x) - (3 * x / 4);
                            iterativnaFunkcija = x => (4 * Math.Sin(x)) / 3;
                            break;
                        case "0":
                            return; //izlaz iz programa
                        default:
                            Console.WriteLine("Pogrešan unos. Pokušajte ponovo.");
                            continue;
                    }
                    //čišćenje konzole te poziv narednog dijela menija
                    Console.Clear();
                    OdabirMetodeRjesavanja(odabranaFunkcija, iterativnaFunkcija);
                }
            }
        }
        //metoda prihvata dva parametra to jeste dvije funkcije
        //prva funkcija je funkcija koju korisnik želi rješavati
        //druga funkcija je iterativna funkcija koja se koristi samo za metodu proste iteracije
        private static void OdabirMetodeRjesavanja(Func<double, double> funkcija, Func<double, double> iterativnaFunkcija)
        {
            while (true)
            {
                //ova while petlja se koristi za drugi meni
                //služi za odabir metode kojom želimo rješavati odabrnu jednačinu
                Console.WriteLine("Odaberite metodu za rješavanje nelinearnih jednačina:");
                Console.WriteLine("1 - Metoda bisekcije");
                Console.WriteLine("2 - Metoda proste iteracije");
                Console.WriteLine("3 - Metoda sekante");
                Console.WriteLine("0 - Povratak");
                Console.Write("Vaš izbor: ");

                string izbor = Console.ReadLine();
                //switch case koji na osnovu izbora pokreće metodu te joj prosljeđuje potrebne parametre
                switch (izbor)
                {
                    //na osnovu odabira korisnika poziva se odgovarajuća metoda
                    case "1":
                        BisectionMethod.PokreniBisekciju(funkcija);
                        break;
                    case "2":
                        ProstaIteracija.PokreniProstuIteraciju(funkcija, iterativnaFunkcija);
                        break;
                    case "3":
                        SekantnaMetoda.PokreniMetoduSekante(funkcija);
                        break;
                    case "0":
                        return; //povratak na odabit funkcije
                    default:
                        Console.WriteLine("Pogrešan unos. Pokušajte ponovo.");
                        break;
                }
                Console.WriteLine("\nPritisnite Enter za povratak na meni metoda...");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
