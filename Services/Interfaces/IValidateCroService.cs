using SmileMarks.DTOs;

namespace SmileMarks.Services.Interfaces;

public interface IValidateCroApiService
{
    Task<ValidateResultCroResponse?> ValidateCroDentist(string cro, string uf);
}