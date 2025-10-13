using VeterinaryCenter.ConsoleApp.Data;
using VeterinaryCenter.ConsoleApp.Entities;

namespace VeterinaryCenter.ConsoleApp.Services;

internal class AppointmentRepository
{
    internal void AddAppointment(Appointment appointment)
    {
        Database.Appointments.Add(appointment);
    }

    internal List<Appointment> GetAllAppointments()
    {
        return Database.Appointments;
    }

    internal Appointment? GetAppointmentById(Guid id)
    {
        return Database.Appointments.FirstOrDefault(a => a.Id == id);
    }

    internal List<Appointment> GetAppointmentsByDate(DateOnly date)
    {
        return Database.Appointments
            .Where(a => a.AppointmentDate == date)
            .ToList();
    }

    internal List<Appointment> GetAppointmentsByVeterinarian(Guid veterinarianId)
    {
        return Database.Appointments
            .Where(a => a.Veterinarian.Id == veterinarianId)
            .ToList();
    }

    public void UpdateAppointment(Appointment appointment)
    {
        var index = Database.Appointments.FindIndex(a => a.Id == appointment.Id);
        if (index != -1)
        {
            Database.Appointments[index] = appointment;
        }
    }

    public void DeleteAppointment(Guid id)
    {
        var appointment = GetAppointmentById(id);
        if (appointment is not null)
            Database.Appointments.Remove(appointment);
    }
}