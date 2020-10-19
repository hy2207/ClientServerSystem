using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTestScores
{
    partial class StudentTestScoresProgram
    {

        /// <summary>
        /// Create a list of students with seed data
        /// </summary>
        /// <returns>A list of students</returns>
        static public List<Student> GetStudents()
        {
            List<Student> students = new List<Student>
            {
                new Student { Name = "Michael", Scores = new int[] { 94, 92, 91, 91 } },
                new Student { Name = "Isabelle", Scores = new int[] { 66, 87, 65, 93, 86} },
                new Student { Name = "Chastity", Scores = new int[] { 76, 61, 73, 66, 54} },
                new Student { Name = "Chaim", Scores = new int[] { 94, 55, 82, 62, 52} },
                new Student { Name = "Patience", Scores = new int[] { 91, 79, 58, 63, 55} },
                new Student { Name = "Echo", Scores = new int[] { 74, 85, 73, 75, 86} },
                new Student { Name = "Pamela", Scores = new int[] { 73, 64, 53, 72, 68} },
                new Student { Name = "Anne", Scores = new int[] { 78, 96, 52, 79, 60} },
                new Student { Name = "Fuller", Scores = new int[] { 59, 68, 88, 85, 76} },
                new Student { Name = "Cameron", Scores = new int[] { 70, 73, 75, 51, 98} },
                new Student { Name = "Aurora", Scores = new int[] { 65, 70, 53, 80, 52} },
                new Student { Name = "Anthony", Scores = new int[] { 68, 69, 94, 88, 98} },
                new Student { Name = "Cheyenne", Scores = new int[] { 58, 74, 87, 88, 78} },
                new Student { Name = "Shana", Scores = new int[] { 79, 74, 98, 87, 57} },
                new Student { Name = "Rina", Scores = new int[] { 51, 97, 53, 94, 71} },
                new Student { Name = "Chadwick", Scores = new int[] { 69, 87, 93, 81, 53} },
                new Student { Name = "Curran", Scores = new int[] { 91, 82, 54, 64, 93} },
                new Student { Name = "Nathaniel", Scores = new int[] { 78, 56, 90, 66, 52} },
                new Student { Name = "Xavier", Scores = new int[] { 81, 62, 61, 69, 96} },
                new Student { Name = "Abel", Scores = new int[] { 96, 81, 80, 82, 71} },
                new Student { Name = "Cassandra", Scores = new int[] { 50, 82, 58, 89, 91} },
                new Student { Name = "Aileen", Scores = new int[] { 54, 60, 97, 88, 62} },
                new Student { Name = "Yvonne", Scores = new int[] { 91, 89, 64, 93, 97} },
                new Student { Name = "Slade", Scores = new int[] { 64, 57, 90, 96, 61} },
                new Student { Name = "Sebastian", Scores = new int[] { 98, 68, 66, 89, 65} },
                new Student { Name = "Eleanor", Scores = new int[] { 52, 97, 96, 91, 51} },
                new Student { Name = "Madaline", Scores = new int[] { 72, 65, 91, 98, 80} },
                new Student { Name = "Hilary", Scores = new int[] { 79, 68, 86, 50, 91} },
                new Student { Name = "Samson", Scores = new int[] { 87, 63, 58, 78, 98} },
                new Student { Name = "Troy", Scores = new int[] { 75, 82, 89, 90, 52} },
                new Student { Name = "Gavin", Scores = new int[] { 88, 81, 72, 97, 57} },
                new Student { Name = "Jackson", Scores = new int[] { 52, 71, 82, 51, 88} },
                new Student { Name = "Bruno", Scores = new int[] { 62, 66, 70, 82, 74} },
                new Student { Name = "Marny", Scores = new int[] { 91, 85, 78, 93, 52} },
                new Student { Name = "Gray", Scores = new int[] { 93, 69, 95, 52, 74} },
                new Student { Name = "Larissa", Scores = new int[] { 82, 84, 98, 54, 94} },
                new Student { Name = "Hope", Scores = new int[] { 69, 60, 84, 83, 91} },
                new Student { Name = "Sydnee", Scores = new int[] { 97, 69, 58, 53, 74} },
                new Student { Name = "Audra", Scores = new int[] { 82, 83, 89, 56, 96} },
                new Student { Name = "Wyoming", Scores = new int[] { 80, 57, 74, 86, 96} },
                new Student { Name = "Connor", Scores = new int[] { 55, 83, 79, 53, 58} },
                new Student { Name = "Philip", Scores = new int[] { 88, 82, 67, 65, 78} },
                new Student { Name = "Sheila", Scores = new int[] { 79, 91, 99, 72, 55} },
                new Student { Name = "Hammett", Scores = new int[] { 59, 65, 73, 91, 64} }
            };

            return students;
        }

        /// <summary>
        /// <para>Query1: simply list all students and their scores</para>
        /// 
        /// <para>Query2: list all students whose first score is below 90
        ///         and output them in sorted by name
        /// </para>  
        /// <para>
        /// You must create an anonymous type of name and first score in
        /// the select statement, and then display these two properties in
        /// the output.
        /// </para>
        /// </summary>
        /// <param name="students">List of students</param>
        /// 
        static void StudentScoresBasic(List<Student> students)
        {
            //select all student and order the result by name
            var allStudent =
                from student in students
                orderby student.Name
                select student;
            //display
            Console.WriteLine();
            Console.WriteLine("== Student Scores: All Count {0} ==", allStudent.Count());
            foreach (var s in allStudent)
                Console.WriteLine(s);

            //only showing student whose first score<90
            const int cutoffScore = 90; //declare cutoff score
            var studentAboveCutOff =
                students.Where(student => student.Scores[0] < cutoffScore) //using where, compare first score with cutoffscore
                .OrderBy(student => student.Name)
                .Select(student => new { student.Name, Score = student.Scores[0] }); //use an anonymous type

            Console.WriteLine("== Student Scores: first score < {0}, Count {1} ==", cutoffScore, studentAboveCutOff.Count());
            foreach (var s in studentAboveCutOff)
                Console.WriteLine($"{s.Name} {s.Score}");

        }

        /// <summary>
        /// <para>Query1: group students by first letter of name, ORDERED ASCENDING, then output by key then name</para>
        /// <para>Query2: group students by average, ORDERED DESCENDING, then output by key then name</para>
        /// 
        /// </summary>
        /// <param name="students">List of students</param>
        static void StudentScoresOrderAndGroup(List<Student> students)
        {
            //query1: group students by the first letter of their name
            var studentGroupQuery =
                students.OrderBy(student => student.Name)
                .GroupBy(student => student.Name[0]) //grouping with first letter of name
                .OrderBy(student => student.Key)
                .Select(student => student);
            /*
            var studentQueryLinqMethods = students
                .GroupBy(s => s.Name[0])
                .OrderBy(s => s.Key);
            var studentQueryLinqExpressions =
                from student in students
                group student by student.Name[0] into studentGroup
                orderby studentGroup.Key
            */
            Console.WriteLine();
            Console.WriteLine("== Student Groups: by first letter of name, Count {0} ==", studentGroupQuery.Count());
            foreach (var studentGroup in studentGroupQuery)
            {
                Console.WriteLine(studentGroup.Key);
                foreach (var s in studentGroup)
                    Console.WriteLine(" " + s.Name);
            }

            //query2: group students by average
            var studentGroupQuery2 =
                from student in students
                let averageScore = student.Scores.Average() / 10 //calculate average
                orderby averageScore descending //order befor grouping
                group new { student.Name, averageScore } by (int)averageScore into studentGroup
                orderby studentGroup.Key descending //sort by average
                select studentGroup;

            Console.WriteLine("== Students Groups: ordered descending by average bracket, Count {0} ==", studentGroupQuery2.Count());
            foreach (var studentGroup in studentGroupQuery2)
            {
                int temp = studentGroup.Key * 10;
                Console.WriteLine("Score > {0} and < {1} ", temp, temp + 10);

                foreach (var s in studentGroup)
                    Console.WriteLine($" {s.Name} {s.averageScore * 10} ");
            }
        }

        /// <summary>
        /// Show student test score statistics.
        /// <para>
        /// Output displays student's name, their test score average, and their max and min scores
        /// Then show the overall class average and average of all students' max and min scores
        /// </para>
        /// </summary>
        /// <param name="students">List of students</param>
        static void StudentScoreStats(List<Student> students)
        {
            //display student's name, score stats
            var studentQuery =
                students.OrderBy(student => student.Name)
                .Select(student => new
                {
                    Name = student.Name,
                    AvgScore = student.Scores.Average(), //calculate average
                    MaxScore = student.Scores.Max(), //get max score
                    MinScore = student.Scores.Min() //get min score
                });
            //average of all student's average, max, min scores
            var avgOverall = studentQuery.Average(student => student.AvgScore);
            var maxOverall = studentQuery.Average(student => student.MaxScore);
            var minOverall = studentQuery.Average(student => student.MinScore);
            //display
            Console.WriteLine();
            Console.WriteLine("== Student Score Stats, Count {0} ==", studentQuery.Count());
            foreach (var s in studentQuery)
                Console.WriteLine($"Name: {s.Name}, Average Score = {s.AvgScore}, Max Score = {s.MaxScore}, Min Score = {s.MinScore}");
            Console.WriteLine("All students overall average score = {0:f1}", avgOverall);
            Console.WriteLine("All students average of highest score = {0:f1}", maxOverall);
            Console.WriteLine("All students average of lowest score = {0:f1}", minOverall);
            Console.WriteLine();
        }

        /// <summary>
        /// Find a set of students and display their information
        /// 
        /// You MUST use lambda or Predicate/delegate with FindAll for this.
        /// </summary>
        /// <param name="students">list of students</param>
        /// <param name="search">array of student names to find</param>
        static void FindStudents(List<Student> students, params string[] search)
        {
            List<Student> foundStudents = students.FindAll(x => search.Contains(x.Name));

            //display the serching list of student
            Console.WriteLine("Searching for the following students: ");

            foreach (var searchStudent in search)
                Console.WriteLine(searchStudent);

            //display the found list of student
            Console.WriteLine("Found the following students: ");
            foreach (var s in foundStudents)
                Console.WriteLine(s);
        }
    }
}
