using StudentApi.Models;

public class TeachingAssignment
{
    public int Id { get; set; }

    public int TeacherId { get; set; }
    public Teacher? Teacher { get; set; }

    public int CourseId { get; set; }
    public Course? Course { get; set; }
}
