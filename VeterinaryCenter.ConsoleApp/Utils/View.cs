namespace VeterinaryCenter.ConsoleApp.Utils;

public class View
{
    public static void ShowMenu()
    {
        Console.WriteLine("=== Veterinary Center Menu ===");
        Console.WriteLine("1. Register patient");
        Console.WriteLine("2. List patients");
        Console.WriteLine("3. Search patient by name");
        Console.WriteLine("4. Exit");
        Console.Write("Choose an option: ");
    }

}
