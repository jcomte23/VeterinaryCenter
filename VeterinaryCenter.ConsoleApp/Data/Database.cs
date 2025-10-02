using VeterinaryCenter.ConsoleApp.Models;

namespace VeterinaryCenter.ConsoleApp.Data;

public abstract class Database
{
    public static List<DocumentType> DocumentTypes { get; set; }
    public static List<Customer> Customers { get; set; }

    static Database()
    {
        DocumentTypes =
        [
            new DocumentType(1, "Cédula de Ciudadanía", "CC"),
            new DocumentType(2, "Tarjeta de Identidad", "TI"),
            new DocumentType(3, "Pasaporte", "PA")
        ];
        
        Customers =
        [
            new Customer("Juan", "Pérez", DocumentTypes[0], new DateOnly(1990, 5, 21), "3001234567", "juan.perez@example.com", "Cra 10 #15-23, Bogotá"),
            new Customer("María", "González", DocumentTypes[1], new DateOnly(2002, 11, 2), "3019876543", "maria.gonzalez@example.com", "Cl 45 #22-11, Medellín"),
            new Customer("Carlos", "Ramírez", DocumentTypes[2], new DateOnly(1985, 3, 14), "3024567890", "carlos.ramirez@example.com", "Av 7 #54-20, Cali"),
            new Customer("Laura", "Martínez", DocumentTypes[0], new DateOnly(1995, 7, 10), "3007654321", "laura.martinez@example.com", "Cl 9 #40-18, Bogotá"),
            new Customer("Andrés", "Suárez", DocumentTypes[1], new DateOnly(1998, 1, 25), "3109876543", "andres.suarez@example.com", "Cra 30 #16-45, Bucaramanga"),
            new Customer("Paula", "Moreno", DocumentTypes[0], new DateOnly(1992, 4, 5), "3206549871", "paula.moreno@example.com", "Cl 80 #12-34, Barranquilla"),
            new Customer("Santiago", "Torres", DocumentTypes[2], new DateOnly(1987, 9, 17), "3001112233", "santiago.torres@example.com", "Av 6 #77-19, Bogotá"),
            new Customer("Camila", "López", DocumentTypes[1], new DateOnly(2000, 6, 8), "3013334455", "camila.lopez@example.com", "Cl 52 #20-40, Medellín"),
            new Customer("David", "Hernández", DocumentTypes[0], new DateOnly(1993, 8, 12), "3022223344", "david.hernandez@example.com", "Cra 12 #100-25, Cartagena"),
            new Customer("Valentina", "Castro", DocumentTypes[2], new DateOnly(1999, 12, 30), "3045556677", "valentina.castro@example.com", "Cl 60 #15-90, Bogotá")
        ];
    }
}