using VeterinaryCenter.ConsoleApp.Models.Enums;

namespace VeterinaryCenter.ConsoleApp.Models;

internal abstract class Person(string name, string lastName, DocumentType documentType, string documentNumber, string phoneNumber, string email, string address)
{
    internal Guid Id { get; set; } = Guid.NewGuid();
    internal string Name { get; set; } = name;
    internal string LastName { get; set; } = lastName;
	internal DocumentType DocumentType { get; set; } = documentType;
	internal string DocumentNumber { get; set; } = documentNumber;
	internal string PhoneNumber { get; set; } = phoneNumber;
	internal string Email { get; set; } = email;
	internal string Address { get; set; } = address;

    // Constantes compartidas para formato
    protected const int TotalWidth = 55;
    protected const int ContentWidth = TotalWidth - 2;

    protected void ShowBasicInfo()
    {
        Console.WriteLine();
        Console.WriteLine("┌" + new string('─', ContentWidth) + "┐");
        Console.WriteLine("│" + "INFORMACIÓN BÁSICA".PadLeft((ContentWidth + "INFORMACIÓN BÁSICA".Length) / 2).PadRight(ContentWidth) + "│");
        Console.WriteLine("├" + new string('─', ContentWidth) + "┤");

        Console.WriteLine($"│ ID: {Id}".PadRight(ContentWidth + 1) + "│");
        Console.WriteLine($"│ Nombre: {Name} {LastName}".PadRight(ContentWidth + 1) + "│");
        Console.WriteLine($"│ Documento: {DocumentType} - {DocumentNumber}".PadRight(ContentWidth + 1) + "│");
        Console.WriteLine($"│ Teléfono: {PhoneNumber}".PadRight(ContentWidth + 1) + "│");
        Console.WriteLine($"│ Email: {Email}".PadRight(ContentWidth + 1) + "│");
        Console.WriteLine($"│ Dirección: {Address}".PadRight(ContentWidth + 1) + "│");
    }
}

