using VeterinaryCenter.ConsoleApp.Models;

namespace VeterinaryCenter.ConsoleApp.Data;

internal abstract class Database
{
	internal static List<DocumentType> DocumentTypes { get; set; }
	internal static List<Customer> Customers { get; set; }
	internal static List<Veterinarian> Veterinarians { get; set; }

	static Database()
    {
        DocumentTypes =
        [
            new DocumentType(1, "Cédula de Ciudadanía", "CC"),
            new DocumentType(2, "Tarjeta de Identidad", "TI"),
            new DocumentType(3, "Pasaporte", "PA")
        ];

        Customers = [];

		Veterinarians = [];

	}
}