namespace VeterinaryCenter.ConsoleApp.Models;

internal abstract class Person(string name, string lastName, DocumentType documentType, string documentNumber, string phoneNumber, string email, string address)
{
    protected Guid Id { get; set; } = Guid.NewGuid();
    protected string Name { get; set; } = name;
    protected string LastName { get; set; } = lastName;
    protected DocumentType DocumentType { get; set; } = documentType;
    protected string DocumentNumber { get; set; } = documentNumber;
    protected string PhoneNumber { get; set; } = phoneNumber;
    protected string Email { get; set; } = email;
    protected string Address { get; set; } = address;

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

