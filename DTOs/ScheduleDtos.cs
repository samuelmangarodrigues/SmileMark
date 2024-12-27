using SmileMarks.Models;

namespace SmileMarks.DTOs;

public record SuccessResponse(string Message);

public record ScheduleDto(Guid Id, DateTime ScheduleDate, Patient? Patient, bool IsReserved);