using Microsoft.EntityFrameworkCore;
using OneOf;
using SmileMarks.Data;
using SmileMarks.DTOs;
using SmileMarks.Models;
using SmileMarks.Services.Errors;
using SmileMarks.Services.Interfaces;

namespace SmileMarks.Services;

public class DentistService(AppDbContext context) : IDentistService
{

    private readonly AppDbContext _context = context;

    public async Task<Dentist> CreateDentist(CreateDentistDto newDentistRequest)
    {
        var newDentist = new Dentist(newDentistRequest.Cro, newDentistRequest.Name, newDentistRequest.LastName,
            newDentistRequest.Age);
        _context.Dentist.Add(newDentist);
        await _context.SaveChangesAsync();

        return newDentist;
    }

    public async Task<OneOf<SuccessAddSchedule, AppError>> AddSchedules(Guid dentistId, AddScheduleDto dateRequest)
    {
        var dentist = await _context.Dentist.FindAsync(dentistId);

        if (dentist == null) return new NotFoundDentist();

        if (dateRequest.ScheduleDate < DateTime.UtcNow) return new DateInPastError();

        var isScheduled =
            await _context.Schedule.AnyAsync(
                sched => sched.DentistId == dentistId && sched.ScheduleDate == dateRequest.ScheduleDate);

        if (isScheduled) return new ScheduleAlreadyExist();

        var schedule = new Schedule
        {
            DentistId = dentistId,
            ScheduleDate = dateRequest.ScheduleDate,
        };

        dentist.AvaiableSchedules.Add(schedule);
        await _context.SaveChangesAsync();

        return new SuccessAddSchedule("Sucesso ao registrar um novo horário!");
    }


    public string GetSchedules()
    {
        throw new NotImplementedException();
    }

    public string GetScheduleAndPatientDetails()
    {
        throw new NotImplementedException();
    }

    public string RescheduleAnAppointment()
    {
        throw new NotImplementedException();
    }
}