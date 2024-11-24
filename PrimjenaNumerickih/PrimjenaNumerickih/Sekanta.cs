using System;

namespace PrimjenaNumerickih
{
    public class SekantnaMetoda
    {
        public static void PokreniMetoduSekante(Func<double, double> funkcija)
        {
            //unos početnih aproksimacija
            Console.Write("Unesite prvu početnu aproksimaciju (x0): ");
            double x0 = double.Parse(Console.ReadLine());

            Console.Write("Unesite drugu početnu aproksimaciju (x1): ");
            double x1 = double.Parse(Console.ReadLine());

            //unos željene preciznosti
            Console.Write("Unesite željenu preciznost (npr. 1e-6): ");
            double preciznost = double.Parse(Console.ReadLine());
            //obrada formata preciznosti za adekvatan prikaz informacija npr. ako je izabrano 1e-7 da na ispisu bude 7 decimala ispisano
            //log10 nam iz 1e-6 tj. 0.000001 daje -6
            //math floor nam daje najbliži integer tj. ono -6 što pomnoženo sa -1 nam daje 6 (moglo se i abs koristiti)
            int decimalPlaces = -1 * (int)Math.Floor(Math.Log10(preciznost));
            //dakle 6 što smo dobili je broj decimala koje želimo da vidimo u ispisima
            string format = $"F{decimalPlaces}";
            //broj iteracija zadan zadatkom
            const int maxIteracije = 100;
            //izgled tabele
            Console.WriteLine("\nIteracija\t x0\t\t x1\t\t x2\t\t f(x2)\t\t Greška");
            //for petlja kojom tražimo rješenje
            //petlja vrti dok ne prođe maksimalan broj iteracija
            //ili dok funkcija ne može dalje konvergirati
            //ili dok ne nađemo približno rješenje
            for (int i = 1; i <= maxIteracije; i++)
            {
                double f0 = funkcija(x0);
                double f1 = funkcija(x1);
                //provjera da li zadane tačke definisane za funkciju
                if (double.IsNaN(f0) || double.IsNaN(f1))
                {
                    Console.WriteLine("Greška: Vrijednosti funkcije u zadanim tačkama nisu definisane.");
                    return;
                }
                //provjera da li funkcija može dalje konvergirati
                //u biti ako je ovaj uslov ispunjen to znači da nam svaki naredni korak neće značajno utjecati na rezultat
                if (Math.Abs(f1 - f0) < preciznost)
                {
                    Console.WriteLine("Greška: Funkcija ne može dalje konvergirati.");
                    break;
                }

                //računanje nove aproksimacije
                double x2 = x1 - f1 * (x1 - x0) / (f1 - f0);
                //računanje greške
                double greska = Math.Abs(x2 - x1);

                //ispis trenutnih vrijednosti
                Console.WriteLine($"{i}\t\t {x0.ToString(format)}\t {x1.ToString(format)}\t {x2.ToString(format)}\t {funkcija(x2).ToString(format)}\t {greska.ToString(format)}");

                //provjera da li smo dostigli pšribližan rezultat
                if (greska < preciznost)
                {
                    Console.WriteLine("\nPostignuta tražena tačnost.");
                    Console.WriteLine($"\nPribližno rješenje: x ≈ {x1.ToString(format)}");
                    Console.WriteLine($"\nBroj iteracija:  {i}");
                    break;
                }

                //postavljanje vrijednosti za iduću iteraciju
                x0 = x1;
                x1 = x2;
            }
        }
    }
}
