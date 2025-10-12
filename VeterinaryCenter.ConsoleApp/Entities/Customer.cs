using VeterinaryCenter.ConsoleApp.Models;
using VeterinaryCenter.ConsoleApp.Models.Enums;

namespace VeterinaryCenter.ConsoleApp.Entities;

internal class Customer : Person
{
    internal DateOnly BirthDay { get; set; }
	//internal List<Pet> Pets { get; set; }
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
		//Pets = [];
	}

    internal void ShowInfo()
    {
        ShowBasicInfo();

        Console.WriteLine($"│ Fecha de nacimiento: {BirthDay:dd/MM/yyyy}".PadRight(ContentWidth + 1) + "│");
        //Console.WriteLine($"│ Mascotas registradas: {Pets.Count}".PadRight(ContentWidth + 1) + "│");
        Console.WriteLine("└" + new string('─', ContentWidth) + "┘");
    }


}
