namespace VeterinaryCenter.ConsoleApp.Models;

public class Pet(int id, string name, byte ageInMonths, string species, int patientId)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name.ToLower().Trim();
    public byte AgeInMonths { get; set; } = ageInMonths;
    public string Species { get; set; } = species.ToLower().Trim();
    public int PatientId { get; set; } = patientId;
    public Customer? Patient { get; set; }
}