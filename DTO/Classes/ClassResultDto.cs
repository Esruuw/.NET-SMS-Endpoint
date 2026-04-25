public class ClassResultDto
{
    public int ClassId { get; set; }
    public string ClassName { get; set; } = string.Empty;

    public List<StudentResultDto> Students { get; set; } = new();
}
