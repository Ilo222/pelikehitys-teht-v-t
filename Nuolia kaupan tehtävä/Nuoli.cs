namespace NuoliPeli
{
    class Nuoli
    {
        public Karki Karki { get; }
        public Pera Pera { get; }
        public int Pituus { get; }

        public Nuoli(Karki karki, Pera pera, int pituus)
        {
            Karki = karki;
            Pera = pera;
            Pituus = pituus;
        }

        public int PalautaHinta()
        {
            int hinta = 0;

            switch (Karki)
            {
                case Karki.Puu: hinta += 3; break;
                case Karki.Teras: hinta += 5; break;
                case Karki.Timantti: hinta += 50; break;
            }

            switch (Pera)
            {
                case Pera.Lehti: hinta += 0; break;
                case Pera.Kanansulka: hinta += 1; break;
                case Pera.Kotkansulka: hinta += 5; break;
            }

            hinta += (int)(Pituus * 0.05);

            return hinta;
        }

        // Valmiit nuolipohjat
        public static Nuoli LuoEliittiNuoli()
        {
            return new Nuoli(Karki.Timantti, Pera.Kotkansulka, 100);
        }

        public static Nuoli LuoAloittelijaNuoli()
        {
            return new Nuoli(Karki.Puu, Pera.Kanansulka, 70);
        }

        public static Nuoli LuoPerusNuoli()
        {
            return new Nuoli(Karki.Teras, Pera.Kanansulka, 85);
        }
    }
}