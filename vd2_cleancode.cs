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