using VeterinaryCenter.ConsoleApp.Models.Enums;

namespace VeterinaryCenter.ConsoleApp.Models;

internal class Customer : Person
{
    internal DateOnly BirthDay { get; set; }
	internal List<Pet> Pets { get; set; }
    internal Customer
	(
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
		Pets = [];
	}

	internal void ShowInfo() 
	{
		ShowBasicInfo();
		Console.WriteLine($"BirthDay: {BirthDay:dd/MM/yyyy}");
		Console.WriteLine($"Pets Count: {Pets.Count}");
	}

}
