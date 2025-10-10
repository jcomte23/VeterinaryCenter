namespace VeterinaryCenter.ConsoleApp.Utils;

public static class View
{
    public static void ShowHeader(string title)
    {
        Console.WriteLine("┌───────────────────────────────────────────────┐");
        Console.WriteLine($"│ {title,-45}│");
        Console.WriteLine("├───────────────────────────────────────────────┤");
    }

    public static void ShowMenu(string[] options)
    {
        for (int i = 0; i < options.Length; i++)
        {
            Console.WriteLine($"│ {i + 1}. {options[i],-42}│");
        }
        Console.WriteLine("│ 0. Exit                                       │");
        Console.WriteLine("└───────────────────────────────────────────────┘");
        Console.Write("Choose an option: ");
    }

    public static void ShowInvalidOption()
    {
        Console.WriteLine("\n❌ Invalid option. Please try again.");
    }

    public static void WaitForUser()
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
}
