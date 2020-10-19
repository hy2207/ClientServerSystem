using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTestScores
{
    /// <summary>
    /// Student class
    /// Contains name and a set of test scores
    /// </summary>
    public class Student
    {
        public string Name { get; set; }  // student name
        public int[] Scores { get; set; } // test scores

        // constructor - just need 4 test scores for this example

        public Student() { }

        // ToString() override allows for easier display of student and their scores

        override public string ToString()
        {
            return $"Name: {Name}, Scores: {Scores[0]}, {Scores[1]}, {Scores[2]}, {Scores[3]}";
        }
    }
}
