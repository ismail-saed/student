using System;

namespace StudentManagementSystem
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public int InstructorId { get; set; }

        public Course(int courseId, string title, int instructorId)
        {
            CourseId = courseId;
            Title = title;
            InstructorId = instructorId;
        }

        public string PrintDetails()
        {
            return $"Course ID: {CourseId} | Title: {Title} | Instructor ID: {InstructorId}";
        }
    }
}