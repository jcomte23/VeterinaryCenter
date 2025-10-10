using VeterinaryCenter.ConsoleApp.Menus;
using VeterinaryCenter.ConsoleApp.Repositories;
using VeterinaryCenter.ConsoleApp.Services;

var repository = new VeterinarianRepository();
var service = new VeterinarianService(repository);
var menu = new VeterinarianMenu(service);

menu.ShowMenu();
