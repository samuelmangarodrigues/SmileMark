using Azure;
using Microsoft.AspNetCore.Mvc;
using SmileMarks.Models;

namespace SmileMarks.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    [HttpGet("/get_dentist_test")]
    public OkObjectResult Get()
    {
        Schedule schedule = new Schedule();
        schedule.IsReserved = true;
        Patient patient = new("Samuel", "Manga", 24, "Dor de cabeçççç");
        patient.Schedule = schedule;

        return Ok(patient);
    }
}