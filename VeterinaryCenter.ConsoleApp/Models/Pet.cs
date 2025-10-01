namespace VeterinaryCenter.ConsoleApp.Models;

public class Pet
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public byte AgeInMonths { get; set; }
    public string Species { get; set; } =  string.Empty;
}