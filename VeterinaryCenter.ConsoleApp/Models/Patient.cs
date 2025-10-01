namespace VeterinaryCenter.ConsoleApp.Models;

public class Patient(int id, string name, int age, string symptom)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name.ToLower().Trim();
    public int Age { get; set; } = age;
    public string Symptom { get; set; } = symptom.ToLower().Trim();
}
