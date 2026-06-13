
Player hrac = new Player(0 + Random.Shared.Next(1, 12)+ Random.Shared.Next(1, 12));
Rozdavac rozdavac = new Rozdavac(0 + Random.Shared.Next(1, 12));
Karty karty = new Karty(0);



while (true)
{
    if (hrac.Skore == 21)
    {
        Console.WriteLine("Dostal jste: " +  hrac.Skore);
        Console.WriteLine("!!BLACK JACK!!");
        break;
    }
    
    Console.Clear();
    
    Console.WriteLine("Rozdavac::  " + rozdavac.Skore);
    Console.WriteLine("Hrac::  " + hrac.Skore);
    Console.WriteLine("");
    Console.WriteLine("Hit");
    Console.WriteLine("Stand");
    string input = Console.ReadLine();

    if (input == "hit" || input == "h")
    {
        hrac.Skore = hrac.Skore + karty.Hit();

        if (hrac.Skore == 21)
        {
            Console.WriteLine("Dostal jste: " +  hrac.Skore);
            Console.WriteLine("Winner winner chicken dinner!!");
            break;
        }

        if (hrac.Skore > 21)
        {
            Console.WriteLine("Dostal jste: " +  hrac.Skore);
            Console.WriteLine("Game Over");
            break;
        }
    }

    if (input == "stand" || input == "s")
    {
        Console.WriteLine("Hrači stojí");
        
        rozdavac.Skore = rozdavac.Skore + karty.Hit();

        if (rozdavac.Skore == 21)
        {
            Console.WriteLine("Rozdavač měl: " +  rozdavac.Skore);
            Console.WriteLine("Rozdavač !VYHRÁL!");
            break;
        }

        if (rozdavac.Skore > 21)
        {
            Console.WriteLine("Rozdavač měl: " +  rozdavac.Skore);
            Console.WriteLine("Hráč !VYHRÁL!");
            break;
        }

        if (rozdavac.Skore < 17)
        {
            rozdavac.Skore = rozdavac.Skore + karty.Hit();
            Console.WriteLine("Rozdavač má: " +  rozdavac.Skore);
        }
    }
}