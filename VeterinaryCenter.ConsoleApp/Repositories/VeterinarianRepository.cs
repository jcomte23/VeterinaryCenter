using VeterinaryCenter.ConsoleApp.Data;
using VeterinaryCenter.ConsoleApp.Interfaces;
using VeterinaryCenter.ConsoleApp.Models;

namespace VeterinaryCenter.ConsoleApp.Repositories;

internal class VeterinarianRepository : IVeterinarianRepository
{
    public void AddVeterinarian(Veterinarian veterinarian)
    {
		Database.Veterinarians.Add(veterinarian);
	}

    public void DeleteVeterinarian(Guid id)
    {
		var vet = GetVeterinarianById(id);
		if (vet is not null)
		{
			Database.Veterinarians.Remove(vet);
		}
	}

    public List<Veterinarian> GetAllVeterinarians()
    {
        return Database.Veterinarians;
    }

    public Veterinarian? GetVeterinarianById(Guid id)
    {
        return Database.Veterinarians.FirstOrDefault(v => v.Id == id);
	}

    public void UpdateVeterinarian(Veterinarian veterinarian)
    {
        var index = Database.Veterinarians.FindIndex(v => v.Id == veterinarian.Id);
        if (index != -1)
        {
			Database.Veterinarians[index] = veterinarian;
		}
	}
}

