namespace VeterinaryCenter.ConsoleApp.Models;

internal class Veterinarian
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public string LastName { get; set; }
	public DocumentType DocumentType { get; set; }
	public string DocumentNumber { get; set; }
	public string PhoneNumber { get; set; }
	public string Email { get; set; }
	public string Specialty { get; set; }  // Ej: Cirugía, Vacunas, Medicina General
	public int YearsExperience { get; set; }

	public Veterinarian(string name, string lastName, DocumentType documentType, string documentNumber, string phoneNumber, string email, string specialty, int yearsExperience)
	{
		Id = Guid.NewGuid();
		Name = name;
		LastName = lastName;
		DocumentType = documentType;
		DocumentNumber = documentNumber;
		PhoneNumber = phoneNumber;
		Email = email;
		Specialty = specialty;
		YearsExperience = yearsExperience;
	}
}

