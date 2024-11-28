using Azure;
using Microsoft.AspNetCore.Mvc;
using SmileMarks.Controllers.Interfaces;
using SmileMarks.Data;
using SmileMarks.Models;

namespace SmileMarks.Controllers;

[ApiController]
[Route("api/v1/dentist")]
public class DentistController : ControllerBase, IDentistController
{

    [HttpPost]
    public ActionResult CreateDentist(Dentist dentist)
    {
        throw new NotImplementedException();
    }

    [HttpPut]
    public OkObjectResult AddSchedules()
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public ActionResult GetSchedules()
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public ActionResult GetScheduleAndPatientDetails()
    {
        throw new NotImplementedException();
    }

    [HttpPatch]
    public ActionResult RescheduleAnAppointment()
    {
        throw new NotImplementedException();
    }


}