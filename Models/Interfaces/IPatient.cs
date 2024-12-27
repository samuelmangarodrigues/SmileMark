namespace SmileMarks.Models.Interfaces;

public interface IPatient : IUser
{
    string Symptom { get; set; }
    Guid ScheduleId { get; set; }
    Schedule Schedule { get; set; }
}