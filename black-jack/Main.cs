
Player hrac = new Player(0 + Random.Shared.Next(1, 12)+ Random.Shared.Next(1, 12));/// hráč začíná s 2 náh. kartama
Rozdavac rozdavac = new Rozdavac(0 + Random.Shared.Next(1, 12));    /// Rozdavač začíná s jednou vyditelnou náhodnou kartou
Karty karty = new Karty(0);

while (true)
{
    if (hrac.Skore == 21)
    {
        Console.WriteLine("Dostal jste: " +  hrac.Skore);
        Console.WriteLine("!!BLACK JACK!!");
        break;
    }
    
    Console.WriteLine("Rozdavac::  " + rozdavac.Skore);
    Console.WriteLine("Hrac::  " + hrac.Skore);
    Console.WriteLine("");
    Console.WriteLine("Hit");
    Console.WriteLine("Stand");
    string input = Console.ReadLine();

    if (input == "hit" || input == "h")                     ////HIT
    {
        hrac.Skore = hrac.Skore + karty.Hit();              /// hrac dostane náhodnou kartu

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

    if (input == "stand" || input == "s")                   ///STAND
    {
        Console.WriteLine("Hrači stojí");
        
        rozdavac.Skore = rozdavac.Skore + karty.Hit();      ///Rozdavač ukáže otočenou druhou kartu

        while (true)
        {
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
            
            if (rozdavac.Skore < 17)                        /// rozdavač si bere dokud nemá alespoň 17
            {
                rozdavac.Skore = rozdavac.Skore + karty.Hit();
                Console.WriteLine("Rozdavač má: " +  rozdavac.Skore);
            }
        }

        
    }
}