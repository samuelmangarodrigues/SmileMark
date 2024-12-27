using SmileMarks.Models;

namespace SmileMarks.DTOs;

public record CreateDentistDto(
    string Name,
    string LastName,
    int Age,
    string Cro,
    string Uf,
    string Category,
    string Email,
    string Password
);


public record AddScheduleDto(DateTime ScheduleDate);


public record DentistDto(
    Guid Id,
    string Name,
    string LastName,
    int Age,
    string Cro,
    string Category,
    string? Specialization,
    ICollection<ScheduleDto> AvaiableSchedules
);


public record ValidateResultCroResponse(DentistResponseValidationCro[] data);

public record DentistResponseValidationCro(string situacao, string categoria, string especialidades);