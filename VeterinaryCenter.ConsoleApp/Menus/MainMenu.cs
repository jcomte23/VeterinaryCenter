using VeterinaryCenter.ConsoleApp.Repositories;
using VeterinaryCenter.ConsoleApp.Services;
using VeterinaryCenter.ConsoleApp.Utils;

namespace VeterinaryCenter.ConsoleApp.Menus;

internal static class MainMenu
{
    public static void Show()
    {
        int option = -1;

        while (option != 0)
        {
            Console.Clear();
            View.ShowHeader("🐾 VETERINARY CENTER APP");
            View.ShowMenu([
                "Veterinarian Management",
                "Customer Management",
                "Animal Management"
            ]);

            if (!int.TryParse(Console.ReadLine(), out option))
                option = -1;

            Console.Clear();

            switch (option)
            {
                case 1:
                    ShowVeterinarianMenu();
                    break;
                case 2:
                    ShowCustomerMenu();
                    break;
                case 3:
                    ShowAnimalMenu();
                    break;
                case 0:
                    Console.WriteLine("👋 Exiting the system...");
                    break;
                default:
                    View.ShowInvalidOption();
                    break;
            }

            if (option != 0)
                View.WaitForUser();
        }
    }

    private static void ShowVeterinarianMenu()
    {
        var repository = new VeterinarianRepository();
        var service = new VeterinarianService(repository);
        var menu = new VeterinarianMenu(service);
        menu.ShowMenu();
    }

    private static void ShowCustomerMenu()
    {
        var repository = new CustomerRepository();
        var service = new CustomerService(repository);
        var menu = new CustomerMenu(service);
        menu.ShowMenu();
    }

    private static void ShowAnimalMenu()
    {
        var repository = new AnimalRepository();
        var service = new AnimalService(repository);
        var customerRepository = new CustomerRepository();
        var customerservice = new CustomerService(customerRepository);
        var menu = new AnimalMenu(service, customerservice);
        menu.Show();
    }
}

