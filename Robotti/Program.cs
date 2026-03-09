using System;

// Robotti-luokka annettu valmiiksi
public class Robotti
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool OnKäynnissä { get; set; }
    public RobottiKäsky?[] Käskyt { get; } = new RobottiKäsky?[3];

    public void Suorita()
    {
        foreach (RobottiKäsky? käsky in Käskyt)
        {
            käsky?.Suorita(this);
            Console.WriteLine($"[{X} {Y} {OnKäynnissä}]");
        }
    }
}

// Abstrakti komento-luokka
public abstract class RobottiKäsky
{
    public abstract void Suorita(Robotti robotti);
}

// Käynnistä- ja Sammuta-käskyt
public class Käynnistä : RobottiKäsky
{
    public override void Suorita(Robotti robotti)
    {
        robotti.OnKäynnissä = true;
    }
}

public class Sammuta : RobottiKäsky
{
    public override void Suorita(Robotti robotti)
    {
        robotti.OnKäynnissä = false;
    }
}

// Liikkumiskäskyt
public class YlösKäsky : RobottiKäsky
{
    public override void Suorita(Robotti robotti)
    {
        if (robotti.OnKäynnissä)
            robotti.Y++;
    }
}

public class AlasKäsky : RobottiKäsky
{
    public override void Suorita(Robotti robotti)
    {
        if (robotti.OnKäynnissä)
            robotti.Y--;
    }
}

public class VasenKäsky : RobottiKäsky
{
    public override void Suorita(Robotti robotti)
    {
        if (robotti.OnKäynnissä)
            robotti.X--;
    }
}

public class OikeaKäsky : RobottiKäsky
{
    public override void Suorita(Robotti robotti)
    {
        if (robotti.OnKäynnissä)
            robotti.X++;
    }
}

// Pääohjelma
class Program
{
    static void Main()
    {
        Robotti robotti = new Robotti();

        for (int i = 0; i < robotti.Käskyt.Length; i++)
        {
            Console.WriteLine("Syötä käsky (Käynnistä, Sammuta, Ylös, Alas, Vasen, Oikea):");
            string syöte = Console.ReadLine()!.Trim().ToLower();

            robotti.Käskyt[i] = syöte switch
            {
                "käynnistä" => new Käynnistä(),
                "sammuta" => new Sammuta(),
                "ylös" => new YlösKäsky(),
                "alas" => new AlasKäsky(),
                "vasen" => new VasenKäsky(),
                "oikea" => new OikeaKäsky(),
                _ => null
            };
        }

        Console.WriteLine("Suoritetaan käskyt:");
        robotti.Suorita();
    }
}