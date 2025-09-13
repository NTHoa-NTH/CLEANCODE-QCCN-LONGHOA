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

// CHẠY CHƯƠNG TRÌNH
// TẠO MENU LỰA CHỌN ĐỐI TƯỢNG CẦN NHẬP TỪ BÀN PHÍM
public class CleanSchoolProgram {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        StudentManager sm = new StudentManager();
        TeacherManager tm = new TeacherManager();
        CourseManager cm = new CourseManager();
        EnrollmentManager em = new EnrollmentManager();
        GradeManager gm = new GradeManager();

        int menu = 0;
        while (menu != 99) {
            System.out.println("===== MENU =====");
            System.out.println("1. Quan ly Sinh vien");
            System.out.println("2. Quan ly Giao vien");
            System.out.println("3. Quan ly Mon hoc");
            System.out.println("4. Dang ky hoc");
            System.out.println("5. Quan ly Diem");
            System.out.println("6. Bao cao tong hop");
            System.out.println("99. Thoat");
            System.out.print("Chon: ");
            menu = sc.nextInt(); sc.nextLine();

            switch(menu) {
                case 1:
                    sm.add(new Student("SV01", "Hoa", 20, 8.5));
                    sm.add(new Student("SV02", "Lan", 21, 7.2));
                    sm.showAll();
                    break;
                case 2:
                    tm.add(new Teacher("T01", "Thay A", "Toan"));
                    tm.showAll();
                    break;
                case 3:
                    cm.add(new Course("C01", "Lap trinh Java", 3));
                    cm.showAll();
                    break;
                case 4:
                    em.add("SV01", "C01");
                    break;
                case 5:
                    gm.add("SV01", "C01", 9.0);
                    break;
                case 6:
                    System.out.println("=== BAO CAO ===");
                    for (Student s : sm.getAll()) {
                        System.out.println("Sinh vien: " + s.name);
                        for (Enrollment e : em.getAll()) {
                            if (e.studentId.equals(s.id)) {
                                for (Course c : cm.getAll()) {
                                    if (c.id.equals(e.courseId)) {
                                        System.out.print(" - Mon hoc: " + c.name);
                                        for (Grade g : gm.getAll()) {
                                            if (g.studentId.equals(s.id) && g.courseId.equals(c.id)) {
                                                System.out.print(" | Diem: " + g.score);
                                            }
                                        }
                                        System.out.println();
                                    }
                                }
                            }
                        }
                    }
                    break;
            }
        }
    }
}