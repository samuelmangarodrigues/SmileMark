using OneOf;
using SmileMarks.DTOs;
using SmileMarks.Models;
using SmileMarks.Services.Errors;

namespace SmileMarks.Services.Interfaces;

public interface IDentistService
{
    Task<OneOf<Dentist, AppError>> CreateDentist(CreateDentistDto newDentistRequest);
    Task<OneOf<SuccessResponse, AppError>> AddSchedules(Guid dentistId, AddScheduleDto dateRequest);
    Task<IEnumerable<DentistDto>> GetAllDentist();
    Task<OneOf<DentistDto, AppError>> GetDentistById(Guid dentistId);
    Task<OneOf<SuccessResponse, AppError>> Login(LoginDto credentials);
    string RescheduleAnAppointment();
}