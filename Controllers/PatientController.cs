using Microsoft.AspNetCore.Mvc;
using SmileMarks.Controllers.Interfaces;
using SmileMarks.Models;
using SmileMarks.Services.Interfaces;

namespace SmileMarks.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PatientController(ITokenService tokenService) : ControllerBase, IPatientController
{
    private readonly ITokenService _tokenService = tokenService;

    [HttpPost("/login_dentist")]
    public IActionResult Login()
    {
        Patient patient = new("Testandinho", "Teste", 22, "Eu to com dor de barriga vei", "teste@teste.com", "123456");
        var token = _tokenService.GenerateToken(patient);



        return Ok(new { token });
    }
}