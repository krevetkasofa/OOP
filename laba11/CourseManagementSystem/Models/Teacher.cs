namespace CourseManagementSystem.Models;

public class Teacher
{
    public string TeacherId { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public List<Course> AssignedCourses { get; set; }

    public Teacher()
    {
        AssignedCourses = new List<Course>();
    }

    public string FullName => $"{FirstName} {LastName}";
}