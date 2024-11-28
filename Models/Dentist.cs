using System.ComponentModel.DataAnnotations;
using SmileMarks.Models.Interfaces;

namespace SmileMarks.Models;

public class Dentist(string cro, string name, string lastName, int age) : Person(name, lastName, age), IDentist
{
    public ICollection<Schedule> AvaiableSchedules { get; set; } = [];
    [MaxLength(20)] public string Cro { get; set; } = cro;
}