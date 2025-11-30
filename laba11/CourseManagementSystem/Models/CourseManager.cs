using System;
using System.Collections.Generic;
using System.Linq;
using CourseManagementSystem.Models.Interfaces;

namespace CourseManagementSystem.Models;

public class CourseManager : ICourseService, ITeacherService, IStudentService
{
    private List<Course> _courses;
    private List<Teacher> _teachers;
    private List<Student> _students;

    public CourseManager()
    {
        _courses = new List<Course>();
        _teachers = new List<Teacher>();
        _students = new List<Student>();
    }

    // ICourseService implementation
    public void AddCourse(Course course)
    {
        if (string.IsNullOrEmpty(course.CourseId))
            throw new ArgumentException("Course ID cannot be null or empty");
            
        _courses.Add(course);
        Console.WriteLine($"Курс '{course.Name}' добавлен.");
    }

    public void RemoveCourse(string courseId)
    {
        var course = _courses.FirstOrDefault(c => c.CourseId == courseId);
        if (course != null)
        {
            _courses.Remove(course);
            Console.WriteLine($"Курс '{course.Name}' удален.");
        }
    }

    public Course? GetCourseById(string courseId)
    {
        return _courses.FirstOrDefault(c => c.CourseId == courseId);
    }

    public List<Course> GetAllCourses()
    {
        return new List<Course>(_courses); // Возвращаем копию для защиты от изменений
    }

    public List<OnlineCourse> GetOnlineCourses()
    {
        return _courses.OfType<OnlineCourse>().ToList();
    }

    public List<OfflineCourse> GetOfflineCourses()
    {
        return _courses.OfType<OfflineCourse>().ToList();
    }

    // ITeacherService implementation
    public void AddTeacher(Teacher teacher)
    {
        if (string.IsNullOrEmpty(teacher.TeacherId))
            throw new ArgumentException("Teacher ID cannot be null or empty");
            
        _teachers.Add(teacher);
        Console.WriteLine($"Преподаватель '{teacher.FullName}' добавлен.");
    }

    public void AssignTeacherToCourse(string teacherId, string courseId)
    {
        var teacher = _teachers.FirstOrDefault(t => t.TeacherId == teacherId);
        var course = _courses.FirstOrDefault(c => c.CourseId == courseId);

        if (teacher == null)
            throw new ArgumentException($"Teacher with ID {teacherId} not found");
            
        if (course == null)
            throw new ArgumentException($"Course with ID {courseId} not found");

        course.AssignedTeacher = teacher;
        teacher.AssignedCourses.Add(course);
        Console.WriteLine($"Преподаватель {teacher.FullName} назначен на курс '{course.Name}'");
    }

    public Teacher? GetTeacherById(string teacherId)
    {
        return _teachers.FirstOrDefault(t => t.TeacherId == teacherId);
    }

    public List<Teacher> GetAllTeachers()
    {
        return new List<Teacher>(_teachers);
    }

    public List<Course> GetCoursesByTeacher(string teacherId)
    {
        return _courses.Where(c => c.AssignedTeacher?.TeacherId == teacherId).ToList();
    }

    // IStudentService implementation
    public void AddStudent(Student student)
    {
        if (string.IsNullOrEmpty(student.StudentId))
            throw new ArgumentException("Student ID cannot be null or empty");
            
        _students.Add(student);
        Console.WriteLine($"Студент '{student.FullName}' добавлен.");
    }

    public void EnrollStudentInCourse(string studentId, string courseId)
    {
        var student = _students.FirstOrDefault(s => s.StudentId == studentId);
        var course = _courses.FirstOrDefault(c => c.CourseId == courseId);

        if (student == null)
            throw new ArgumentException($"Student with ID {studentId} not found");
            
        if (course == null)
            throw new ArgumentException($"Course with ID {courseId} not found");

        if (!course.EnrolledStudents.Contains(student))
        {
            course.EnrolledStudents.Add(student);
            student.EnrolledCourses.Add(course);
            Console.WriteLine($"Студент {student.FullName} записан на курс '{course.Name}'");
        }
    }

    public void RemoveStudentFromCourse(string studentId, string courseId)
    {
        var student = _students.FirstOrDefault(s => s.StudentId == studentId);
        var course = _courses.FirstOrDefault(c => c.CourseId == courseId);

        if (student != null && course != null)
        {
            course.EnrolledStudents.Remove(student);
            student.EnrolledCourses.Remove(course);
            Console.WriteLine($"Студент {student.FullName} удален с курса '{course.Name}'");
        }
    }

    public Student? GetStudentById(string studentId)
    {
        return _students.FirstOrDefault(s => s.StudentId == studentId);
    }

    public List<Student> GetAllStudents()
    {
        return new List<Student>(_students);
    }

    public List<Student> GetStudentsByCourse(string courseId)
    {
        var course = GetCourseById(courseId);
        return course?.EnrolledStudents ?? new List<Student>();
    }

    // Вспомогательные методы
    public void DisplayCourseInfo(string courseId)
    {
        var course = GetCourseById(courseId);
        if (course != null)
        {
            Console.WriteLine($"\n=== Информация о курсе: {course.Name} ===");
            Console.WriteLine($"ID: {course.CourseId}");
            Console.WriteLine($"Тип: {course.GetCourseType()}");
            Console.WriteLine($"Описание: {course.Description}");
            Console.WriteLine($"Преподаватель: {course.AssignedTeacher?.FullName ?? "Не назначен"}");
            Console.WriteLine($"Количество студентов: {course.EnrolledStudents.Count}");
            
            if (course is OnlineCourse online)
            {
                Console.WriteLine($"Платформа: {online.Platform}");
                Console.WriteLine($"Ссылка: {online.MeetingLink}");
            }
            else if (course is OfflineCourse offline)
            {
                Console.WriteLine($"Аудитория: {offline.Classroom}");
                Console.WriteLine($"Расписание: {offline.Schedule}");
            }
        }
    }
}