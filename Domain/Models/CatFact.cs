namespace Domain.Models;

public class CatFact
{
    public string Fact { get; set; }
    public int Length { get; set; }

    public override string ToString()
    {
        return $"\"fact\": \"{Fact}\", \"length\": {Length}";
    }
}