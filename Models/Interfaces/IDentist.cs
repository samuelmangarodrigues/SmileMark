namespace SmileMarks.Models.Interfaces;

public interface IDentist : IUser
{
    ICollection<Schedule> AvaiableSchedules { get; set; }
    string Cro { get; set; }
}