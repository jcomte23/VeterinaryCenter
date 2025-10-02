using VeterinaryCenter.ConsoleApp.Models;

namespace VeterinaryCenter.ConsoleApp.Services;

public static class PatientService
{
    public static void RegisterPatient(List<Customer> patients)
    {
        Console.WriteLine("--- Register New Customer ---");
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

        int id = patients.Count > 0 ? patients.Max(p => p.Id) + 1 : 1;

        var patient = new Customer(id, name, age, symptom);
        patients.Add(patient);
        Console.WriteLine($"✅ Customer registered successfully (ID: {patient.Id})\n");
    }

    public static void ListPatients(List<Customer> patients)
    {
        Console.WriteLine("--- Customer List ---");
        if (patients.Count == 0)
        {
            Console.WriteLine("No patients registered yet.\n");
            return;
        }

        foreach (var p in patients)
        {
            Console.WriteLine($"ID: {p.Id}, Name: {p.Name}");
        }
        Console.WriteLine();
    }

    public static void SearchPatientByName(List<Customer> patients, string name)
    {
        Console.WriteLine($"--- Searching for: {name} ---");
        var found = patients.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        if (found != null)
        {
            Console.WriteLine($"✅ Found: ID {found.Id}, {found.Name},\n");
        }
        else
        {
            Console.WriteLine("⚠ No patient found with that name.\n");
        }
    }
}
 