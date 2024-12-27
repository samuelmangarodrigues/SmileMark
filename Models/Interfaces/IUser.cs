namespace SmileMarks.Models.Interfaces;

public interface IUser
{
    Guid Id { get; set; }
    string Name { get; set; }
    string LastName { get; set; }
    int Age { get; set; }
    string Email { get; set; }
    string Password { get; set; }
}