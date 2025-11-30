using System.Collections.Generic;

namespace CourseManagementSystem.Models.Interfaces;

public interface ICourseService
{
    void AddCourse(Course course);
    void RemoveCourse(string courseId);
    Course? GetCourseById(string courseId);
    List<Course> GetAllCourses();
    List<OnlineCourse> GetOnlineCourses();
    List<OfflineCourse> GetOfflineCourses();
}

public interface ITeacherService
{
    void AddTeacher(Teacher teacher);
    void AssignTeacherToCourse(string teacherId, string courseId);
    Teacher? GetTeacherById(string teacherId);
    List<Teacher> GetAllTeachers();
    List<Course> GetCoursesByTeacher(string teacherId);
}

public interface IStudentService
{
    void AddStudent(Student student);
    void EnrollStudentInCourse(string studentId, string courseId);
    void RemoveStudentFromCourse(string studentId, string courseId);
    Student? GetStudentById(string studentId);
    List<Student> GetAllStudents();
    List<Student> GetStudentsByCourse(string courseId);
}