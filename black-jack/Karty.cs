
public class Karty
{
    public int Number{get;set;}
    public Karty(int number)
    {
        Number = number;
    }

    public void Hit()
    {
        Number = Random.Shared.Next(1, 12);
    }
    
}