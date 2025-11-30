namespace CourseManagementSystem.Models;

public class OfflineCourse : Course
{
    public string Classroom { get; set; } = string.Empty;
    public string Schedule { get; set; } = string.Empty;

    public override string GetCourseType()
    {
        return "Offline";
    }
}