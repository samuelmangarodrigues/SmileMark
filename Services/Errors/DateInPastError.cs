using SmileMarks.Enums;

namespace SmileMarks.Services.Errors;

public record DateInPastError() : AppError(ETypeError.Conflict, "A data não pode ser menor que a atual!");