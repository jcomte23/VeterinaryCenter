using VeterinaryCenter.ConsoleApp.Data;
using VeterinaryCenter.ConsoleApp.Entities;
using VeterinaryCenter.ConsoleApp.Interfaces;
using VeterinaryCenter.ConsoleApp.Models;

namespace VeterinaryCenter.ConsoleApp.Repositories;

internal class AnimalRepository : IAnimalRepository
{
    public void AddAnimal(Animal animal)
    {
        Database.Animals.Add(animal);
    }

    public List<Animal> GetAllAnimals()
    {
        return [.. Database.Animals];
    }

    public Animal? GetAnimalById(Guid id)
    {
        return Database.Animals.FirstOrDefault(a => a.Id == id);
    }

    public void UpdateAnimal(Animal animal)
    {
        var existing = GetAnimalById(animal.Id) ?? throw new KeyNotFoundException($"No se encontró el animal con ID {animal.Id}");
        var index = Database.Animals.IndexOf(existing);
        Database.Animals[index] = animal;
    }

    public void DeleteAnimal(Guid id)
    {
        var animal = GetAnimalById(id);
        if (animal is not null)
            Database.Animals.Remove(animal);
    }

    public List<Animal> GetAnimalsByOwner(Customer owner)
    {
        return [.. Database.Animals.Where(a => a.Owner?.Id == owner.Id)];
    }

    public List<Animal> GetAnimalsBySpecies(string species)
    {
        return [.. Database.Animals.Where(a => a.Species.Equals(species, StringComparison.OrdinalIgnoreCase))];
    }
}
