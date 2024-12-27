using SmileMarks.Enums;

namespace SmileMarks.Services.Errors;

public record CroError() : AppError(ETypeError.NotFound, "CRO não encontrado ou inativo");