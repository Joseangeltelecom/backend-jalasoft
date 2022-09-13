using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace ClassMembers
{
    internal struct Course
    {
        static public List<Member> studentsList;
        public Member Manager { get; }
        public Member Trainer { get; }
        public string Name { get; }
        public Course(Member manager, Member trainer, string courseName)
        {
            studentsList = new List<Member>();
            Name = courseName;

            if (manager._role == Role.manager)
            {
                Manager = manager;
            }
            else
                throw new ArgumentException("Invalid Member type, Please add a Manager");

            if (trainer._role == Role.trainer)
            {
                Trainer = trainer;
            }
            else
                throw new ArgumentException("Invalid Member type, Please add a Trainer");
        }
        public void AddStudent(Member student) {
            studentsList.Add(student);
        } // Add a student to the course.
        public void GetStudentList()
        {
            var print = new StringBuilder();

            // HEADER
            print.AppendLine($"\nCourse = {Name}");
            int n = 1;
            foreach (var student in studentsList)
            {
                print.AppendLine($"{n++}.student = {student._name}");
            }

           Console.WriteLine(print.ToString());
        } // Show student list.

    }
}
