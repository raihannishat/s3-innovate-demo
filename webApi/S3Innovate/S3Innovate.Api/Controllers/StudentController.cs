namespace S3Innovate.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly StudentDbContext _context;

    public StudentController(StudentDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _context.Students.ToListAsync());
    }

    [HttpGet("{id}")]
    [ActionName("Get")]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var student = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);

        if (student != null)
        {
            return Ok(student);
        }

        return NotFound("Student not found");
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Student student)
    {
        student.Id = Guid.NewGuid();

        await _context.Students.AddAsync(student);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = student.Id }, student);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] Student student)
    {
        var studentEntity = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);

        if (studentEntity != null)
        {
            studentEntity.Name = student.Name;
            studentEntity.StudentId = student.StudentId;
            studentEntity.CGPA = student.CGPA;
            studentEntity.University = student.University;
            studentEntity.PassingYear = student.PassingYear;
            await _context.SaveChangesAsync();
            return Ok(studentEntity);
        }

        return NotFound("Student not found");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var studentEntity = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);

        if (studentEntity != null)
        {
            _context.Students.Remove(studentEntity);
            await _context.SaveChangesAsync();
            return Ok(studentEntity);
        }

        return NotFound("Student not found");
    }
}
