using VeterinaryCenter.ConsoleApp.Models;
using VeterinaryCenter.ConsoleApp.Models.Enums;

namespace VeterinaryCenter.ConsoleApp.Entities;

internal class Veterinarian : Person
{
	internal string Specialty { get; set; }  // Ej: Cirugía, Vacunas, Medicina General
	internal int YearsExperience { get; set; }

	internal Veterinarian
	(
		string name, 
		string lastName, 
		DocumentType documentType, 
		string documentNumber, 
		string phoneNumber, 
		string email, 
		string address,
		string specialty,
		int yearsExperience

	) : base(name, lastName, documentType, documentNumber, phoneNumber, email, address)
	{
		Specialty = specialty;
		YearsExperience = yearsExperience;
	}


	internal void ShowInfo()
	{
		ShowBasicInfo();
		Console.WriteLine($"Specialty: {Specialty}");
		Console.WriteLine($"Years of Experience: {YearsExperience}");
	}
}

