using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmileMarks.Controllers.Interfaces;
using SmileMarks.Data;
using SmileMarks.DTOs;
using SmileMarks.Enums;
using SmileMarks.Models;
using SmileMarks.Services;
using SmileMarks.Services.Errors;
using SmileMarks.Services.Interfaces;
using SmileMarks.Utils;

namespace SmileMarks.Controllers;

[Route("api/v1/dentist")]
[ApiController]
public class DentistController(IDentistService dentistService, ITokenService tokenService, AppDbContext context)
    : ControllerBase, IDentistController
{
    private readonly IDentistService _dentistService = dentistService;
    private readonly ITokenService _tokenService = tokenService;
    private readonly AppDbContext _context = context;

    [HttpPost]
    public async Task<IActionResult> CreateDentist([FromBody] CreateDentistDto dentist)
    {
        var newDentistResult = await _dentistService.CreateDentist(dentist);

        if (newDentistResult.IsT0)
        {
            return Ok(newDentistResult.AsT0);
        }

        var error = newDentistResult.AsT1;

        return BadRequest(error);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto credentials)
    {
        var returnValue = await _dentistService.Login(credentials);

        if (returnValue.IsT0)
        {
            var response = returnValue.AsT0;

            return Ok(new
            {
                tokrn = response.Message
            });
        }

        var error = returnValue.AsT1;
        return NotFound(new { message = error.Message });
    }


    [Authorize(Roles = "dentist")]
    [HttpGet("get_all_dentists")]
    public async Task<IActionResult> GetAllDentists()
    {
        var allDentist = await _dentistService.GetAllDentist();
        return Ok(allDentist);
    }

    [HttpGet("get_dentist/{dentistId:guid}")]
    public async Task<IActionResult> GetDentistById(Guid dentistId)
    {
        var dentist = await _dentistService.GetDentistById(dentistId);

        if (dentist.IsT0)
        {
            var response = dentist.AsT0;

            return Ok(response);
        }

        var errorObject = dentist.AsT1;
        var errorHandler = new ErrorValidator();

        return errorHandler.Validator(errorObject);
    }

    [Authorize(Roles = "dentist")]
    [HttpPatch("add_avaiable_schedules/{dentistId:guid}")]
    public async Task<IActionResult> AddSchedules(Guid dentistId, [FromBody] AddScheduleDto newSchedule)
    {
        var scheduleResult = await _dentistService.AddSchedules(dentistId, newSchedule);

        if (scheduleResult.IsT0)
        {
            var result = scheduleResult.AsT0;
            var formatResponse = new { message = result.Message };

            return Ok(formatResponse);
        }

        var errorObject = scheduleResult.AsT1;

        var errorHandler = new ErrorValidator();

        return errorHandler.Validator(errorObject);
    }

    [Authorize(Roles = "dentist")]
    [HttpPatch]
    public IActionResult RescheduleAnAppointment()
    {
        throw new NotImplementedException();
    }


}