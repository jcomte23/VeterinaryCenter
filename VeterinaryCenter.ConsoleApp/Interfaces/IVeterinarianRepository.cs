using VeterinaryCenter.ConsoleApp.Models;

namespace VeterinaryCenter.ConsoleApp.Interfaces;

internal interface IVeterinarianRepository
{
	void AddVeterinarian(Veterinarian veterinarian);
	List<Veterinarian> GetAllVeterinarians();
	Veterinarian? GetVeterinarianById(Guid id);
	void UpdateVeterinarian(Veterinarian veterinarian);
	void DeleteVeterinarian(Guid id);
}