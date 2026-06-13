
public class Karty
{
    public int Number{get;set;}
    public Karty(int number)
    {
        Number = number;
    }

    public int Hit()
    {
        return Random.Shared.Next(1, 12);
    }
    
}