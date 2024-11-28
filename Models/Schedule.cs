using SmileMarks.Models.Interfaces;

namespace SmileMarks.Models;

public class Schedule() : ISchedule
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime ScheduleDate { get; set; }
    public Guid DentistId { get; set; }
    public Dentist Dentist { get; set; } = null!;
    public Patient? Patient { get; set; }
    public bool IsReserved { get; set; } = false;
}