namespace SmileMarks.Models.Interfaces;

public interface IPerson
{
    Guid Id { get; set; }
    string Name { get; set; }
    string LastName { get; set; }
    int Age { get; set; }
}