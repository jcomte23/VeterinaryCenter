using VeterinaryCenter.ConsoleApp.Entities;
using VeterinaryCenter.ConsoleApp.Interfaces;
using VeterinaryCenter.ConsoleApp.Models;
using VeterinaryCenter.ConsoleApp.Repositories;

namespace VeterinaryCenter.ConsoleApp.Services;

internal class AnimalService
{
    private readonly IAnimalRepository _repository;

    internal AnimalService(IAnimalRepository repository)
    {
        _repository = repository;
    }

    internal void AddAnimal(Animal animal)
    {
        if (animal is null)
            throw new ArgumentNullException(nameof(animal));

        // Ejemplo de validación básica
        if (string.IsNullOrWhiteSpace(animal.Name))
            throw new ArgumentException("El nombre del animal es obligatorio.");

        if (string.IsNullOrWhiteSpace(animal.Species))
            throw new ArgumentException("Debe especificarse la especie.");

        _repository.AddAnimal(animal);
    }

    internal List<Animal> GetAllAnimals()
    {
        return _repository.GetAllAnimals();
    }

    internal Animal? GetAnimalById(Guid id)
    {
        return _repository.GetAnimalById(id);
    }

    internal void UpdateAnimal(Animal animal)
    {
        if (animal is null)
            throw new ArgumentNullException(nameof(animal));

        _repository.UpdateAnimal(animal);
    }

    internal void DeleteAnimal(Guid id)
    {
        _repository.DeleteAnimal(id);
    }

    internal List<Animal> GetAnimalsByOwner(Customer owner)
    {
        if (owner is null)
            throw new ArgumentNullException(nameof(owner));

        return _repository.GetAnimalsByOwner(owner);
    }

    internal List<Animal> GetAnimalsBySpecies(string species)
    {
        if (string.IsNullOrWhiteSpace(species))
            throw new ArgumentException("La especie no puede estar vacía.");

        return _repository.GetAnimalsBySpecies(species);
    }

    internal void ShowAllAnimals()
    {
        var animals = _repository.GetAllAnimals();

        if (animals.Count == 0)
        {
            Console.WriteLine("\n⚠️ No hay animales registrados actualmente.\n");
            return;
        }

        Console.WriteLine("\n=== LISTA DE ANIMALES REGISTRADOS ===\n");
        foreach (var animal in animals)
        {
            animal.ShowInfo();
            Console.WriteLine();
        }
    }
}
