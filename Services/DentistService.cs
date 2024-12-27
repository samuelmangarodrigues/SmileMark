using Microsoft.EntityFrameworkCore;
using OneOf;
using SmileMarks.Data;
using SmileMarks.DTOs;
using SmileMarks.Models;
using SmileMarks.Services.Errors;
using SmileMarks.Services.Interfaces;

namespace SmileMarks.Services;

public class DentistService(
    AppDbContext context,
    IValidateCroApiService validateCroApiService,
    ITokenService tokenService) : IDentistService
{
    private readonly AppDbContext _context = context;
    private readonly IValidateCroApiService _validateCroApiService = validateCroApiService;
    private readonly ITokenService _tokenService = tokenService;


    public async Task<OneOf<Dentist, AppError>> CreateDentist(CreateDentistDto newDentistRequest)
    {
        var newDentist = new Dentist(newDentistRequest.Cro, newDentistRequest.Name, newDentistRequest.LastName,
            newDentistRequest.Age, newDentistRequest.Uf, newDentistRequest.Category, newDentistRequest.Email,
            newDentistRequest.Password);

        var response = _validateCroApiService.ValidateCroDentist(newDentist.Cro, newDentist.Uf);
        var isActive = "INATIVO";

        if (response.Result != null)
            foreach (var item in response.Result.data)
            {
                newDentist.Category = item.categoria;
                newDentist.Specialization = item.especialidades;
                isActive = item.situacao;
            }

        if (isActive != "ATIVO") return new CroError();

        _context.Dentist.Add(newDentist);
        await _context.SaveChangesAsync();

        return newDentist;
    }


    public async Task<OneOf<SuccessResponse, AppError>> AddSchedules(Guid dentistId, AddScheduleDto dateRequest)
    {
        var dentist = await _context.Dentist.Include(d => d.AvaiableSchedules)
            .FirstOrDefaultAsync(d => d.Id == dentistId);

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

        await _context.Schedule.AddAsync(schedule);
        await _context.SaveChangesAsync();


        return new SuccessResponse("Sucesso ao registrar um novo horário!");
    }

    public async Task<IEnumerable<DentistDto>> GetAllDentist()
    {
        var allDentists = await _context.Dentist.AsNoTracking()
            .Select(d => new DentistDto(
                d.Id,
                d.Name,
                d.LastName,
                d.Age,
                d.Cro,
                d.Category,
                d.Specialization,
                d.AvaiableSchedules.Select(schedule =>
                    new ScheduleDto(schedule.Id, schedule.ScheduleDate, schedule.Patient, schedule.IsReserved)).ToList()
            ))
            .ToListAsync();

        return allDentists;
    }

    public async Task<OneOf<DentistDto, AppError>> GetDentistById(Guid dentistId)
    {
        var dentistExist = await _context.Dentist
            .AsNoTracking()
            .Include(dentist => dentist.AvaiableSchedules)
            .ThenInclude(schedule => schedule.Patient)
            .FirstOrDefaultAsync(d => d.Id == dentistId);

        if (dentistExist == null) return new NotFoundDentist();

        var dentistFormated = new DentistDto(dentistId, dentistExist.Name, dentistExist.LastName, dentistExist.Age,
            dentistExist.Cro, dentistExist.Category, dentistExist.Specialization,
            dentistExist.AvaiableSchedules.Select(schedule =>
                new ScheduleDto(schedule.Id, schedule.ScheduleDate, schedule.Patient, schedule.IsReserved)).ToList());


        return dentistFormated;
    }

    public async Task<OneOf<SuccessResponse, AppError>> Login(LoginDto credentials)
    {
        var dentist = await _context.Dentist
            .AsNoTracking()
            .Include(d => d.Role)
            .FirstOrDefaultAsync(d => d.Email == credentials.Email);

        if (dentist == null) return new NotFoundDentist();

        var token = _tokenService.GenerateToken(dentist);

        return new SuccessResponse(token);
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