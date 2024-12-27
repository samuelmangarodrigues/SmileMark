using System.ComponentModel.DataAnnotations;
using SmileMarks.Models.Interfaces;
using BCrypt.Net;

namespace SmileMarks.Models;

public abstract class User(string name, string lastName, int age, string email, string password, string role = "user")
    : IUser
{
    private string _password = password;
    public Guid Id { get; set; } = Guid.NewGuid();
    [MaxLength(80)] public string Name { get; set; } = name;
    [MaxLength(80)] public string LastName { get; set; } = lastName;

    [MaxLength(100)]
    [EmailAddress(ErrorMessage = "O E-mail é inválido")]
    public string Email { get; set; } = email;

    [MaxLength(255)]
    [MinLength(8, ErrorMessage = "A senha deve conter pelo menos 8 caracteres")]

    public string Password { get; set; } = password;

    [Range(0, 120, ErrorMessage = "Invalid Age value!")]
    public int Age { get; set; } = age;

    public string Role { get; set; } = role;

}