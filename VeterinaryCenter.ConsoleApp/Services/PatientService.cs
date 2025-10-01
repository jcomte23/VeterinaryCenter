using VeterinaryCenter.ConsoleApp.Models;

namespace VeterinaryCenter.ConsoleApp.Services;

public class PatientService
{
    private int _nextId = 1;

    public void RegisterPatient(List<Patient> patients)
    {
        Console.WriteLine("--- Register New Patient ---");
        var id = _nextId++;

        Console.Write("Enter patient name: ");
        var name = Console.ReadLine() ?? string.Empty;

        Console.Write("Enter age: ");
        int age;
        try
        {
            age = int.Parse(Console.ReadLine() ?? "0");
        }
        catch
        {
            Console.WriteLine("⚠ Invalid age. Defaulting to 0.");
            age= 0;
        }

        Console.Write("Enter symptom: ");
        var symptom = Console.ReadLine() ?? string.Empty;

        Patient p = new Patient(name, age, symptom);
        patients.Add(p);
        Console.WriteLine($"✅ Patient registered successfully (ID: {p.Id})\n");
    }

    public void ListPatients(List<Patient> patients)
    {
        Console.WriteLine("--- Patient List ---");
        if (patients.Count == 0)
        {
            Console.WriteLine("No patients registered yet.\n");
            return;
        }

        foreach (var p in patients)
        {
            Console.WriteLine($"ID: {p.Id}, Name: {p.Name}, Age: {p.Age}, Symptom: {p.Symptom}");
        }
        Console.WriteLine();
    }

    public void SearchPatientByName(List<Patient> patients, string name)
    {
        Console.WriteLine($"--- Searching for: {name} ---");
        var found = patients.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        if (found != null)
        {
            Console.WriteLine($"✅ Found: ID {found.Id}, {found.Name}, Age {found.Age}, Symptom: {found.Symptom}\n");
        }
        else
        {
            Console.WriteLine("⚠ No patient found with that name.\n");
        }
    }

}
 