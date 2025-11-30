using System;
using CourseManagementSystem.Models;

namespace CourseManagementSystem;

class Program
{
    static void Main(string[] args)
    {
        var manager = new CourseManager();

        // Создаем преподавателей
        var teacher1 = new Teacher 
        { 
            TeacherId = "T001", 
            FirstName = "Иван", 
            LastName = "Петров", 
            Email = "ivan.petrov@university.com" 
        };

        var teacher2 = new Teacher 
        { 
            TeacherId = "T002", 
            FirstName = "Мария", 
            LastName = "Сидорова", 
            Email = "maria.sidorova@university.com" 
        };

        // Создаем курсы
        var onlineCourse = new OnlineCourse 
        { 
            CourseId = "C001", 
            Name = "Программирование на C#", 
            Description = "Основы программирования на C#",
            Platform = "Microsoft Teams",
            MeetingLink = "https://teams.live/meeting/123"
        };

        var offlineCourse = new OfflineCourse 
        { 
            CourseId = "C002", 
            Name = "Базы данных", 
            Description = "Основы работы с базами данных",
            Classroom = "Аудитория 101",
            Schedule = "Пн, Ср 10:00-11:30"
        };

        // Создаем студентов
        var student1 = new Student 
        { 
            StudentId = "S001", 
            FirstName = "Анна", 
            LastName = "Иванова", 
            Email = "anna.ivanova@student.com" 
        };

        // Добавляем в систему
        manager.AddTeacher(teacher1);
        manager.AddTeacher(teacher2);
        manager.AddCourse(onlineCourse);
        manager.AddCourse(offlineCourse);
        manager.AddStudent(student1);

        // Назначаем преподавателей на курсы
        manager.AssignTeacherToCourse("T001", "C001");
        manager.AssignTeacherToCourse("T002", "C002");

        // Записываем студентов на курсы
        manager.EnrollStudentInCourse("S001", "C001");

        Console.WriteLine("\n=== Система управления курсами запущена ===");

        Console.WriteLine("\n=== Тестирование новых функций ===");
        
        // Информация о курсе
        manager.DisplayCourseInfo("C001");
        
        // Получение онлайн-курсов
        var onlineCourses = manager.GetOnlineCourses();
        Console.WriteLine($"\nОнлайн-курсов: {onlineCourses.Count}");
        
        // Получение студентов на курсе
        var studentsOnCourse = manager.GetStudentsByCourse("C001");
        Console.WriteLine($"Студентов на курсе C#: {studentsOnCourse.Count}");
        
        // Поиск объектов по ID
        var foundTeacher = manager.GetTeacherById("T001");
        Console.WriteLine($"Найден преподаватель: {foundTeacher?.FullName}");
    
    }
}
