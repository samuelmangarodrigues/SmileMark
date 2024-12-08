using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SmileMarks.Enums;
using SmileMarks.Services.Errors;

namespace SmileMarks.Utils;

public class ErrorValidator : ControllerBase
{
    public IActionResult Validator(AppError errorObject)
    {
        var response = new { message = errorObject.Message };
        
        return errorObject.Type switch
        {
            ETypeError.Conflict => Conflict(response),
            ETypeError.NotFound => NotFound(response),
            ETypeError.BadRequest => BadRequest(response),
            _ => BadRequest("Unknown Error")
        };
    }
}