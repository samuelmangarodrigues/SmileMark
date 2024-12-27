using SmileMarks.DTOs;
using SmileMarks.Services.Interfaces;

namespace SmileMarks.Services;

public class ValidateCroApiService(HttpClient httpClient) : IValidateCroApiService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<ValidateResultCroResponse?> ValidateCroDentist(string cro, string uf)
    {
        var body = new
        {
            inscricao = cro,
            uf
        };

        var response = await _httpClient.PostAsJsonAsync(
            "https://api.infosimples.com/api/v2/consultas/cro/cadastro/?token=JnOufZJUhQYJmm_3vPLdZ5Pn3thMBPcDu-sLjZqb",
            body
        );

        return response.Content.ReadFromJsonAsync<ValidateResultCroResponse>().Result;
    }
}