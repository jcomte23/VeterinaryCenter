using VeterinaryCenter.ConsoleApp.Entities;
using VeterinaryCenter.ConsoleApp.Models.Enums;
using VeterinaryCenter.ConsoleApp.Services;

namespace VeterinaryCenter.ConsoleApp.Menus;

internal class CustomerMenu
{
    private readonly CustomerService _service;

    public CustomerMenu(CustomerService service)
    {
        _service = service;
    }

    public void ShowMenu()
    {
        int option = -1;

        while (option != 0)
        {
            Console.Clear();
            Console.WriteLine("=== Gestión de Clientes ===");
            Console.WriteLine("1. Registrar cliente");
            Console.WriteLine("2. Listar clientes");
            Console.WriteLine("3. Buscar cliente por ID");
            Console.WriteLine("4. Actualizar cliente");
            Console.WriteLine("5. Eliminar cliente");
            Console.WriteLine("0. Volver al menú principal");
            Console.Write("Seleccione una opción: ");

            if (!int.TryParse(Console.ReadLine(), out option))
                option = -1;

            Console.Clear();

            switch (option)
            {
                case 1:
                    CreateCustomer();
                    break;
                case 2:
                    ListCustomers();
                    break;
                case 3:
                    GetCustomerById();
                    break;
                case 4:
                    UpdateCustomer();
                    break;
                case 5:
                    DeleteCustomer();
                    break;
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

    private void CreateCustomer()
    {
        Console.WriteLine("=== Registrar Cliente ===");

        Console.Write("Nombre: ");
        string name = Console.ReadLine()?.Trim() ?? "";

        Console.Write("Apellido: ");
        string lastName = Console.ReadLine()?.Trim() ?? "";

        // === Selección del tipo de documento ===
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

        Console.Write("Fecha de nacimiento (dd/MM/yyyy): ");
        DateOnly birthDay;
        while (!DateOnly.TryParse(Console.ReadLine(), out birthDay))
        {
            Console.Write("Formato inválido. Intente de nuevo (dd/MM/yyyy): ");
        }

        var customer = new Customer(
            name, lastName,
            documentType,
            documentNumber, phone, email, address,
            birthDay
        );

        try
        {
            _service.AddCustomer(customer);
            Console.WriteLine("\n✅ Cliente registrado con éxito.");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"❌ {ex.Message}");
        }
    }

    private void ListCustomers()
    {
        Console.WriteLine("=== Lista de Clientes ===");
        var customers = _service.GetAllCustomers();

        if (customers.Count == 0)
        {
            Console.WriteLine("No hay clientes registrados.");
            return;
        }

        foreach (var c in customers)
        {
            c.ShowInfo();
        }
    }

    private void GetCustomerById()
    {
        Console.Write("Ingrese el ID del cliente: ");
        var idText = Console.ReadLine();

        if (!Guid.TryParse(idText, out var id))
        {
            Console.WriteLine("❌ ID inválido.");
            return;
        }

        var customer = _service.GetCustomerById(id);
        if (customer is null)
        {
            Console.WriteLine("❌ No se encontró el cliente.");
            return;
        }

        customer.ShowInfo();
    }

    private void UpdateCustomer()
    {
        Console.Write("Ingrese el ID del cliente a actualizar: ");
        var idText = Console.ReadLine();

        if (!Guid.TryParse(idText, out var id))
        {
            Console.WriteLine("❌ ID inválido.");
            return;
        }

        var customer = _service.GetCustomerById(id);
        if (customer is null)
        {
            Console.WriteLine("❌ No se encontró el cliente.");
            return;
        }

        Console.WriteLine("\n=== Actualizar Cliente ===");
        Console.WriteLine("💡 Deje el campo vacío y presione Enter para mantener el valor actual.\n");

        Console.Write($"Nombre ({customer.Name}): ");
        string? input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input)) customer.Name = input.Trim();

        Console.Write($"Apellido ({customer.LastName}): ");
        input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input)) customer.LastName = input.Trim();

        Console.Write($"Teléfono ({customer.PhoneNumber}): ");
        input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input)) customer.PhoneNumber = input.Trim();

        Console.Write($"Email ({customer.Email}): ");
        input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input)) customer.Email = input.Trim();

        Console.Write($"Dirección ({customer.Address}): ");
        input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input)) customer.Address = input.Trim();

        Console.Write($"Fecha de nacimiento ({customer.BirthDay:dd/MM/yyyy}): ");
        input = Console.ReadLine();
        if (DateOnly.TryParse(input, out var birth))
            customer.BirthDay = birth;

        _service.UpdateCustomer(customer);
        Console.WriteLine("\n✅ Cliente actualizado con éxito.");
    }

    private void DeleteCustomer()
    {
        Console.Write("Ingrese el ID del cliente a eliminar: ");
        var idText = Console.ReadLine();

        if (!Guid.TryParse(idText, out var id))
        {
            Console.WriteLine("❌ ID inválido.");
            return;
        }

        _service.DeleteCustomer(id);
        Console.WriteLine("✅ Cliente eliminado con éxito.");
    }
}

