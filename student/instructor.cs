using System;

namespace StudentManagementSystem
{
    public class Instructor
    {
        public int InstructorId { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }

        public Instructor(int instructorId, string name, string specialization)
        {
            InstructorId = instructorId;
            Name = name;
            Specialization = specialization;
        }

        public string PrintDetails()
        {
            return $"Instructor ID: {InstructorId} | Name: {Name} | Specialization: {Specialization}";
        }
    }
}