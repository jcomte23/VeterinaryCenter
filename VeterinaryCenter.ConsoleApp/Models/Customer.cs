namespace VeterinaryCenter.ConsoleApp.Models;

internal class Customer : Person
{
	internal Customer
	(
		string name,
		string lastName,
		DocumentType documentType,
		string documentNumber,
		string phoneNumber,
		string email,
		string address
	) : base(name, lastName, documentType, documentNumber, phoneNumber, email, address) { }
}
