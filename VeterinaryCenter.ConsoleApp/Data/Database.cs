using VeterinaryCenter.ConsoleApp.Entities;
using VeterinaryCenter.ConsoleApp.Models;
using VeterinaryCenter.ConsoleApp.Models.Enums;

namespace VeterinaryCenter.ConsoleApp.Data;

internal static class Database
{
	internal static List<Veterinarian> Veterinarians { get; } = [];
    internal static List<Customer> Customers { get; } = [];
    internal static List<Animal> Animals { get; } = [];
    internal static List<Appointment> Appointments { get; } = [];

    static Database()
    {
        // === Veterinarians ===
        var veterinarian1 = new Veterinarian(
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
        var veterinarian2 = new Veterinarian(
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

        Veterinarians.AddRange([veterinarian1, veterinarian2]);

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

        Customers.AddRange([customer1, customer2, customer3, customer4]);

        // === Animals ===
        var dog1 = new Dog(
            name: "Rocky",
            species: "Perro",
            breed: "Labrador Retriever",
            color: "Dorado",
            gender: "Macho",
            weight: 28.5,
            birthDate: new DateOnly(2019, 3, 15),
            isNeutered: true,
            size: "Grande",
            microchipNumber: "CHP-001",
            owner: customer1
        );
        var dog2 = new Dog(
            name: "Luna",
            species: "Perro",
            breed: "Border Collie",
            color: "Blanco y negro",
            gender: "Hembra",
            weight: 18.2,
            birthDate: new DateOnly(2020, 8, 10),
            isNeutered: false,
            size: "Mediano",
            microchipNumber: "CHP-002",
            owner: customer2
        );
        var dog3 = new Dog(
            name: "Toby",
            species: "Perro",
            breed: "Beagle",
            color: "Tricolor",
            gender: "Macho",
            weight: 12.4,
            birthDate: new DateOnly(2021, 1, 25),
            isNeutered: true,
            size: "Pequeño",
            microchipNumber: "CHP-003",
            owner: customer3
        );
        var dog4 = new Dog(
            name: "Nala",
            species: "Perro",
            breed: "Golden Retriever",
            color: "Dorado claro",
            gender: "Hembra",
            weight: 26.8,
            birthDate: new DateOnly(2018, 11, 5),
            isNeutered: true,
            size: "Grande",
            microchipNumber: "CHP-004",
            owner: customer1
        );
        var dog5 = new Dog(
            name: "Max",
            species: "Perro",
            breed: "Pastor Alemán",
            color: "Negro y fuego",
            gender: "Macho",
            weight: 32.0,
            birthDate: new DateOnly(2017, 6, 18),
            isNeutered: false,
            size: "Grande",
            microchipNumber: "CHP-005",
            owner: null // 👈 sin dueño asignado
        );

        // Agregar a la lista
        Animals.AddRange([dog1, dog2, dog3, dog4, dog5]);

        var appointment1 = new Appointment(
           pet: dog1,
           owner: customer1,
           veterinarian: veterinarian1,
           serviceType: "Vacunación antirrábica",
           appointmentDate: new DateOnly(2025, 10, 15),
           startTime: new TimeOnly(14, 00),
           endTime: new TimeOnly(14, 30),
           notes: "Primera dosis de vacuna."
       );

        Appointments.Add(appointment1);
    }
}

