using VeterinaryCenter.ConsoleApp.Entities;

namespace VeterinaryCenter.ConsoleApp.Repositories;

internal interface IAppointmentRepository
{
    void AddAppointment(Appointment appointment);
    List<Appointment> GetAllAppointments();
    Appointment? GetAppointmentById(Guid id);
    List<Appointment> GetAppointmentsByDate(DateOnly date);
    List<Appointment> GetAppointmentsByVeterinarian(Guid veterinarianId);
    void UpdateAppointment(Appointment appointment);
    void DeleteAppointment(Guid id);
}