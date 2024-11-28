namespace SmileMarks.Models.Interfaces;

public interface IPatient : IPerson
{
    string Symptom { get; set; }
    Guid ScheduleId { get; set; }
    Schedule Schedule { get; set; }
}