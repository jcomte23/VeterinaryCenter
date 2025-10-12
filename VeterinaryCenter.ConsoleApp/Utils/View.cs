namespace VeterinaryCenter.ConsoleApp.Utils;

public static class View
{
    // Ancho total de la caja (incluyendo bordes)
    private const int BoxWidth = 55;
    // Ancho interno del contenido (sin contar │ │)
    private const int ContentWidth = BoxWidth - 2;

    public static void ShowHeader(string title)
    {
        Console.WriteLine("┌" + new string('─', ContentWidth) + "┐");

        // Centramos el título dentro del área útil
        int leftPadding = Math.Max((ContentWidth - title.Length) / 2, 0);
        string centered = new string(' ', leftPadding) + title;
        Console.WriteLine("│" + centered.PadRight(ContentWidth) + "│");

        Console.WriteLine("├" + new string('─', ContentWidth) + "┤");
    }

    public static void ShowMenu(string[] options)
    {
        for (int i = 0; i < options.Length; i++)
        {
            string line = $"{i + 1}. {options[i]}";
            Console.WriteLine("│ " + line.PadRight(ContentWidth - 1) + "│");
        }

        string exitLine = "0. Exit";
        Console.WriteLine("│ " + exitLine.PadRight(ContentWidth - 1) + "│");
        Console.WriteLine("└" + new string('─', ContentWidth) + "┘");
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
