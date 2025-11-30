namespace CourseManagementSystem.Models;

public class OnlineCourse : Course
{
    public string Platform { get; set; } = string.Empty;
    public string MeetingLink { get; set; } = string.Empty;

    public override string GetCourseType()
    {
        return "Online";
    }
}