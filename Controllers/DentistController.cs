using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SmileMarks.Controllers.Interfaces;
using SmileMarks.DTOs;
using SmileMarks.Enums;
using SmileMarks.Services;
using SmileMarks.Services.Interfaces;

namespace SmileMarks.Controllers;

[Route("api/v1/dentist")]
[ApiController]
public class DentistController(IDentistService dentistService) : ControllerBase, IDentistController
{
    private readonly IDentistService _dentistService = dentistService;

    [HttpPost]
    public async Task<IActionResult> CreateDentist([FromBody] CreateDentistDto dentist)
    {
        var newDentistResult = await _dentistService.CreateDentist(dentist);

        return Ok(newDentistResult);
    }

    [HttpGet("get_all_dentist")]
    public IActionResult GetScheduleAndPatientDetails()
    {
        return Ok("Deu certo");
    }

    [HttpGet("get_all_schedules")]
    public IActionResult GetSchedules()
    {
        throw new NotImplementedException();
    }

    [HttpPatch("add_avaiable_schedules/{dentistId:guid}")]
    public async Task<IActionResult> AddSchedules(Guid dentistId, [FromBody] AddScheduleDto newSchedule)
    {
        var scheduleResult = await _dentistService.AddSchedules(dentistId, newSchedule);

        if (scheduleResult.IsT0)
        {
            var result = scheduleResult.AsT0;

            return Ok(result.Message);
        }

        var errorObject = scheduleResult.AsT1;

        return errorObject.Type switch
        {
            ETypeError.Conflict => Conflict(errorObject.Message),
            ETypeError.NotFound => NotFound(errorObject.Message),
            ETypeError.BadRequest => BadRequest(errorObject.Message),
            _ => BadRequest("Unknown Error")
        };
    }

    [HttpPatch]
    public IActionResult RescheduleAnAppointment()
    {
        throw new NotImplementedException();
    }


}