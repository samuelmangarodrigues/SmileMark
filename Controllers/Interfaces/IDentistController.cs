using Microsoft.AspNetCore.Mvc;
using SmileMarks.DTOs;

namespace SmileMarks.Controllers.Interfaces;

public interface IDentistController
{
    public Task<IActionResult> CreateDentist(CreateDentistDto dentist);
    public Task<IActionResult> AddSchedules(Guid dentistId, AddScheduleDto newSchedule);
    public IActionResult GetSchedules();
    public IActionResult GetScheduleAndPatientDetails();
    public IActionResult RescheduleAnAppointment();
}