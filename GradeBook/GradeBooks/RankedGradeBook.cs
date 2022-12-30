using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    { 
        string name;

        GradeBookType type;
        bool isWeighted;
        public RankedGradeBook(string name, bool isWeighted) : base(name,isWeighted)
        {
            this.name = name;
            type = GradeBookType.Ranked;
            IsWeighted = isWeighted;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            
                Students.Sort();
            int studentRank = 0;
            int noOfStudents = 0;
            foreach(var student in Students)
            {
                if(student.AverageGrade == averageGrade)
                {
                    studentRank = Students.IndexOf(student);
                    break;
                }
            }

             double percentile = (((noOfStudents-studentRank+1)/noOfStudents)*100);


                 if (percentile >= 80 && percentile <= 100)
                return 'A';
            else if (percentile >= 60 && percentile <= 79)
                return 'B';
            else if (percentile >= 40 && percentile <= 59)
                return 'C';
            else if (percentile >= 20 && percentile <= 39)
                return 'D';
            else
                return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to" +
                    " properly calculate a student's overall grade.");
            }

            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to" +
                    " properly calculate a student's overall grade.");
            }
            base.CalculateStudentStatistics(name);  
        }
    }
}
