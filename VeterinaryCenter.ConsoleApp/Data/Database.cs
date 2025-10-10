using VeterinaryCenter.ConsoleApp.Entities;
using VeterinaryCenter.ConsoleApp.Models.Enums;

namespace VeterinaryCenter.ConsoleApp.Data;

internal static class Database
{
	internal static List<Veterinarian> Veterinarians { get; } = [];

    internal static List<Customer> Customers { get; } = [];

    static Database()
    {
        // === Veterinarians ===
        var vet1 = new Veterinarian(
            name: "Laura",
            lastName: "Gómez",
            documentType: DocumentType.CC,
            documentNumber: "1023456789",
            phoneNumber: "3001234567",
            email: "laura.gomez@vetericenter.com",
            address: "Cra 10 #45-23, Medellín",
            specialty: "Cirugía",
            yearsExperience: 7
        );

        var vet2 = new Veterinarian(
            name: "Andrés",
            lastName: "Pérez",
            documentType: DocumentType.CC,
            documentNumber: "9876543210",
            phoneNumber: "3019876543",
            email: "andres.perez@vetericenter.com",
            address: "Calle 50 #22-10, Bogotá",
            specialty: "Medicina General",
            yearsExperience: 5
        );

        Veterinarians.Add(vet1);
        Veterinarians.Add(vet1);

        // === Customers ===
        var customer1 = new Customer(
            name: "María",
            lastName: "Rodríguez",
            documentType: DocumentType.CC,
            documentNumber: "1122334455",
            phoneNumber: "3205566778",
            email: "maria.rodriguez@gmail.com",
            address: "Av. Las Palmas #12-34, Medellín",
            birthDay: new DateOnly(1990, 5, 14)
        );

        var customer2 = new Customer(
            name: "Carlos",
            lastName: "Martínez",
            documentType: DocumentType.CC,
            documentNumber: "2233445566",
            phoneNumber: "3109988776",
            email: "carlos.martinez@hotmail.com",
            address: "Calle 80 #30-45, Bogotá",
            birthDay: new DateOnly(1985, 9, 22)
        );

        var customer3 = new Customer(
            name: "Lucía",
            lastName: "Torres",
            documentType: DocumentType.CC,
            documentNumber: "5566778899",
            phoneNumber: "3114455667",
            email: "lucia.torres@yahoo.com",
            address: "Cra 5 #15-20, Cali",
            birthDay: new DateOnly(1995, 12, 3)
        );

        var customer4 = new Customer(
            name: "Jorge",
            lastName: "Ramírez",
            documentType: DocumentType.CC,
            documentNumber: "7788990011",
            phoneNumber: "3023344556",
            email: "jorge.ramirez@gmail.com",
            address: "Calle 60 #40-10, Barranquilla",
            birthDay: new DateOnly(1992, 3, 18)
        );

        Customers.Add(customer1);
        Customers.Add(customer2);
        Customers.Add(customer3);
        Customers.Add(customer4);

    }
}

