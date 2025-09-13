import java.util.*;

// TẠO CÁC LỚP ĐỐI TƯỢNG 
// LỚP SINH VIÊN
class Student {
    String id;
    String name;
    int age;
    double gpa;

    public Student(String id, String name, int age, double gpa) {
        this.id = id;
        this.name = name;
        this.age = age;
        this.gpa = gpa;
    }

    @Override
    public String toString() {
        return "ID:" + id + " Name:" + name + " Age:" + age + " GPA:" + gpa;
    }
}
// LỚP GIÁO VIÊN
class Teacher {
    String id, name, major;

    public Teacher(String id, String name, String major) {
        this.id = id;
        this.name = name;
        this.major = major;
    }

    @Override
    public String toString() {
        return "ID:" + id + " Name:" + name + " Major:" + major;
    }
}
// LỚP MÔN HỌC 
class Course {
    String id, name;
    int credits;

    public Course(String id, String name, int credits) {
        this.id = id;
        this.name = name;
        this.credits = credits;
    }

    @Override
    public String toString() {
        return "ID:" + id + " Name:" + name + " Credits:" + credits;
    }
}
// LỚP ĐĂNG KÝ HỌC 
class Enrollment {
    String studentId, courseId;

    public Enrollment(String studentId, String courseId) {
        this.studentId = studentId;
        this.courseId = courseId;
    }
}
// LỚP ĐIỂM
class Grade {
    String studentId, courseId;
    double score;

    public Grade(String studentId, String courseId, double score) {
        this.studentId = studentId;
        this.courseId = courseId;
        this.score = score;
    }
}