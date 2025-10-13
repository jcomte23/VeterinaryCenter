using VeterinaryCenter.ConsoleApp.Data;
using VeterinaryCenter.ConsoleApp.Entities;
using VeterinaryCenter.ConsoleApp.Services;

namespace VeterinaryCenter.ConsoleApp.Menus;

internal class AnimalMenu
{
    private readonly AnimalService _service;
    private readonly CustomerService _customerService;

    public AnimalMenu(AnimalService service, CustomerService customerService)
    {
        _service = service;
        _customerService = customerService;
    }

    internal void Show()
    {
        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("==========================================");
            Console.WriteLine("        🐾 MENÚ DE GESTIÓN DE ANIMALES     ");
            Console.WriteLine("==========================================");
            Console.WriteLine("1. Registrar nuevo animal");
            Console.WriteLine("2. Ver todos los animales");
            Console.WriteLine("3. Buscar animal por ID");
            Console.WriteLine("4. Ver animales por especie");
            Console.WriteLine("5. Ver animales por dueño");
            Console.WriteLine("6. Actualizar datos de un animal");
            Console.WriteLine("7. Eliminar animal");
            Console.WriteLine("0. Volver al menú principal");
            Console.Write("\nSeleccione una opción: ");

            string? option = Console.ReadLine();
            Console.Clear();

            switch (option)
            {
                case "1":
                    CreateAnimal();
                    break;
                case "2":
                    _service.ShowAllAnimals();
                    break;
                case "3":
                    SearchById();
                    break;
                case "4":
                    SearchBySpecies();
                    break;
                case "5":
                    SearchByOwner();
                    break;
                case "6":
                    UpdateAnimal();
                    break;
                case "7":
                    DeleteAnimal();
                    break;
                case "0":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("⚠️ Opción no válida. Intente de nuevo.");
                    break;
            }

            if (!exit)
            {
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }
    }

    private void CreateAnimal()
    {
        Console.WriteLine("=== Registrar Nuevo Animal ===");

        // 🐶 Datos básicos
        Console.Write("Nombre: ");
        string name = Console.ReadLine() ?? string.Empty;

        Console.Write("Especie: ");
        string species = Console.ReadLine() ?? string.Empty;

        Console.Write("Raza: ");
        string breed = Console.ReadLine() ?? string.Empty;

        Console.Write("Color: ");
        string color = Console.ReadLine() ?? string.Empty;

        Console.Write("Sexo (M/F): ");
        string gender = Console.ReadLine() ?? string.Empty;

        Console.Write("Peso (kg): ");
        double weight = double.TryParse(Console.ReadLine(), out double w) ? w : 0;

        Console.Write("Fecha de nacimiento (yyyy-mm-dd): ");
        DateOnly birthDate = DateOnly.TryParse(Console.ReadLine(), out var date)
            ? date
            : new DateOnly(2020, 1, 1);

        Console.Write("¿Está esterilizado? (s/n): ");
        bool isNeutered = Console.ReadLine()?.Trim().ToLower() == "s";

        // 👇 Nuevo: pedir tamaño
        Console.Write("Tamaño (Pequeño/Mediano/Grande): ");
        string size = Console.ReadLine() ?? "Mediano";

        Console.WriteLine("\n--- Seleccionar Dueño ---");
        var customers = _customerService.GetAllCustomers();
        Customer? selectedOwner = null;

        if (customers.Count == 0)
        {
            Console.WriteLine("No hay clientes registrados. El animal se guardará sin dueño.");
        }
        else
        {
            for (int i = 0; i < customers.Count; i++)
            {
                var c = customers[i];
                Console.WriteLine($"{i + 1}. {c.Name} {c.LastName} ({c.Email})");
            }

            Console.Write("Seleccione el número del dueño (0 = ninguno): ");
            int ownerOption = int.TryParse(Console.ReadLine(), out int opt) ? opt : 0;

            if (ownerOption > 0 && ownerOption <= customers.Count)
                selectedOwner = customers[ownerOption - 1];
            else
                Console.WriteLine("⚠️ Opción inválida. El animal se guardará sin dueño.");
        }

        // 🐕 Crear el nuevo perro
        var animal = new Dog(
            name,
            species,
            breed,
            color,
            gender,
            weight,
            birthDate,
            isNeutered,
            size,
            microchipNumber: Guid.NewGuid().ToString()[..8],
            owner: selectedOwner
        );

        _service.AddAnimal(animal);
        Console.WriteLine("\n✅ Animal registrado exitosamente.");
    }

    private void SearchById()
    {
        Console.Write("Ingrese el ID del animal: ");
        string? input = Console.ReadLine();

        if (Guid.TryParse(input, out Guid id))
        {
            var animal = _service.GetAnimalById(id);
            if (animal != null)
                animal.ShowInfo();
            else
                Console.WriteLine("⚠️ No se encontró ningún animal con ese ID.");
        }
        else
        {
            Console.WriteLine("⚠️ ID inválido.");
        }
    }

    private void SearchBySpecies()
    {
        Console.Write("Ingrese la especie: ");
        string species = Console.ReadLine() ?? string.Empty;

        var animals = _service.GetAnimalsBySpecies(species);
        if (animals.Count == 0)
            Console.WriteLine("⚠️ No hay animales de esa especie.");
        else
            animals.ForEach(a => a.ShowInfo());
    }

    private void SearchByOwner()
    {
        Console.Write("Ingrese el nombre del dueño: ");
        string ownerName = Console.ReadLine() ?? string.Empty;

        var owner = Database.Customers.FirstOrDefault(c =>
            $"{c.Name} {c.LastName}".Contains(ownerName, StringComparison.OrdinalIgnoreCase));

        if (owner == null)
        {
            Console.WriteLine("⚠️ No se encontró ningún cliente con ese nombre.");
            return;
        }

        var animals = _service.GetAnimalsByOwner(owner);
        if (animals.Count == 0)
            Console.WriteLine("⚠️ Este cliente no tiene animales registrados.");
        else
            animals.ForEach(a => a.ShowInfo());
    }

    private void UpdateAnimal()
    {
        Console.Write("Ingrese el ID del animal a actualizar: ");
        if (!Guid.TryParse(Console.ReadLine(), out Guid id))
        {
            Console.WriteLine("⚠️ ID inválido.");
            return;
        }

        var animal = _service.GetAnimalById(id);
        if (animal == null)
        {
            Console.WriteLine("⚠️ No se encontró el animal.");
            return;
        }

        Console.WriteLine("Deje vacío el campo si no desea cambiarlo.");

        Console.Write($"Nuevo nombre ({animal.Name}): ");
        string name = Console.ReadLine() ?? string.Empty;
        if (!string.IsNullOrWhiteSpace(name))
            animal.Name = name;

        Console.Write($"Nuevo color ({animal.Color}): ");
        string color = Console.ReadLine() ?? string.Empty;
        if (!string.IsNullOrWhiteSpace(color))
            animal.Color = color;

        Console.Write($"Nuevo peso ({animal.Weight}): ");
        if (double.TryParse(Console.ReadLine(), out double newWeight))
            animal.Weight = newWeight;

        _service.UpdateAnimal(animal);
        Console.WriteLine("\n✅ Datos actualizados correctamente.");
    }

    private void DeleteAnimal()
    {
        Console.Write("Ingrese el ID del animal a eliminar: ");
        if (Guid.TryParse(Console.ReadLine(), out Guid id))
        {
            _service.DeleteAnimal(id);
            Console.WriteLine("✅ Animal eliminado correctamente.");
        }
        else
        {
            Console.WriteLine("⚠️ ID inválido.");
        }
    }
}

