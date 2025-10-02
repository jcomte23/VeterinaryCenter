using VeterinaryCenter.ConsoleApp.Data;
using VeterinaryCenter.ConsoleApp.Models;

Console.WriteLine("Welcome to VeterinaryCenter.ConsoleApp!");

var cliente = new Customer
(
	name: "John",
	lastName: "Doe",
	documentType: Database.DocumentTypes[0],
	documentNumber: "123456789",
	phoneNumber: "555-1234",
	email: "john.doe@gmail.com",
	address: "123 Main St", 
	birthDay: new DateOnly(1990, 1, 1)
);

cliente.ShowInfo();

