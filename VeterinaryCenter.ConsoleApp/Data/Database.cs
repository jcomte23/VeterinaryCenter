using VeterinaryCenter.ConsoleApp.Models;

namespace VeterinaryCenter.ConsoleApp.Data;

public class Database
{
    public static List<DocumentType> DocumentTypes { get; set; }

    static Database()
    {
        DocumentTypes =
        [
            new DocumentType(1, "Cédula de Ciudadanía", "CC"),
            new DocumentType(2, "Tarjeta de Identidad", "TI"),
            new DocumentType(3, "Pasaporte", "PA")
        ];
    }
}