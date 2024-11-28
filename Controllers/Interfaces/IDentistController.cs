using Microsoft.AspNetCore.Mvc;
using SmileMarks.Models;

namespace SmileMarks.Controllers.Interfaces;

public interface IDentistController
{
    public ActionResult CreateDentist(Dentist dentist);
    public OkObjectResult AddSchedules();
    public ActionResult GetSchedules();
    public ActionResult GetScheduleAndPatientDetails();
    public ActionResult RescheduleAnAppointment();
}