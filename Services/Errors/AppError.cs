using SmileMarks.Enums;

namespace SmileMarks.Services.Errors;

public record AppError(ETypeError Type, string Message);