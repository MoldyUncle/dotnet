
public class Karty
{
    public int Number{get;set;}
    public Karty(int number)
    {
        Number = number;
    }

    public int Hit()                    /// generátor náhodných čísel od 1 do 11
    {
        return Random.Shared.Next(1, 12);
    }
    
}