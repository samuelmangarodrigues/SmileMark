namespace SmileMarks.Models.Interfaces;

public interface ISchedule
{
    Guid Id { get; set; }
    DateTime ScheduleDate { get; set; }
    Guid DentistId { get; set; }
    Dentist Dentist { get; set; }
    Patient? Patient { get; set; }
    bool IsReserved { get; set; }
}