using Microsoft.AspNetCore.Mvc;

namespace SmileMarks.Controllers.Interfaces;

public interface IPatientController
{
    IActionResult Login();
}