using System;
using Xunit;
using CourseManagementSystem.Models;

namespace CourseManagementSystem.Tests;


public class UnitTest1
{
    [Fact]
    public void AddCourse_ShouldAddCourseToList()
    {
        // Arrange
        var manager = new CourseManager();
        var course = new OnlineCourse 
        { 
            CourseId = "TEST001", 
            Name = "Test Course" 
        };

        // Act
        manager.AddCourse(course);

        // Assert
        var allCourses = manager.GetAllCourses();
        Assert.Contains(course, allCourses);
    }

    [Fact]
    public void AssignTeacherToCourse_ShouldAssignTeacherCorrectly()
    {
        // Arrange
        var manager = new CourseManager();
        var teacher = new Teacher 
        { 
            TeacherId = "T001", 
            FirstName = "John", 
            LastName = "Doe" 
        };
        var course = new OnlineCourse 
        { 
            CourseId = "C001", 
            Name = "Programming" 
        };

        // Act
        manager.AddTeacher(teacher);
        manager.AddCourse(course);
        manager.AssignTeacherToCourse("T001", "C001");

        // Assert
        var teacherCourses = manager.GetCoursesByTeacher("T001");
        Assert.Single(teacherCourses);
        Assert.Equal("Programming", teacherCourses[0].Name);
    }

    [Fact]
    public void EnrollStudentInCourse_ShouldEnrollStudent()
    {
        // Arrange
        var manager = new CourseManager();
        var student = new Student 
        { 
            StudentId = "S001", 
            FirstName = "Alice" 
        };
        var course = new OnlineCourse 
        { 
            CourseId = "C001", 
            Name = "Math" 
        };

        // Act
        manager.AddStudent(student);
        manager.AddCourse(course);
        manager.EnrollStudentInCourse("S001", "C001");

        // Assert
        var allCourses = manager.GetAllCourses();
        var mathCourse = allCourses[0];
        Assert.Single(mathCourse.EnrolledStudents);
        Assert.Equal("Alice", mathCourse.EnrolledStudents[0].FirstName);
    }
}