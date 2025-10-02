using VeterinaryCenter.ConsoleApp.Data;
using VeterinaryCenter.ConsoleApp.Models;

Console.WriteLine("Welcome to VeterinaryCenter.ConsoleApp!");

var cliente = new Customer
(
    "Juan",
    "Pérez",
    documentType: Database.DocumentTypes[0],
    new DateOnly(1990, 5, 21),
    "3001234567",
    "juan.perez@example.com",
    "Cra 10 #15-23, Bogotá"
);

Database.Customers.Add(cliente);

