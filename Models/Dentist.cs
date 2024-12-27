using System.ComponentModel.DataAnnotations;
using SmileMarks.Models.Interfaces;

namespace SmileMarks.Models;

public class Dentist(
    string cro,
    string name,
    string lastName,
    int age,
    string uf,
    string category,
    string email,
    string password
)
    : User(name, lastName, age, email, password, "dentist"), IDentist
{
    public ICollection<Schedule> AvaiableSchedules { get; set; } = [];
    [MaxLength(20)] public string Cro { get; set; } = cro;
    [MaxLength(20)] public string Uf { get; set; } = uf;
    [MaxLength(120)] public string Category { get; set; } = category;
    [MaxLength(120)] public string? Specialization { get; set; } = string.Empty;

}