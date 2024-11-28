namespace SmileMarks.Services.Interfaces;

public interface IPatientService
{
    string GetSchedules();
    string BookAnAppointment();
    string RescheduleAnAppointment();
}