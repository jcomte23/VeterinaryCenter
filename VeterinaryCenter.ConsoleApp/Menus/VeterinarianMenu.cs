using VeterinaryCenter.ConsoleApp.Data;
using VeterinaryCenter.ConsoleApp.Interfaces;
using VeterinaryCenter.ConsoleApp.Models;

namespace VeterinaryCenter.ConsoleApp.Menus;

internal class VeterinarianMenu(IVeterinarianRepository repository)
{
	private readonly IVeterinarianRepository _repository = repository;

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
				case 1:
					CreateVeterinarian();
					break;
				case 2:
					ListVeterinarians();
					break;
				case 3:
					GetVeterinarianById();
					break;
				case 4:
					UpdateVeterinarian();
					break;
				case 5:
					DeleteVeterinarian();
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

	private void CreateVeterinarian()
	{
		Console.WriteLine("=== Registrar Veterinario ===");

		Console.Write("Nombre: ");
		string name = Console.ReadLine() ?? "";

		Console.Write("Apellido: ");
		string lastName = Console.ReadLine() ?? "";

		Console.Write("Número de documento: ");
		string documentNumber = Console.ReadLine() ?? "";

		Console.Write("Teléfono: ");
		string phone = Console.ReadLine() ?? "";

		Console.Write("Email: ");
		string email = Console.ReadLine() ?? "";

		Console.Write("Dirección: ");
		string address = Console.ReadLine() ?? "";

		Console.Write("Especialidad: ");
		string specialty = Console.ReadLine() ?? "";

		Console.Write("Años de experiencia: ");
		int years = int.TryParse(Console.ReadLine(), out var y) ? y : 0;

		var vet = new Veterinarian(
			name, lastName,
			Database.DocumentTypes[0], // Aquí luego podrías pedir tipo de documento
			documentNumber, phone, email, address,
			specialty, years
		);

		_repository.AddVeterinarian(vet);
		Console.WriteLine("✅ Veterinario registrado con éxito.");
	}

	private void ListVeterinarians()
	{
		Console.WriteLine("=== Lista de Veterinarios ===");
		var vets = _repository.GetAllVeterinarians();

		if (vets.Count == 0)
		{
			Console.WriteLine("No hay veterinarios registrados.");
			return;
		}

		foreach (var v in vets)
		{
			Console.WriteLine($"ID: {v.Id}");
			Console.WriteLine($"Nombre: {v.Name} {v.LastName}");
			Console.WriteLine($"Documento: {v.DocumentType} - {v.DocumentNumber}");
			Console.WriteLine($"Teléfono: {v.PhoneNumber}");
			Console.WriteLine($"Email: {v.Email}");
			Console.WriteLine($"Especialidad: {v.Specialty} ({v.YearsExperience} años)");
			Console.WriteLine("-------------------------");
		}
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

		var vet = _repository.GetVeterinarianById(id);
		if (vet is null)
		{
			Console.WriteLine("No se encontró el veterinario.");
			return;
		}

		Console.WriteLine($"Nombre: {vet.Name} {vet.LastName}");
		Console.WriteLine($"Documento: {vet.DocumentType} - {vet.DocumentNumber}");
		Console.WriteLine($"Teléfono: {vet.PhoneNumber}");
		Console.WriteLine($"Email: {vet.Email}");
		Console.WriteLine($"Especialidad: {vet.Specialty} ({vet.YearsExperience} años)");
	}

	private void UpdateVeterinarian()
	{
		Console.Write("Ingrese el ID del veterinario a actualizar: ");
		var idText = Console.ReadLine();

		if (!Guid.TryParse(idText, out var id))
		{
			Console.WriteLine("ID inválido.");
			return;
		}

		var vet = _repository.GetVeterinarianById(id);
		if (vet is null)
		{
			Console.WriteLine("No se encontró el veterinario.");
			return;
		}

		Console.WriteLine("=== Actualizar Veterinario ===");
		Console.Write($"Nombre ({vet.Name}): ");
		vet.Name = Console.ReadLine() ?? vet.Name;

		Console.Write($"Apellido ({vet.LastName}): ");
		vet.LastName = Console.ReadLine() ?? vet.LastName;

		Console.Write($"Teléfono ({vet.PhoneNumber}): ");
		vet.PhoneNumber = Console.ReadLine() ?? vet.PhoneNumber;

		Console.Write($"Email ({vet.Email}): ");
		vet.Email = Console.ReadLine() ?? vet.Email;

		Console.Write($"Dirección ({vet.Address}): ");
		vet.Address = Console.ReadLine() ?? vet.Address;

		Console.Write($"Especialidad ({vet.Specialty}): ");
		vet.Specialty = Console.ReadLine() ?? vet.Specialty;

		Console.Write($"Años de experiencia ({vet.YearsExperience}): ");
		if (int.TryParse(Console.ReadLine(), out var years))
			vet.YearsExperience = years;

		_repository.UpdateVeterinarian(vet);
		Console.WriteLine("✅ Veterinario actualizado con éxito.");
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

		_repository.DeleteVeterinarian(id);
		Console.WriteLine("✅ Veterinario eliminado con éxito.");
	}
}

