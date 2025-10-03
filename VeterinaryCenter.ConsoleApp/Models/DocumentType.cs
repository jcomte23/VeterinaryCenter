namespace VeterinaryCenter.ConsoleApp.Models;

internal class DocumentType(int id,string name, string abbreviation)
{
    internal int Id { get; set; } = id;
	internal string Name { get; set; } = name;
	internal string Abbreviation { get; set; } = abbreviation;
}