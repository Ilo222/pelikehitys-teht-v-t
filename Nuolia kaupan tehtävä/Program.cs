using System;

namespace NuoliPeli
{
    enum Karki { Puu, Teras, Timantti }
    enum Pera { Lehti, Kanansulka, Kotkansulka }

    class Nuoli
    {
        public Karki KarkiTyyppi { get; }
        public Pera PeraTyyppi { get; }
        public int Pituus { get; }

        public Nuoli(Karki karki, Pera pera, int pituus)
        {
            if (pituus < 60 || pituus > 100)
                throw new ArgumentException("Nuolen pituuden tulee olla välillä 60-100 cm");

            KarkiTyyppi = karki;
            PeraTyyppi = pera;
            Pituus = pituus;
        }

        public double PalautaHinta()
        {
            double hintaKarki = KarkiTyyppi switch
            {
                Karki.Puu => 3,
                Karki.Teras => 5,
                Karki.Timantti => 50,
                _ => 0
            };

            double hintaPera = PeraTyyppi switch
            {
                Pera.Lehti => 0,
                Pera.Kanansulka => 1,
                Pera.Kotkansulka => 5,
                _ => 0
            };

            double hintaVarsi = Pituus * 0.05;

            return hintaKarki + hintaPera + hintaVarsi;
        }
    }

    class Program
    {
        static void Main()
        {
            // Luetaan syötteet ja käsitellään mahdollinen null
            Console.Write("Minkälainen kärki (puu, teräs, timantti)?: ");
            string karkiInput = Console.ReadLine() ?? "";

            Console.Write("Minkälaiset sulat (lehti, kanansulka, kotkansulka)?: ");
            string peraInput = Console.ReadLine() ?? "";

            Console.Write("Nuolen pituus sentteinä (60-100): ");
            string pituusInput = Console.ReadLine() ?? "";

            if (!int.TryParse(pituusInput, out int pituus))
            {
                Console.WriteLine("Virheellinen syöte pituudelle!");
                return;
            }

            // Muutetaan syöte enumiksi
            Karki karki = karkiInput.ToLower() switch
            {
                "puu" => Karki.Puu,
                "teräs" => Karki.Teras,
                "timantti" => Karki.Timantti,
                _ => throw new Exception("Virheellinen kärki")
            };

            Pera pera = peraInput.ToLower() switch
            {
                "lehti" => Pera.Lehti,
                "kanansulka" => Pera.Kanansulka,
                "kotkansulka" => Pera.Kotkansulka,
                _ => throw new Exception("Virheellinen perä")
            };

            Nuoli nuoli = new Nuoli(karki, pera, pituus);
            Console.WriteLine($"Tämän nuolen hinta on {nuoli.PalautaHinta()} kultarahaa.");
        }
    }
}