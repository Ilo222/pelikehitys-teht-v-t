using System;

namespace NuoliPeli
{
    enum Karki { Puu, Teras, Timantti }
    enum Pera { Lehti, Kanansulka, Kotkansulka }

    class Program
    {
        static void Main()
        {
            // Luetaan syötteet ja käsitellään mahdollinen null
            Console.Write("Minkälainen kärki (puu, teräs, timantti)?: ");
            string karkiInput = Console.ReadLine() ?? "";

            Console.Write("Minkälaiset sulat (lehti, kanansulka, kotkansulka)?: ");
            string peraInput = Console.ReadLine() ?? "";

            int pituus = 0;
            while (true)
            {
                Console.Write("Nuolen pituus sentteinä (60-100): ");
                string pituusInput = Console.ReadLine() ?? "";

                if (!int.TryParse(pituusInput, out pituus))
                {
                    Console.WriteLine("Virheellinen syöte pituudelle!");
                    continue;
                }
                else
                {
                    break;
                }
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