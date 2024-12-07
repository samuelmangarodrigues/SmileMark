using OneOf;
using SmileMarks.DTOs;
using SmileMarks.Models;
using SmileMarks.Services.Errors;

namespace SmileMarks.Services.Interfaces;

public interface IDentistService
{
    Task<Dentist> CreateDentist(CreateDentistDto newDentistRequest);
    Task<OneOf<SuccessAddSchedule, AppError>> AddSchedules(Guid dentistId, AddScheduleDto dateRequest);
    string GetSchedules();
    string GetScheduleAndPatientDetails();
    string RescheduleAnAppointment();
}