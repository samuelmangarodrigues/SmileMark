namespace SmileMarks.DTOs;

public record CreateDentistDto(string Name, string LastName, int Age, string Cro);

public record AddScheduleDto(DateTime ScheduleDate);