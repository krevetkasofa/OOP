namespace CourseManagementSystem.Models;

public abstract class Course
{
    public string CourseId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Teacher? AssignedTeacher { get; set; }
    public List<Student> EnrolledStudents { get; set; }

    protected Course()
    {
        EnrolledStudents = new List<Student>();
    }

    public abstract string GetCourseType();
}