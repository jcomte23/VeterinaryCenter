using VeterinaryCenter.ConsoleApp.Entities;

namespace VeterinaryCenter.ConsoleApp.Models;

internal class Pet(int id, string name, byte ageInMonths, string species, int patientId)
{
	internal int Id { get; set; } = id;
	internal string Name { get; set; } = name.ToLower().Trim();
	internal byte AgeInMonths { get; set; } = ageInMonths;
	internal string Species { get; set; } = species.ToLower().Trim();
	internal int PatientId { get; set; } = patientId;
    internal Customer? Customer { get; set; }
}