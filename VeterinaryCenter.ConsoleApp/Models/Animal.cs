namespace VeterinaryCenter.ConsoleApp.Models;

internal abstract class Animal
{
    internal Guid Id { get; set; } = Guid.NewGuid();
    internal string Name { get; set; } = string.Empty;
    internal string Species { get; set; } = string.Empty;
    internal string Breed { get; set; } = string.Empty;
    internal string Color { get; set; } = string.Empty;
    internal string Gender { get; set; } = string.Empty;
    internal double Weight { get; set; }
    internal DateOnly BirthDate { get; set; }

    // 🔹 Propiedad de solo lectura que calcula la edad automáticamente
    internal int Age => DateTime.Now.Year - BirthDate.Year -
                     (DateTime.Now.DayOfYear < BirthDate.DayOfYear ? 1 : 0);

    // Método común para mostrar información general del animal
    internal virtual void ShowInfo()
    {
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Species: {Species}");
        Console.WriteLine($"Breed: {Breed}");
        Console.WriteLine($"Color: {Color}");
        Console.WriteLine($"Gender: {Gender}");
        Console.WriteLine($"Weight: {Weight} kg");
        Console.WriteLine($"Birth Date: {BirthDate:dd/MM/yyyy} (Age: {Age})");
    }
}

