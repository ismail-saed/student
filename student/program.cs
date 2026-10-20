using System;
using System.Collections.Generic;

namespace StudentManagementSystem
{
    class Program
    {
        static List<Student> students = new List<Student>();
        static List<Course> courses = new List<Course>();
        static List<Instructor> instructors = new List<Instructor>();

        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n===========================================");
                Console.WriteLine("        Student Management System          ");
                Console.WriteLine("===========================================");
                Console.WriteLine("1. Add a new Student");
                Console.WriteLine("2. View all Students");
                Console.WriteLine("3. Search for a Student by ID");
                Console.WriteLine("4. Update Student Information");
                Console.WriteLine("5. Delete a Student");
                Console.WriteLine("6. Add a new Course");
                Console.WriteLine("7. Add a new Instructor");
                Console.WriteLine("8. Enroll a Student in a Course");
                Console.WriteLine("9. View all Courses");
                Console.WriteLine("10. View all Instructors");
                Console.WriteLine("11. Exit");
                Console.Write("Select an option (1-11): ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1": AddStudent(); break;
                    case "2": ViewAllStudents(); break;
                    case "3": SearchStudentById(); break;
                    case "4": UpdateStudent(); break;
                    case "5": DeleteStudent(); break;
                    case "6": AddCourse(); break;
                    case "7": AddInstructor(); break;
                    case "8": EnrollStudentInCourse(); break;
                    case "9": ViewAllCourses(); break;
                    case "10": ViewAllInstructors(); break;
                    case "11": exit = true; break;
                    default: Console.WriteLine("Invalid option! Please try again."); break;
                }
            }
        }

        static void AddStudent()
        {
            Console.Write("Enter Student ID: ");
            int id = int.Parse(Console.ReadLine());

            if (students.Exists(s => s.StudentId == id))
            {
                Console.WriteLine("A student with this ID already exists!");
                return;
            }

            Console.Write("Enter Student Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Student Age: ");
            int age = int.Parse(Console.ReadLine());

            students.Add(new Student(id, name, age));
            Console.WriteLine("Student added successfully!");
        }

        static void ViewAllStudents()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No students found.");
                return;
            }

            Console.WriteLine("--- Students List ---");
            foreach (var student in students)
            {
                Console.WriteLine(student.PrintDetails());
            }
        }

        static void SearchStudentById()
        {
            Console.Write("Enter Student ID to search: ");
            int id = int.Parse(Console.ReadLine());

            Student student = students.Find(s => s.StudentId == id);
            if (student != null)
            {
                Console.WriteLine("Student Found:");
                Console.WriteLine(student.PrintDetails());
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        static void UpdateStudent()
        {
            Console.Write("Enter Student ID to update: ");
            int id = int.Parse(Console.ReadLine());

            Student student = students.Find(s => s.StudentId == id);
            if (student != null)
            {
                Console.Write("Enter New Name (leave blank to keep current): ");
                string newName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newName)) student.Name = newName;

                Console.Write("Enter New Age (enter 0 to keep current): ");
                int newAge = int.Parse(Console.ReadLine());
                if (newAge > 0) student.Age = newAge;

                Console.WriteLine("Student updated successfully!");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        static void DeleteStudent()
        {
            Console.Write("Enter Student ID to delete: ");
            int id = int.Parse(Console.ReadLine());

            Student student = students.Find(s => s.StudentId == id);
            if (student != null)
            {
                students.Remove(student);
                Console.WriteLine("Student deleted successfully!");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        static void AddCourse()
        {
            Console.Write("Enter Course ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter Course Title: ");
            string title = Console.ReadLine();

            Console.Write("Enter Instructor ID for this Course: ");
            int instructorId = int.Parse(Console.ReadLine());

            courses.Add(new Course(id, title, instructorId));
            Console.WriteLine("Course added successfully!");
        }

        static void AddInstructor()
        {
            Console.Write("Enter Instructor ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter Instructor Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Instructor Specialization: ");
            string spec = Console.ReadLine();

            instructors.Add(new Instructor(id, name, spec));
            Console.WriteLine("Instructor added successfully!");
        }

        static void EnrollStudentInCourse()
        {
            Console.Write("Enter Student ID: ");
            int studentId = int.Parse(Console.ReadLine());

            Student student = students.Find(s => s.StudentId == studentId);
            if (student == null)
            {
                Console.WriteLine("Student not found!");
                return;
            }

            Console.Write("Enter Course ID: ");
            int courseId = int.Parse(Console.ReadLine());

            Course course = courses.Find(c => c.CourseId == courseId);
            if (course == null)
            {
                Console.WriteLine("Course not found!");
                return;
            }

            bool success = student.Enroll(course);
            if (success)
            {
                Console.WriteLine($"Student '{student.Name}' enrolled in '{course.Title}' successfully!");
            }
            else
            {
                Console.WriteLine("Student is already enrolled in this course.");
            }
        }

        static void ViewAllCourses()
        {
            if (courses.Count == 0)
            {
                Console.WriteLine("No courses found.");
                return;
            }

            Console.WriteLine("--- Courses List ---");
            foreach (var course in courses)
            {
                Console.WriteLine(course.PrintDetails());
            }
        }

        static void ViewAllInstructors()
        {
            if (instructors.Count == 0)
            {
                Console.WriteLine("No instructors found.");
                return;
            }

            Console.WriteLine("--- Instructors List ---");
            foreach (var instructor in instructors)
            {
                Console.WriteLine(instructor.PrintDetails());
            }
        }
    }
}