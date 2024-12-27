using Microsoft.AspNetCore.Mvc;
using SmileMarks.DTOs;

namespace SmileMarks.Controllers.Interfaces;

public interface IDentistController
{
    public Task<IActionResult> CreateDentist(CreateDentistDto dentist);
    public Task<IActionResult> AddSchedules(Guid dentistId, AddScheduleDto newSchedule);
    public Task<IActionResult> GetDentistById(Guid dentistId);
    public Task<IActionResult> Login([FromBody] LoginDto credentials);
    public Task<IActionResult> GetAllDentists();
    public IActionResult RescheduleAnAppointment();
}