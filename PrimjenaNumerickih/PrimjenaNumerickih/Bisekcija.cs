using System;

public class BisectionMethod
{
    public static void PokreniBisekciju(Func<double, double> funkcija)
    {
        //unos granica intervala
        //unos donje granice intervaala
        Console.Write("Unesite donju granicu (a): ");
        double donjaGranica = double.Parse(Console.ReadLine());
        //unos gornje granice intervala
        Console.Write("Unesite gornju granicu (b): ");
        double gornjaGranica = double.Parse(Console.ReadLine());
        //unos željene preciznosti
        Console.Write("Unesite željenu preciznost (npr. 1e-6): ");
        double preciznost = double.Parse(Console.ReadLine());
        //obrada formata preciznosti za adekvatan prikaz informacija npr. ako je izabrano 1e-7 da na ispisu bude 7 decimala ispisano
        int decimalPlaces = -1 * (int)Math.Floor(Math.Log10(preciznost));
        string format = $"F{decimalPlaces}";
        //broj iteracija zadan zadatkom
        const int maxIteracije = 250;
        //provjera da li su vrijednosti funkcije u zadanim tačkama definisane
        double funkcijaZaDonjuGranicu = funkcija(donjaGranica);

        double funkcijaZaGornjuGranicu = funkcija(gornjaGranica);

        if(double.IsNaN(funkcijaZaDonjuGranicu) || double.IsNaN(funkcijaZaGornjuGranicu))
        {
            Console.WriteLine("Greška: Vrijednosti funkcije u zadanim tačkama nisu definisane.");
            return;
        }

        //provjera da li se rješenje nalazi u intevalu
        if (funkcija(donjaGranica) * funkcija(gornjaGranica) >= 0)
        {
            Console.WriteLine("Greška: Metoda bisekcije ne može se primijeniti. Molimo unesite interval gdje funkcija mijenja predznak.");
            return;
        }
        //ispis tabele
        Console.WriteLine("\nIteracija\t a\t\t b\t\t c\t\t f(c)\t\t Greška");

        //inicijalizacija varijable za sredinu intervala
        double sredinaIntervala = donjaGranica;
        int konacanBrojItracija = 0;
        //for petlja kojom tražimo rješenje
        //krećemo se korz petlju dok ne dostignemo željenu preciznost rezultata ili dok ne dostignemo maksimalan broj iteracija
        for (int i = 1; i <= maxIteracije; i++)
        {
            //računanje sredine intervala
            sredinaIntervala = (donjaGranica + gornjaGranica) / 2;
            double funkcijaSredneIntervala = funkcija(sredinaIntervala);

            //ipsis trenutne iteracije
            Console.WriteLine($"{i}\t\t {donjaGranica.ToString(format)}\t {gornjaGranica.ToString(format)}\t {sredinaIntervala.ToString(format)}\t {funkcijaSredneIntervala.ToString(format)}\t {Math.Abs(gornjaGranica - donjaGranica).ToString(format)}");

            //provjera da li zaustavljamo iteraciju tj. da li smo pronašli približan rezultat
            if (Math.Abs(funkcijaSredneIntervala) < preciznost || Math.Abs(gornjaGranica - donjaGranica) < preciznost)
            {
                Console.WriteLine("\nPostignuta tražena tačnost.");
                break;
            }

            //pomjeranje granice intervala na osnovu predznaka funkcije
            //prvi slučaj gornja granica se pomjera
            //drugi slučaj donja granica se pomjera
            //ako u donjem dijelu intervala funkcija mijenja predznak taj dio nas zanima i obratno
            if (funkcija(donjaGranica) * funkcijaSredneIntervala < 0)
            {
                gornjaGranica = sredinaIntervala;
            }
            else
            {
                donjaGranica = sredinaIntervala;
            }
            konacanBrojItracija = i;
        }
        //konačan ispis rješenja
        Console.WriteLine($"\nRješenje približno iznosi: c ≈ {sredinaIntervala.ToString(format)}");
        Console.WriteLine($"\nBroj iteracija:  {konacanBrojItracija+1}");
    }
}