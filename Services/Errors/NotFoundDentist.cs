using SmileMarks.Enums;

namespace SmileMarks.Services.Errors;

public record NotFoundDentist() : AppError(ETypeError.NotFound, "Dentista não encontrado.");