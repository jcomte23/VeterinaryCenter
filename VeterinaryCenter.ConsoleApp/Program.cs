using VeterinaryCenter.ConsoleApp.Interfaces;
using VeterinaryCenter.ConsoleApp.Menus;
using VeterinaryCenter.ConsoleApp.Repositories;


// Crear dependencias manualmente (sin inyección de dependencias aún)
IVeterinarianRepository veterinarianRepository = new VeterinarianRepository();

// Crear el menú pasando la dependencia
var veterinarianMenu = new VeterinarianMenu(veterinarianRepository);

// Mostrar el menú de veterinarios
veterinarianMenu.ShowMenu();
