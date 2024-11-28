using System.ComponentModel.DataAnnotations;
using SmileMarks.Models.Interfaces;


namespace SmileMarks.Models;

public abstract class Person(string name, string lastName, int age) : IPerson
{
    public Guid Id { get; set; } = Guid.NewGuid();
    [MaxLength(80)] public string Name { get; set; } = name;
    [MaxLength(80)] public string LastName { get; set; } = lastName;

    [Range(0, 120, ErrorMessage = "Invalid Age value!")]
    public int Age { get; set; } = age;
}