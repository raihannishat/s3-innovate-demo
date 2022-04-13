namespace S3Innovate.Api.Models;

public class Student
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string StudentId { get; set; } = string.Empty;
    public string CGPA { get; set; } = string.Empty;
    public string University { get; set; } = string.Empty;
    public string PassingYear { get; set; } = string.Empty;
}