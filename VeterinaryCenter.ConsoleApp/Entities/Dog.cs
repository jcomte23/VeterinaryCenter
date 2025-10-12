using VeterinaryCenter.ConsoleApp.Models;

namespace VeterinaryCenter.ConsoleApp.Entities;

internal class Dog : Animal
{
    public bool IsNeutered { get; set; } // Indica si el perro está castrado
    public string Size { get; set; } = string.Empty; // Pequeño, Mediano, Grande
    public string MicrochipNumber { get; set; } = string.Empty;

    internal Dog(
        string name,
        string species,
        string breed,
        string color,
        string gender,
        double weight,
        DateOnly birthDate,
        bool isNeutered,
        string size,
        string microchipNumber,
        Customer? owner = null
    ) : base(name, species, breed, color,gender, weight, birthDate,owner)
    {
        IsNeutered = isNeutered;
        Size = size;
        MicrochipNumber = microchipNumber;
    }

    internal override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"│ Esterilizado: {(IsNeutered ? "Sí" : "No")}".PadRight(ContentWidth + 1) + "│");
        Console.WriteLine($"│ Tamaño: {Size}".PadRight(ContentWidth + 1) + "│");
        Console.WriteLine($"│ Microchip: {MicrochipNumber}".PadRight(ContentWidth + 1) + "│");
        Console.WriteLine("└" + new string('─', ContentWidth) + "┘");
    }
}

