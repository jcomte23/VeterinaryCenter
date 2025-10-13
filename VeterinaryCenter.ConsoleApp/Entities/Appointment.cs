using VeterinaryCenter.ConsoleApp.Models;

namespace VeterinaryCenter.ConsoleApp.Entities;

internal class Appointment
{
    internal Guid Id { get; } = Guid.NewGuid();

    // 🔗 Relaciones
    internal Animal Pet { get; set; }
    internal Customer Owner { get; set; }
    internal Veterinarian Veterinarian { get; set; }

    // 💉 Detalles del servicio
    internal string ServiceType { get; set; } = string.Empty;
    internal DateOnly AppointmentDate { get; set; }         // Día
    internal TimeOnly StartTime { get; set; }               // Hora de inicio
    internal TimeOnly EndTime { get; set; }                 // Hora de fin
    internal string Status { get; set; } = "Programada";    // Programada | Completada | Cancelada
    internal string? Notes { get; set; }

    public Appointment(
        Animal pet,
        Customer owner,
        Veterinarian veterinarian,
        string serviceType,
        DateOnly appointmentDate,
        TimeOnly startTime,
        TimeOnly endTime,
        string? notes = null)
    {
        Pet = pet;
        Owner = owner;
        Veterinarian = veterinarian;
        ServiceType = serviceType;
        AppointmentDate = appointmentDate;
        StartTime = startTime;
        EndTime = endTime;
        Notes = notes;
    }

    // 📋 Mostrar info
    internal void ShowInfo()
    {
        Console.WriteLine("────────────────────────────────────────────");
        Console.WriteLine($"🐾 Servicio: {ServiceType}");
        Console.WriteLine($"📅 Fecha: {AppointmentDate:yyyy-MM-dd}");
        Console.WriteLine($"🕒 Horario: {StartTime:HH\\:mm} - {EndTime:HH\\:mm}");
        Console.WriteLine($"🐶 Mascota: {Pet.Name} ({Pet.Species})");
        Console.WriteLine($"👤 Dueño: {Owner.Name} {Owner.LastName}");
        Console.WriteLine($"🩺 Veterinario: {Veterinarian.Name} {Veterinarian.LastName}");
        Console.WriteLine($"📌 Estado: {Status}");
        if (!string.IsNullOrEmpty(Notes))
            Console.WriteLine($"📝 Notas: {Notes}");
        Console.WriteLine("────────────────────────────────────────────");
    }
}