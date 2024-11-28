namespace SmileMarks.Models.Interfaces;

public interface IDentist : IPerson
{
    ICollection<Schedule> AvaiableSchedules { get; set; }
    string Cro { get; set; }
}