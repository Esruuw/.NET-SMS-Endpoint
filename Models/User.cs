public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = "";
    public string Password { get; set; } = ""; // store hashed later!
    public string Role { get; set; } = ""; // Admin, Teacher, Student
}