using VeterinaryCenter.ConsoleApp.Entities;

namespace VeterinaryCenter.ConsoleApp.Models;

internal abstract class Animal
{
    internal Guid Id { get; set; } = Guid.NewGuid();
    internal string Name { get; set; }
    internal Customer? Owner { get; set; }
    internal string Species { get; set; }
    internal string Breed { get; set; }
    internal string Color { get; set; }
    internal string Gender { get; set; }
    internal double Weight { get; set; }
    internal DateOnly BirthDate { get; set; }

    // 🔹 Propiedad calculada para obtener la edad actual
    internal int Age => DateTime.Now.Year - BirthDate.Year -
                       (DateTime.Now.DayOfYear < BirthDate.DayOfYear ? 1 : 0);

    protected const int TotalWidth = 55;
    protected const int ContentWidth = TotalWidth - 2;

    internal Animal(
        string name,
        string species,
        string breed,
        string color,
        string gender,
        double weight,
        DateOnly birthDate
    )
    {
        Name = name;
        Species = species;
        Breed = breed;
        Color = color;
        Gender = gender;
        Weight = weight;
        BirthDate = birthDate;
    }

    internal virtual void ShowInfo()
    {
        Console.WriteLine();
        Console.WriteLine("┌" + new string('─', ContentWidth) + "┐");
        Console.WriteLine("│" + "INFORMACIÓN DEL ANIMAL".PadLeft((ContentWidth + "INFORMACIÓN DEL ANIMAL".Length) / 2).PadRight(ContentWidth) + "│");
        Console.WriteLine("├" + new string('─', ContentWidth) + "┤");
        Console.WriteLine($"│ ID: {Id}".PadRight(ContentWidth + 1) + "│");
        Console.WriteLine($"│ Nombre: {Name}".PadRight(ContentWidth + 1) + "│");
        Console.WriteLine($"│ Especie: {Species}".PadRight(ContentWidth + 1) + "│");
        Console.WriteLine($"│ Raza: {Breed}".PadRight(ContentWidth + 1) + "│");
        Console.WriteLine($"│ Color: {Color}".PadRight(ContentWidth + 1) + "│");
        Console.WriteLine($"│ Sexo: {Gender}".PadRight(ContentWidth + 1) + "│");
        Console.WriteLine($"│ Peso: {Weight} kg".PadRight(ContentWidth + 1) + "│");
        Console.WriteLine($"│ Fecha de Nacimiento: {BirthDate:dd/MM/yyyy} (Edad: {Age})".PadRight(ContentWidth + 1) + "│");

        // 👇 Mostrar el dueño solo si existe
        if (Owner is not null)
            Console.WriteLine($"│ Dueño: {Owner.Name} {Owner.LastName}".PadRight(ContentWidth + 1) + "│");
        else
            Console.WriteLine($"│ Dueño: (No asignado)".PadRight(ContentWidth + 1) + "│");

        Console.WriteLine("└" + new string('─', ContentWidth) + "┘");
    }
}

