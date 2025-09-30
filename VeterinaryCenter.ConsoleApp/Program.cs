using VeterinaryCenter.ConsoleApp.Models;
using VeterinaryCenter.ConsoleApp.Services;

List<Patient> patients = new List<Patient>();
PatientService service = new PatientService();

bool exit = false;

while (!exit)
{
    Console.WriteLine("=== Veterinary Center Menu ===");
    Console.WriteLine("1. Register patient");
    Console.WriteLine("2. List patients");
    Console.WriteLine("3. Search patient by name");
    Console.WriteLine("4. Exit");
    Console.Write("Choose an option: ");
    string option = Console.ReadLine() ?? string.Empty;

    switch (option)
    {
        case "1":
            service.RegisterPatient(patients);
            break;

        case "2":
            service.ListPatients(patients);
            break;

        case "3":
            Console.Write("Enter patient name to search: ");
            string name = Console.ReadLine() ?? string.Empty;
            service.SearchPatientByName(patients, name);
            break;

        case "4":
            exit = true;
            Console.WriteLine("Exiting system. Goodbye!");
            break;

        default:
            Console.WriteLine("⚠ Invalid option. Try again.\n");
            break;
    }
}