namespace VeterinaryCenter.ConsoleApp.Models;

public class Patient
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public string Symptom { get; set; } = string.Empty;

    public Patient(string name, int age, string symptom)
    {
        Id = 1;
        Name = name;
        Age = age;
        Symptom = symptom;
    }
}
