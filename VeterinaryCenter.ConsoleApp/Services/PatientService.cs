using VeterinaryCenter.ConsoleApp.Models;

namespace VeterinaryCenter.ConsoleApp.Services;

public static class PatientService
{
    public static void RegisterPatient(List<Patient> patients)
    {
        Console.WriteLine("--- Register New Patient ---");
        Console.Write("Enter patient name: ");
        string name = Console.ReadLine() ?? string.Empty;

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
        string symptom = Console.ReadLine() ?? string.Empty;

        var patient = new Patient(name, age, symptom);
        patients.Add(patient);
        Console.WriteLine($"✅ Patient registered successfully (ID: {patient.Id})\n");
    }

    public static void ListPatients(List<Patient> patients)
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

    public static void SearchPatientByName(List<Patient> patients, string name)
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
 