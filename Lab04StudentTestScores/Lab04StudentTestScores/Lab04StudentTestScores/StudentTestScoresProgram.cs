using System;
using System.Timers;
using System.Collections.Generic;
using System.Linq;

namespace StudentTestScores
{
    /// <summary>
    /// This is a driver class for the lab. Do NOT change any of the code below.
    /// 
    /// StudentTestScores.cs and TimerTest.cs must be completed such that the
    /// method calls below generate the output found in Output.txt exactly.
    /// </summary>
    partial class StudentTestScoresProgram
    {
        static void Main(string[] args)
        {

            List<Student> students = GetStudents();

            // add another student the long way
            Student anotherStudent = new Student
            {
                Name = "Tanya",
                Scores = new int[] { 60, 77, 88, 99, 40 }
            };

            students.Add(anotherStudent);

            TestScores();  // sample only

            StudentScoresBasic(students);

            StudentScoresOrderAndGroup(students);

            StudentScoreStats(students);

            FindStudents(students, "Bruno", "Tanya", "Tony", "Sami");
            FindStudents(students, "Xerxes");

            Console.WriteLine();

            // create and start the timer

            Timer clock = TimerTest();

            Console.WriteLine("Hit enter to stop the clock ticking");
            Console.ReadLine();
            clock.Stop();
            Console.WriteLine("Clock stopped at {0}, {1} ticks", DateTime.Now, ticks);

            Console.WriteLine();
            Console.ReadLine();

        }

        /// <summary>
        /// Three example queries on the testScores array and their output
        /// </summary>
        static void TestScores()
        {
            // sample list of test scores

            List<int> testScores = new List<int>() { 95, 35, 65, 25, 100, 91, 60, 72, 55, 80, 77 };

            // select all scores and simply output them

            var allScores =
                from score in testScores
                orderby score
                select score;

            // using LINQ methods and lambdas
            // var allScores = testScores.OrderBy(s => s);

            Console.WriteLine("== Test Scores ==");
            foreach (var s in allScores)
                Console.WriteLine(s);

            // similar, but only choose scores greater than some number

            const int cutoffScore = 75;

            var scoresAboveCutoff =
                from score in testScores
                where score > cutoffScore
                select score;

            // using LINQ methods and lambdas
            // var scoresAboveCutoff = testScores.Where(s => s > cutoffScore);

            Console.WriteLine("== Test Scores > {0} ==", cutoffScore);
            foreach (var s in scoresAboveCutoff)
                Console.WriteLine(s);

            // similar, only showing above the midpoint.
            // note that we could have used a let statement here as well

            int midpointFixed = (testScores.Min() + testScores.Max()) / 2;

            // demonstrates use of anonymous type

            var scoresAboveMidpoint =
                from score in testScores
                let midpoint = (testScores.Min() + testScores.Max()) / 2
                where score > midpoint
                orderby score
                select new {
                    Midpoint = midpoint,
                    score
                };

            // using LINQ methods and lambdas
            // var scoresAboveMidpoint = testScores.Where(s => s > midpointFixed).OrderBy(s => s);


            Console.WriteLine("== Test Scores above midpoint {0} ==", midpointFixed);
            foreach (var s in scoresAboveMidpoint)
                Console.WriteLine(s);
            Console.WriteLine();
        }
    }
}


