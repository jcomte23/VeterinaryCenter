namespace VeterinaryCenter.ConsoleApp.Utils;

public static class View
{
    private const int TotalWidth = 47;   // Ancho total del marco (sin bordes)
    private const int ContentWidth = TotalWidth - 2; // Espacio entre │ │

    public static void ShowHeader(string title)
    {
        Console.WriteLine("┌" + new string('─', TotalWidth) + "┐");
        Console.WriteLine("│" + title.PadRight(TotalWidth) + "│");
        Console.WriteLine("├" + new string('─', TotalWidth) + "┤");
    }

    public static void ShowMenu(string[] options)
    {
        foreach (var (option, index) in options.Select((text, i) => (text, i + 1)))
        {
            string line = $"{index}. {option}";
            Console.WriteLine("│ " + line.PadRight(ContentWidth - 1) + "│");
        }

        string exitLine = "0. Exit";
        Console.WriteLine("│ " + exitLine.PadRight(ContentWidth - 1) + "│");
        Console.WriteLine("└" + new string('─', TotalWidth) + "┘");
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
