using System;
using System.Collections.Generic;

namespace Ruoka_annos
{
    public enum Paaruoka
    {
        nautaa,
        kanaa,
        kasviksia
    }

    public enum Lisuke
    {
        perunaa,
        riisiä,
        pastaa
    }

    public enum Kastike
    {
        curry,
        hapanimelä,
        pippuri,
        chili
    }

    public class Ateria
    {
        public Paaruoka Paaruoka { get; set; }
        public Lisuke Lisuke { get; set; }
        public Kastike Kastike { get; set; }

        public Ateria(Paaruoka p, Lisuke l, Kastike k)
        {
            Paaruoka = p;
            Lisuke = l;
            Kastike = k;
        }

        public void Tulosta()
        {
            Console.WriteLine($"{Paaruoka} ja {Lisuke} {Kastike}-kastikkeella");
        }
    }

    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Tervetuloa ravintolaan\n");

            List<Ateria> ateriat = new List<Ateria>();

            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine($"Luo ateria {i}");

                Paaruoka p = KysyEnum<Paaruoka>("Valitse pääraaka-aine");
                Lisuke l = KysyEnum<Lisuke>("Valitse lisuke");
                Kastike k = KysyEnum<Kastike>("Valitse kastike");

                ateriat.Add(new Ateria(p, l, k));
                Console.WriteLine();
            }

            Console.WriteLine("Valitsemasi ateriat:");
            foreach (Ateria a in ateriat)
            {
                a.Tulosta();
            }

            Console.WriteLine("\nPaina Enter lopettaaksesi...");
            Console.ReadLine();
        }

        static T KysyEnum<T>(string otsikko) where T : struct, Enum
        {
            while (true)
            {
                Console.WriteLine(otsikko + ":");

                foreach (var arvo in Enum.GetValues(typeof(T)))
                {
                    Console.WriteLine("- " + arvo);
                }

                // 🔹 NULL-TURVALLINEN ratkaisu
                string syote = Console.ReadLine() ?? "";

                if (Enum.TryParse<T>(syote, true, out T tulos))
                {
                    return tulos;
                }

                Console.WriteLine("Virheellinen syöte, yritä uudelleen.\n");
            }
        }
    }
}