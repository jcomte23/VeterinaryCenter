using VeterinaryCenter.ConsoleApp.Entities;
using VeterinaryCenter.ConsoleApp.Models.Enums;

namespace VeterinaryCenter.ConsoleApp.Data;

internal static class Database
{
	internal static List<Veterinarian> Veterinarians { get; } = [];

    static Database()
    {
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
    }
}

