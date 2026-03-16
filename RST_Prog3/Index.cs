using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace RST_Prog3
{
    public class Index
    {
        public Index(int id, StudyProgram program)
        {
            this.StudentID = id;
            this.Program = program;
        }

        public int StudentID { get; }

        public StudyProgram Program { get; }

        private int year;
        public int Year
        {
            get { return year; }
            set
            {
                if (value < 1 || value > 3)
                {
                    throw new ArgumentException("Napačno leto študija!");
                }
                year = value;
            }
        }

        public List<Subject> Subjects { get; } = new List<Subject>();

        public override string ToString()
        {
            string output = $"{this.StudentID} ({this.Program}): ";
            foreach (var subject in this.Subjects) 
            {
                output += $"\n\t{subject}";
            }
            return output;
        }
    }

    public enum StudyProgram
    {
        RST = 1,
        ISD = 2,
        RVRR = 3,
        iRST = 4,
        iISD = 5
    }

    public class Subject
    {
        public Subject(int id)
        {
            this.ID = id;
        }

        public int ID { get; }
        public string Name { get; set; }
        public int ECTS { get; set; }
        public int Grade { get; set; }
        public DateOnly DateCompleted { get; set; }

        public override string ToString()
        {
            return $"{Name}: {Grade} [{ECTS}], opravljeno: {DateCompleted:dd.MM.yyyy}";
        }
    }
}
