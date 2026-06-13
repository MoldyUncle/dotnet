
Player hrac = new Player(0);
Rozdavac rozdavac = new Rozdavac(0 + Random.Shared.Next(1, 12));
Karty karty = new Karty(0);

while (true)
{
    Console.WriteLine("Rozdavac::  " + rozdavac.Skore);
    Console.WriteLine("Hrac::  " + hrac.Skore);
    Console.WriteLine("");
    Console.WriteLine("Hit");
    Console.WriteLine("Stand");
    string input = Console.ReadLine();

    if (input == "hit" || input == "h")
    {
        hrac.Skore = hrac.Skore + karty.Hit();
    }
}