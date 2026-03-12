using System;

struct Koordinaatti
{
    public int X { get; private set; }
    public int Y { get; private set; }

    public Koordinaatti(int x, int y)
    {
        X = x;
        Y = y;
    }

    public bool OnVieressa(Koordinaatti toinen)
    {
        int dx = Math.Abs(X - toinen.X);
        int dy = Math.Abs(Y - toinen.Y);

        return dx <= 1 && dy <= 1 && !(dx == 0 && dy == 0);
    }
}

class Program
{
    static void Main()
    {
        Koordinaatti keski = new Koordinaatti(0, 0);

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                Koordinaatti k = new Koordinaatti(x, y);

                if (k.X == keski.X && k.Y == keski.Y)
                {
                    Console.WriteLine($"Annettu koordinaatti {x},{y} on koordinaatissa 0,0.");
                }
                else if (k.OnVieressa(keski))
                {
                    Console.WriteLine($"Annettu koordinaatti {x},{y} on koordinaatin 0,0 vieressä.");
                }
            }
        }
    }
}