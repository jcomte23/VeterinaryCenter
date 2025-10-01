using VeterinaryCenter.ConsoleApp.Models;
using VeterinaryCenter.ConsoleApp.Services;
using VeterinaryCenter.ConsoleApp.Utils;

List<Patient> patients = [];

bool exit = false;

while (!exit)
{
    View.ShowMenu();
    string option = Console.ReadLine() ?? string.Empty;

    switch (option)
    {
        case "1":
            PatientService.RegisterPatient(patients);
            break;

        case "2":
            PatientService.ListPatients(patients);
            break;

        case "3":
            Console.Write("Enter patient name to search: ");
            string name = Console.ReadLine() ?? string.Empty;
            PatientService.SearchPatientByName(patients, name);
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