namespace SmileMarks.Services.Interfaces;

public interface IDentistService
{
    string AddSchedules();
    string GetSchedules();
    string GetScheduleAndPatientDetails();
    string RescheduleAnAppointment();
}