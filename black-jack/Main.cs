
int hrac_vyhra = 0;
int rozdavac_vyhra = 0;
int remiza = 0;

while (true)
{
    Console.ForegroundColor = ConsoleColor.Yellow;                  ////Záznam výher
    Console.WriteLine("************************");
    Console.WriteLine("Hráč výhry:: " + hrac_vyhra);
    Console.WriteLine("Rozdavač výhry:: " +  rozdavac_vyhra);
    Console.WriteLine("Remízy:: " + remiza);
    Console.WriteLine("************************");
    Console.WriteLine("");
    Console.ResetColor();
    
    Player hrac = new Player(0 + Random.Shared.Next(1, 12)+ Random.Shared.Next(1, 12));/// hráč začíná s 2 náh. kartama
    Rozdavac rozdavac = new Rozdavac(0 + Random.Shared.Next(1, 12));    /// Rozdavač začíná s jednou vyditelnou náhodnou kartou
    Karty karty = new Karty(0);
    bool konec = false;
    
    while (true)
    {
        if (hrac.Skore == 21)
        {
            Console.WriteLine("Dostal jste: " +  hrac.Skore);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("!!BLACK JACK!!");
            hrac_vyhra++;
            break;
        }
        
        Console.WriteLine("Rozdavac::  " + rozdavac.Skore);
        Console.WriteLine("Hrac::  " + hrac.Skore);
        Console.WriteLine("Hit");
        Console.WriteLine("Stand");
        string input = Console.ReadLine();
    
        if (input == "hit" || input == "h")                     ////HIT
        {
            Console.Clear();
            hrac.Skore = hrac.Skore + karty.Hit();              /// hrac dostane náhodnou kartu
    
            if (hrac.Skore == 21)
            {
                Console.WriteLine("Dostal jste: " +  hrac.Skore);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Winner winner chicken dinner!!");
                hrac_vyhra ++;
                break;
            }
    
            if (hrac.Skore > 21)
            {
                Console.WriteLine("Dostal jste: " +  hrac.Skore);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Rozdavač !VYHRÁL!");
                rozdavac_vyhra ++;
                break;
            }
        }
    
        else if (input == "stand" || input == "s")                   ///STAND
        {
            Console.WriteLine("Hrači stojí");
            
            rozdavac.Skore = rozdavac.Skore + karty.Hit();      ///Rozdavač ukáže otočenou druhou kartu
    
            while (true)
            {
                if (rozdavac.Skore == 21)
                {
                    Console.Clear();
                    Console.WriteLine("Rozdavač měl: " +  rozdavac.Skore);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Rozdavač !VYHRÁL!");
                    rozdavac_vyhra ++;
                    konec = true;
                    break;
                }
                
                if (rozdavac.Skore > 21)
                {
                    Console.WriteLine("Rozdavač měl: " +  rozdavac.Skore);
                    Console.WriteLine("Rozdavač přesáhl 21");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Hráč !VYHRÁL!");
                    hrac_vyhra ++;
                    konec = true;
                    break;
                }
    
                if (rozdavac.Skore >= 17)
                {
                    if (rozdavac.Skore > hrac.Skore)        ///rozdavač má víc než hráč tak vyhrává
                    {
                        Console.WriteLine("Rozdac měl: "  +  rozdavac.Skore);
                        Console.WriteLine("Hráč měl: " + hrac.Skore);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Rozdavač !VYHRÁL!");
                        rozdavac_vyhra ++;
                        konec = true;
                        break;
                    }
    
                    if (rozdavac.Skore < hrac.Skore)        ///Hráč má víc takže vyhrává
                    {
                        Console.WriteLine("Rozdac měl: "  +  rozdavac.Skore);
                        Console.WriteLine("Hráč měl: " + hrac.Skore);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Hráč !VYHRÁL!");
                        hrac_vyhra ++;
                        konec = true;
                        break;
                    }
    
                    if (rozdavac.Skore == hrac.Skore)       ///Hrác a rozdavač mají stejně takže je remíza
                    {
                        Console.WriteLine("Rozdac měl: "  +  rozdavac.Skore);
                        Console.WriteLine("Hráč měl: " + hrac.Skore);
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("PUSH");
                        remiza ++;
                        konec = true;
                        break;
                    }
                }
                
                if (rozdavac.Skore < 17)                        /// rozdavač si bere dokud nemá alespoň 17
                {
                    rozdavac.Skore = rozdavac.Skore + karty.Hit();
                    Console.WriteLine("Rozdavač má: " +  rozdavac.Skore);
                }
            }
    
            
        }

        else
        {
            Console.Clear();
        }
        
        if (konec == true)
        {
            Console.ResetColor();
            hrac.Skore = 0;
            rozdavac.Skore = 0;
            karty.Number = 0;
            konec = false;
            break;
        }
    }
}
