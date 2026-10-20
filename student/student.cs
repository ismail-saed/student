using System;
using System.Collections.Generic;

namespace StudentManagementSystem
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Course> Courses { get; set; }

        public Student(int studentId, string name, int age)
        {
            StudentId = studentId;
            Name = name;
            Age = age;
            Courses = new List<Course>();
        }

        public bool Enroll(Course course)
        {
            if (Courses.Exists(c => c.CourseId == course.CourseId))
            {
                return false;
            }
            Courses.Add(course);
            return true;
        }

        public string PrintDetails()
        {
            string courseList = Courses.Count > 0
                ? string.Join(", ", Courses.ConvertAll(c => c.Title))
                : "No Enrolled Courses";

            return $"Student ID: {StudentId} | Name: {Name} | Age: {Age} | Courses: [{courseList}]";
        }
    }
}