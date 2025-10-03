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

    protected void ShowBasicInfo()
	{
		Console.WriteLine($"ID: {Id}");
		Console.WriteLine($"Name: {Name} {LastName}");
		Console.WriteLine($"Document: {DocumentType.Name} - {DocumentNumber}");
		Console.WriteLine($"Phone: {PhoneNumber}");
		Console.WriteLine($"Email: {Email}");
		Console.WriteLine($"Address: {Address}");
	}
}

