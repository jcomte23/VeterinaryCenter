namespace VeterinaryCenter.ConsoleApp.Models;

public class DocumentType(int id,string name, string abbreviation)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
    public string Abbreviation { get; set; } = abbreviation;
}