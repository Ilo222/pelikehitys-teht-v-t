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
    }
}