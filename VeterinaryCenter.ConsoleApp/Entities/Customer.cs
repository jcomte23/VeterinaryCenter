using VeterinaryCenter.ConsoleApp.Models;
using VeterinaryCenter.ConsoleApp.Models.Enums;

namespace VeterinaryCenter.ConsoleApp.Entities;

internal class Customer : Person
{
    internal DateOnly BirthDay { get; set; }
    internal List<Animal> Pets { get; } = [];

    internal Customer(
        string name,
        string lastName,
        DocumentType documentType,
        string documentNumber,
        string phoneNumber,
        string email,
        string address,
        DateOnly birthDay
    ) : base(name, lastName, documentType, documentNumber, phoneNumber, email, address)
    {
        BirthDay = birthDay;
    }

    // 🔹 Método para agregar una mascota
    internal void AddPet(Animal pet)
    {
        Pets.Add(pet);
    }

    // 🔹 Método para listar las mascotas del cliente
    internal void ShowPets()
    {
        if (Pets.Count == 0)
        {
            Console.WriteLine("│ Mascotas registradas: 0".PadRight(ContentWidth + 1) + "│");
            Console.WriteLine("└" + new string('─', ContentWidth) + "┘");
            return;
        }

        Console.WriteLine($"│ Mascotas registradas: {Pets.Count}".PadRight(ContentWidth + 1) + "│");
        Console.WriteLine("├" + new string('─', ContentWidth) + "┤");

        foreach (var pet in Pets)
        {
            Console.WriteLine($"│ 🐾 {pet.Name} ({pet.Species})".PadRight(ContentWidth + 1) + "│");
        }

        Console.WriteLine("└" + new string('─', ContentWidth) + "┘");
    }

    // 🔹 Mostrar información completa del cliente
    internal void ShowInfo()
    {
        ShowBasicInfo();
        Console.WriteLine($"│ Fecha de nacimiento: {BirthDay:dd/MM/yyyy}".PadRight(ContentWidth + 1) + "│");
        Console.WriteLine($"│ Mascotas registradas: {Pets.Count}".PadRight(ContentWidth + 1) + "│");
        Console.WriteLine("└" + new string('─', ContentWidth) + "┘");

        // Mostrar las mascotas si hay
        if (Pets.Count > 0)
        {
            Console.WriteLine();
            Console.WriteLine("🐶 Mascotas del cliente:");
            foreach (var pet in Pets)
            {
                pet.ShowInfo();
                Console.WriteLine();
            }
        }
    }
}
