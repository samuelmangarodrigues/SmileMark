using System.ComponentModel.DataAnnotations;
using SmileMarks.Models.Interfaces;

namespace SmileMarks.Models;

public class Patient(
    string name,
    string lastName,
    int age,
    string symptom,
    string email,
    string password
)
    : User(name, lastName, age, email, password, "patient"), IPatient
{
    [MaxLength(255)] public string Symptom { get; set; } = symptom;
    public Guid ScheduleId { get; set; }
    public Schedule Schedule { get; set; } = null!;
}