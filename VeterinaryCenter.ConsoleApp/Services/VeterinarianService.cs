using VeterinaryCenter.ConsoleApp.Entities;
using VeterinaryCenter.ConsoleApp.Interfaces;

namespace VeterinaryCenter.ConsoleApp.Services;

internal class VeterinarianService
{
	private readonly IVeterinarianRepository _repository;

	public VeterinarianService(IVeterinarianRepository repository)
	{
		_repository = repository;
	}

	public void AddVeterinarian(Veterinarian veterinarian)
	{
		if (_repository.GetAllVeterinarians()
					   .Any(v => v.DocumentNumber == veterinarian.DocumentNumber))
		{
			throw new InvalidOperationException("Ya existe un veterinario con ese documento.");
		}

		_repository.AddVeterinarian(veterinarian);
	}

	public List<Veterinarian> GetAllVeterinarians()
	{
		return _repository.GetAllVeterinarians();
	}

	public Veterinarian? GetVeterinarianById(Guid id)
	{
		return _repository.GetVeterinarianById(id);
	}

	public void UpdateVeterinarian(Veterinarian veterinarian)
	{
		_repository.UpdateVeterinarian(veterinarian);
	}

	public void DeleteVeterinarian(Guid id)
	{
		_repository.DeleteVeterinarian(id);
	}
}