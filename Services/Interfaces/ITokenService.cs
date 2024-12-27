using SmileMarks.Models;

namespace SmileMarks.Services.Interfaces;

public interface ITokenService
{
    string GenerateToken(User user);
}