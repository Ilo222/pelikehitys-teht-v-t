namespace NuoliPeli
{
    class Nuoli
    {
        private Karki karki;
        private Pera pera;
        private int pituus;

        public Nuoli(Karki karki, Pera pera, int pituus)
        {
            this.karki = karki;
            this.pera = pera;
            this.pituus = pituus;
        }

        public Karki GetKarki() => karki;
        public Pera GetPera() => pera;
        public int GetPituus() => pituus;

        public int PalautaHinta()
        {
            int hinta = 0;

            switch (karki)
            {
                case Karki.Puu: hinta += 3; break;
                case Karki.Teras: hinta += 5; break;
                case Karki.Timantti: hinta += 50; break;
            }

            switch (pera)
            {
                case Pera.Lehti: hinta += 0; break;
                case Pera.Kanansulka: hinta += 1; break;
                case Pera.Kotkansulka: hinta += 5; break;
            }

            hinta += (int)(pituus * 0.05);

            return hinta;
        }
    }
}