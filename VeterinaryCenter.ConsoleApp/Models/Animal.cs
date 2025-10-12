namespace VeterinaryCenter.ConsoleApp.Models;

internal abstract class Animal
{
    public Guid Id { get; set; } = Guid.NewGuid(); 
    public string Name { get; set; } = string.Empty; 
    public string Species { get; set; } = string.Empty; 
    public string Breed { get; set; } = string.Empty; 
    public string Color { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty; 
    public double Weight { get; set; } 
    public DateOnly BirthDate { get; set; } 

    // 🔹 Propiedad de solo lectura que calcula la edad automáticamente
    public int Age => DateTime.Now.Year - BirthDate.Year -
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

