namespace S3Innovate.Api.Data;

public class StudentDbContext : DbContext
{
    public StudentDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Student> Students { get; set; }
}
