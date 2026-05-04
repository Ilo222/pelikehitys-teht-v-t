using System;

namespace NuoliPeli
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tervetuloa nuolikauppaan.");
            Console.WriteLine("Haluatko:");
            Console.WriteLine("1. Teettää nuolen tilaustyönä?");
            Console.WriteLine("2. Ostaa valmiin nuolen?");
            int valinta = int.Parse(Console.ReadLine());

            Nuoli nuoli;

            if (valinta == 2)
            {
                Console.WriteLine("Valitse valmis nuoli:");
                Console.WriteLine("1. Eliittinuoli");
                Console.WriteLine("2. Aloittelijanuoli");
                Console.WriteLine("3. Perusnuoli");

                int valinta2 = int.Parse(Console.ReadLine());

                if (valinta2 == 1)
                    nuoli = Nuoli.LuoEliittiNuoli();
                else if (valinta2 == 2)
                    nuoli = Nuoli.LuoAloittelijaNuoli();
                else
                    nuoli = Nuoli.LuoPerusNuoli();
            }
            else
            {
                Console.WriteLine("Valitse kärki: 1=Puu, 2=Teräs, 3=Timantti");
                int k = int.Parse(Console.ReadLine());

                Console.WriteLine("Valitse perä: 1=Lehti, 2=Kanansulka, 3=Kotkansulka");
                int p = int.Parse(Console.ReadLine());

                Console.WriteLine("Anna pituus (60-100):");
                int pit = int.Parse(Console.ReadLine());

                Karki karki = (Karki)(k - 1);
                Pera pera = (Pera)(p - 1);

                nuoli = new Nuoli(karki, pera, pit);
            }

            Console.WriteLine($"Nuolen hinta on {nuoli.PalautaHinta()} kultarahaa.");
        }
    }
}