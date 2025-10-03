using VeterinaryCenter.ConsoleApp.Interfaces;
using VeterinaryCenter.ConsoleApp.Models;

namespace VeterinaryCenter.ConsoleApp.Repositories;

internal class VeterinarianRepository : IVeterinarianRepository
{
    private readonly List<Veterinarian> _veterinarians = [];

    public void AddVeterinarian(Veterinarian veterinarian)
    {
		if (_veterinarians.Any(v => v.DocumentNumber == veterinarian.DocumentNumber))
			throw new InvalidOperationException("Ya existe un veterinario con ese documento.");

		_veterinarians.Add(veterinarian);
	}

    public void DeleteVeterinarian(Guid id)
    {
		var vet = GetVeterinarianById(id);
		if (vet is not null)
		{
			_veterinarians.Remove(vet);
		}
	}

    public List<Veterinarian> GetAllVeterinarians()
    {
        return _veterinarians;
    }

    public Veterinarian? GetVeterinarianById(Guid id)
    {
        return _veterinarians.FirstOrDefault(v => v.Id == id);
	}

    public void UpdateVeterinarian(Veterinarian veterinarian)
    {
        var index = _veterinarians.FindIndex(v => v.Id == veterinarian.Id);
        if (index != -1)
        {
			_veterinarians[index] = veterinarian;
		}
	}
}

