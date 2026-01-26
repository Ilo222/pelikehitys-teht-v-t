using System;

enum DoorState
{
    Auki,
    Kiinni,
    Lukossa
}

enum DoorAction
{
    Avaa = 1,
    Sulje = 2,
    Lukitse = 3,
    AvaaLukko = 4
}

DoorState doorState = DoorState.Kiinni;

while (true)
{
    Console.WriteLine("------------------------");
    Console.WriteLine("Oven tila: " + doorState);
    Console.WriteLine("Valitse toiminto:");
    Console.WriteLine("1 = Avaa");
    Console.WriteLine("2 = Sulje");
    Console.WriteLine("3 = Lukitse");
    Console.WriteLine("4 = Avaa lukko");
    Console.Write("Valinta: ");

    string input = Console.ReadLine();

    if (!Enum.TryParse(input, out DoorAction action))
    {
        Console.WriteLine("Virheellinen valinta.");
        continue;
    }

    bool onnistui = false;

    switch (action)
    {
        case DoorAction.Avaa:
            if (doorState == DoorState.Kiinni)
            {
                doorState = DoorState.Auki;
                onnistui = true;
            }
            break;

        case DoorAction.Sulje:
            if (doorState == DoorState.Auki)
            {
                doorState = DoorState.Kiinni;
                onnistui = true;
            }
            break;

        case DoorAction.Lukitse:
            if (doorState == DoorState.Kiinni)
            {
                doorState = DoorState.Lukossa;
                onnistui = true;
            }
            break;

        case DoorAction.AvaaLukko:
            if (doorState == DoorState.Lukossa)
            {
                doorState = DoorState.Kiinni;
                onnistui = true;
            }
            break;
    }

    if (onnistui)
        Console.WriteLine("Toiminto onnistui.");
    else
        Console.WriteLine("Toiminto ei ole mahdollinen nykyisessä tilassa.");
}
