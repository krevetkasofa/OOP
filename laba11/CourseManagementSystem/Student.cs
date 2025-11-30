namespace CourseManagementSystem.Models;

public class Student
{
    public string StudentId { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public List<Course> EnrolledCourses { get; set; }

    public Student()
    {
        EnrolledCourses = new List<Course>();
    }

    public string FullName => $"{FirstName} {LastName}";
}