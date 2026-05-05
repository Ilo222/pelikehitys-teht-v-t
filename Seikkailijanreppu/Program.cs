using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

class Tavara
{
    private double paino;
    private double tilavuus;

    public double Paino => paino;
    public double Tilavuus => tilavuus;

    public Tavara(double paino, double tilavuus)
    {
        this.paino = paino;
        this.tilavuus = tilavuus;
    }

    public override string ToString()
    {
        return GetType().Name;
    }
}

class Nuoli : Tavara { public Nuoli() : base(0.1, 0.05) { } }
class Jousi : Tavara { public Jousi() : base(1, 4) { } }
class Koysi : Tavara { public Koysi() : base(1, 1.5) { } }
class Vesi : Tavara { public Vesi() : base(2, 2) { } }
class RuokaAnnos : Tavara { public RuokaAnnos() : base(1, 0.5) { } }
class Miekka : Tavara { public Miekka() : base(5, 3) { } }

class Reppu
{
    private List<Tavara> tavarat = new List<Tavara>();

    private int maxTavarat;
    private double maxPaino;
    private double maxTilavuus;

    public int TavaroidenMaara => tavarat.Count;
    public double NykyinenPaino => tavarat.Sum(t => t.Paino);
    public double NykyinenTilavuus => tavarat.Sum(t => t.Tilavuus);

    public Reppu(int maxTavarat, double maxPaino, double maxTilavuus)
    {
        this.maxTavarat = maxTavarat;
        this.maxPaino = maxPaino;
        this.maxTilavuus = maxTilavuus;
    }

    public bool Lisaa(Tavara tavara)
    {
        if (tavarat.Count >= maxTavarat)
        {
            Console.WriteLine("Liikaa tavaroita!");
            return false;
        }

        if (NykyinenPaino + tavara.Paino > maxPaino)
        {
            Console.WriteLine("Liikaa painoa!");
            return false;
        }

        if (NykyinenTilavuus + tavara.Tilavuus > maxTilavuus)
        {
            Console.WriteLine("Liikaa tilavuutta!");
            return false;
        }

        tavarat.Add(tavara);
        Console.WriteLine("Lisätty: " + tavara.GetType().Name);
        return true;
    }

    public void TulostaTiedot()
    {
        Console.WriteLine($"Tavarat: {tavarat.Count}/{maxTavarat}");
        Console.WriteLine($"Paino: {NykyinenPaino}/{maxPaino}");
        Console.WriteLine($"Tilavuus: {NykyinenTilavuus}/{maxTilavuus}");
    }

    public override string ToString()
    {
        if (tavarat.Count == 0)
            return "Repussa ei ole tavaroita.";

        return "Repussa on seuraavat tavarat: " + string.Join(", ", tavarat);
    }
}

class Program
{
    static void Main()
    {
        CultureInfo.CurrentCulture = new CultureInfo("fi-FI");

        Reppu reppu = new Reppu(10, 30, 20);

        // Tulostetaan repun sisältö ennen kuin lisätään mitään
        Console.WriteLine(reppu);

        while (true)
        {
            Console.WriteLine("\n--- REPPU ---");
            reppu.TulostaTiedot();

            Console.WriteLine("\n1 - Nuoli");
            Console.WriteLine("2 - Jousi");
            Console.WriteLine("3 - Köysi");
            Console.WriteLine("4 - Vettä");
            Console.WriteLine("5 - Ruokaa");
            Console.WriteLine("6 - Miekka");
            Console.WriteLine("0 - Lopeta");

            Console.Write("Valinta: ");
            string? valinta = Console.ReadLine();

            if (valinta == "0")
                break;

            Tavara? tavara = valinta switch
            {
                "1" => new Nuoli(),
                "2" => new Jousi(),
                "3" => new Koysi(),
                "4" => new Vesi(),
                "5" => new RuokaAnnos(),
                "6" => new Miekka(),
                _ => null
            };

            if (tavara == null)
            {
                Console.WriteLine("Virheellinen valinta.");
                continue;
            }

            reppu.Lisaa(tavara);
        }
    }
}