using System;

public class ProstaIteracija
{
    public static void PokreniProstuIteraciju(Func<double, double> funkcija, Func<double, double> iterativnaFunkcija)
    {
        //unos početne aproksimacije
        Console.Write("Unesite početnu aproksimaciju (x0): ");
        double x0 = double.Parse(Console.ReadLine());

        //unos željene preciznosti
        Console.Write("Unesite željenu preciznost (npr. 1e-6): ");
        double preciznost = double.Parse(Console.ReadLine());
        //obrada formata preciznosti za adekvatan prikaz informacija npr. ako je izabrano 1e-7 da na ispisu bude 7 decimala ispisano
        int decimalPlaces = -1 * (int)Math.Floor(Math.Log10(preciznost));
        string format = $"F{decimalPlaces}";
        //max broj iteracija zadan zadatkom
        const int maxIteracije = 500;
        //inicijalizacija trenutne i prethodne greške
        double greska = double.MaxValue;
        double prethodnaGreska = greska;

        Console.WriteLine("\nIteracija\t x\t\t f(x)\t\t Greška");
        //for petlja kojom tražimo rješenje
        //krećemo se korz petlju dok ne dostignemo željenu preciznost rezultata
        //ili dok ne dostignemo maksimalan broj iteracija
        //ili dok ne dođemo do divergencije
        for (int i = 1; i <= maxIteracije; i++)
        {
            //inicijalizacija vrijednosti iterativne funkcije
            double x1 = iterativnaFunkcija(x0);
            greska = Math.Abs(x1 - x0);

            //ispis trenutnih vrijednosti
            Console.WriteLine($"{i}\t\t {x1.ToString(format)}\t {funkcija(x1).ToString(format)}\t {greska.ToString(format)}");

            //provjera da li smo došli do željene preciznosti
            if (greska < preciznost)
            {
                Console.WriteLine("\nPostignuta tražena tačnost.");
                Console.WriteLine($"\nPribližno rješenje: x ≈ {x1.ToString(format)}");
                Console.WriteLine($"\nBroj iteracija:  {i}");
                break;
            }

            //provjera divergiranja
            if (i > 1 && greska > prethodnaGreska)
            {
                Console.WriteLine("\nIterativni postupak divergira.");
                break;
            }
            //postavljamo vrijednosti za narednu iteraciju
            prethodnaGreska = greska;
            x0 = x1;
        }
    }
}
