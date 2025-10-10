using VeterinaryCenter.ConsoleApp.Entities;
using VeterinaryCenter.ConsoleApp.Models.Enums;
using VeterinaryCenter.ConsoleApp.Services;

namespace VeterinaryCenter.ConsoleApp.Menus;

internal class VeterinarianMenu(VeterinarianService service)
{
    private readonly VeterinarianService _service = service;

    public void ShowMenu()
    {
        int option = -1;

        while (option != 0)
        {
            Console.Clear();
            Console.WriteLine("=== Gestión de Veterinarios ===");
            Console.WriteLine("1. Registrar veterinario");
            Console.WriteLine("2. Listar veterinarios");
            Console.WriteLine("3. Buscar veterinario por ID");
            Console.WriteLine("4. Actualizar veterinario");
            Console.WriteLine("5. Eliminar veterinario");
            Console.WriteLine("0. Volver al menú principal");
            Console.Write("Seleccione una opción: ");

            if (!int.TryParse(Console.ReadLine(), out option))
                option = -1;

            Console.Clear();

            switch (option)
            {
                case 1: CreateVeterinarian(); break;
                case 2: ListVeterinarians(); break;
                case 3: GetVeterinarianById(); break;
                case 4: UpdateVeterinarian(); break;
                case 5: DeleteVeterinarian(); break;
                case 0:
                    Console.WriteLine("Volviendo al menú principal...");
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }

            if (option != 0)
            {
                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();
            }
        }
    }

    // ========================================================
    // MÉTODOS CRUD usando el servicio
    // ========================================================
    private void CreateVeterinarian()
    {
        Console.WriteLine("=== Registrar Veterinario ===");

        Console.Write("Nombre: ");
        string name = Console.ReadLine()?.Trim() ?? "";

        Console.Write("Apellido: ");
        string lastName = Console.ReadLine()?.Trim() ?? "";

        // === Tipo de documento ===
        Console.WriteLine("Seleccione el tipo de documento:");
        var docTypes = Enum.GetValues(typeof(DocumentType)).Cast<DocumentType>().ToList();

        for (int i = 0; i < docTypes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {docTypes[i]}");
        }

        int selectedType = 0;
        while (selectedType < 1 || selectedType > docTypes.Count)
        {
            Console.Write("Opción: ");
            int.TryParse(Console.ReadLine(), out selectedType);
            if (selectedType < 1 || selectedType > docTypes.Count)
                Console.WriteLine("❌ Opción inválida. Intente de nuevo.");
        }

        DocumentType documentType = docTypes[selectedType - 1];

        Console.Write("Número de documento: ");
        string documentNumber = Console.ReadLine()?.Trim() ?? "";

        Console.Write("Teléfono: ");
        string phone = Console.ReadLine()?.Trim() ?? "";

        Console.Write("Email: ");
        string email = Console.ReadLine()?.Trim() ?? "";

        Console.Write("Dirección: ");
        string address = Console.ReadLine()?.Trim() ?? "";

        Console.Write("Especialidad: ");
        string specialty = Console.ReadLine()?.Trim() ?? "";

        Console.Write("Años de experiencia: ");
        int years = int.TryParse(Console.ReadLine(), out var y) ? y : 0;

        var vet = new Veterinarian(
            name, lastName,
            documentType,
            documentNumber, phone, email, address,
            specialty, years
        );

        try
        {
            _service.AddVeterinarian(vet);
            Console.WriteLine("\n✅ Veterinario registrado con éxito.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Error: {ex.Message}");
        }
    }

    private void ListVeterinarians()
    {
        Console.WriteLine("=== Lista de Veterinarios ===");
        var vets = _service.GetAllVeterinarians();

        if (vets.Count == 0)
        {
            Console.WriteLine("No hay veterinarios registrados.");
            return;
        }

        foreach (var v in vets)
            v.ShowInfo();
    }

    private void GetVeterinarianById()
    {
        Console.Write("Ingrese el ID del veterinario: ");
        var idText = Console.ReadLine();

        if (!Guid.TryParse(idText, out var id))
        {
            Console.WriteLine("ID inválido.");
            return;
        }

        var vet = _service.GetVeterinarianById(id);
        if (vet is null)
        {
            Console.WriteLine("No se encontró el veterinario.");
            return;
        }

        vet.ShowInfo();
    }

    private void UpdateVeterinarian()
    {
        Console.Write("Ingrese el ID del veterinario a actualizar: ");
        var idText = Console.ReadLine();

        if (!Guid.TryParse(idText, out var id))
        {
            Console.WriteLine("❌ ID inválido.");
            return;
        }

        var vet = _service.GetVeterinarianById(id);
        if (vet is null)
        {
            Console.WriteLine("❌ No se encontró el veterinario.");
            return;
        }

        Console.WriteLine("\n=== Actualizar Veterinario ===");
        Console.WriteLine("💡 Deje el campo vacío y presione Enter para mantener el valor actual.\n");

        Console.Write($"Nombre ({vet.Name}): ");
        string? input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input)) vet.Name = input.Trim();

        Console.Write($"Apellido ({vet.LastName}): ");
        input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input)) vet.LastName = input.Trim();

        Console.Write($"Teléfono ({vet.PhoneNumber}): ");
        input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input)) vet.PhoneNumber = input.Trim();

        Console.Write($"Email ({vet.Email}): ");
        input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input)) vet.Email = input.Trim();

        Console.Write($"Dirección ({vet.Address}): ");
        input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input)) vet.Address = input.Trim();

        Console.Write($"Especialidad ({vet.Specialty}): ");
        input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input)) vet.Specialty = input.Trim();

        Console.Write($"Años de experiencia ({vet.YearsExperience}): ");
        input = Console.ReadLine();
        if (int.TryParse(input, out var years))
            vet.YearsExperience = years;

        _service.UpdateVeterinarian(vet);
        Console.WriteLine("\n✅ Veterinario actualizado con éxito.");
    }

    private void DeleteVeterinarian()
    {
        Console.Write("Ingrese el ID del veterinario a eliminar: ");
        var idText = Console.ReadLine();

        if (!Guid.TryParse(idText, out var id))
        {
            Console.WriteLine("ID inválido.");
            return;
        }

        _service.DeleteVeterinarian(id);
        Console.WriteLine("✅ Veterinario eliminado con éxito.");
    }
}

