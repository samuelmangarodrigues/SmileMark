using SmileMarks.Enums;

namespace SmileMarks.Services.Errors;

public record ScheduleAlreadyExist() : AppError(ETypeError.Conflict, "O horário já existe!");