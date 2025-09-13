using System;
using System.Collections.Generic;
using System.Linq;

#region Entities
public class Student
{
    public string Id { get; set; }
    public string Name { get; set; } = "";
    public int Age { get; set; }
    public double GPA { get; set; }

    public override string ToString()
        => $"[Student] ID:{Id}, Name:{Name}, Age:{Age}, GPA:{GPA}";
}

public class Teacher
{
    public string Id { get; set; }
    public string Name { get; set; } = "";
    public string Subject { get; set; } = "";

    public override string ToString()
        => $"[Teacher] ID:{Id}, Name:{Name}, Subject:{Subject}";
}

public class Course
{
    public string Id { get; set; }
    public string Name { get; set; } = "";
    public string TeacherId { get; set; } = "";

    public override string ToString()
        => $"[Course] ID:{Id}, Name:{Name}, TeacherId:{TeacherId}";
}

public class Enrollment
{
    public string StudentId { get; set; } = "";
    public string CourseId { get; set; } = "";

    public override string ToString()
        => $"[Enroll] Student:{StudentId}, Course:{CourseId}";
}

public class Grade
{
    public string StudentId { get; set; } = "";
    public string CourseId { get; set; } = "";
    public double Score { get; set; }

    public override string ToString()
        => $"[Grade] Student:{StudentId}, Course:{CourseId}, Score:{Score}";
}
#endregion
#region Repositories
public class Repository<T>
{
    protected readonly List<T> items = new();

    public void Add(T item) => items.Add(item);
    public void Remove(T item) => items.Remove(item);
    public List<T> GetAll() => items;
}

public class StudentRepository : Repository<Student>
{
    public Student? FindById(string id) => items.FirstOrDefault(s => s.Id == id);
    public List<Student> FindByName(string name) => items.Where(s => s.Name == name).ToList();
    public List<Student> FindExcellent() => items.Where(s => s.GPA > 8.0).ToList();
    public void SortByName() => items.Sort((a, b) => a.Name.CompareTo(b.Name));
    public void SortByGPA() => items.Sort((a, b) => b.GPA.CompareTo(a.GPA));
}
#endregion

#region Menus
public static class StudentMenu
{
    public static void Run(StudentRepository repo)
    {
        int choice = 0;
        while (choice != 9)
        {
            Console.WriteLine("\n--- QUẢN LÝ SINH VIÊN ---");
            Console.WriteLine("1. Thêm SV");
            Console.WriteLine("2. Xóa SV");
            Console.WriteLine("3. Cập nhật SV");
            Console.WriteLine("4. Hiển thị tất cả SV");
            Console.WriteLine("5. Tìm SV theo tên");
            Console.WriteLine("6. Tìm SV GPA > 8");
            Console.WriteLine("7. Sắp xếp theo tên");
            Console.WriteLine("8. Sắp xếp theo GPA");
            Console.WriteLine("9. Quay lại");
            Console.Write("Chọn: ");
            if (!int.TryParse(Console.ReadLine(), out choice)) continue;

            switch (choice)
            {
                case 1:
                    AddStudent(repo);
                    break;
                case 2:
                    RemoveStudent(repo);
                    break;
                case 3:
                    UpdateStudent(repo);
                    break;
                case 4:
                    ShowAll(repo);
                    break;
                case 5:
                    FindByName(repo);
                    break;
                case 6:
                    FindExcellent(repo);
                    break;
                case 7:
                    repo.SortByName();
                    Console.WriteLine("Đã sắp xếp theo tên.");
                    break;
                case 8:
                    repo.SortByGPA();
                    Console.WriteLine("Đã sắp xếp theo GPA.");
                    break;
            }
        }
    }

    private static void AddStudent(StudentRepository repo)
    {
        Console.Write("ID: ");
        string id = Console.ReadLine() ?? "";
        Console.Write("Tên: ");
        string name = Console.ReadLine() ?? "";
        Console.Write("Tuổi: ");
        int age = int.Parse(Console.ReadLine() ?? "0");
        Console.Write("GPA: ");
        double gpa = double.Parse(Console.ReadLine() ?? "0");

        repo.Add(new Student { Id = id, Name = name, Age = age, GPA = gpa });
    }

    private static void RemoveStudent(StudentRepository repo)
    {
        Console.Write("Nhập ID cần xóa: ");
        string id = Console.ReadLine() ?? "";
        var st = repo.FindById(id);
        if (st != null) repo.Remove(st);
    }

    private static void UpdateStudent(StudentRepository repo)
    {
        Console.Write("Nhập ID cần cập nhật: ");
        string id = Console.ReadLine() ?? "";
        var st = repo.FindById(id);
        if (st != null)
        {
            Console.Write("Tên mới: ");
            st.Name = Console.ReadLine() ?? "";
            Console.Write("Tuổi mới: ");
            st.Age = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("GPA mới: ");
            st.GPA = double.Parse(Console.ReadLine() ?? "0");
        }
    }

    private static void ShowAll(StudentRepository repo)
    {
        foreach (var s in repo.GetAll())
            Console.WriteLine(s);
    }

    private static void FindByName(StudentRepository repo)
    {
        Console.Write("Nhập tên: ");
        string name = Console.ReadLine() ?? "";
        foreach (var s in repo.FindByName(name))
            Console.WriteLine(s);
    }

    private static void FindExcellent(StudentRepository repo)
    {
        foreach (var s in repo.FindExcellent())
            Console.WriteLine("SV giỏi: " + s);
    }
}
#endregion