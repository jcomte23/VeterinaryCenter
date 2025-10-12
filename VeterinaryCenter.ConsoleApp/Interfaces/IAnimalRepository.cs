using VeterinaryCenter.ConsoleApp.Entities;
using VeterinaryCenter.ConsoleApp.Models;

namespace VeterinaryCenter.ConsoleApp.Interfaces;

internal interface IAnimalRepository
{
    void AddAnimal(Animal animal);
    List<Animal> GetAllAnimals();
    Animal? GetAnimalById(Guid id);
    void UpdateAnimal(Animal animal);
    void DeleteAnimal(Guid id);
    List<Animal> GetAnimalsByOwner(Customer owner);
    List<Animal> GetAnimalsBySpecies(string species);
}
