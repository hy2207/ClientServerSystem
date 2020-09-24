using System;
using System.Collections;
using System.Collections.Generic;
using static System.Console;

namespace Lab02SportsLeague
{
    // Insert classes and enum here
    #region Participants class
    /// <summary>
    /// participant abstract class - base class for anyone on a team, can't be instantiated
    /// </summary>
    public abstract class Participant : IComparable<Participant>
    {
        //fields
        private static int nParticipants = 0; //used to keep a count of participants

        //constructor
        public Participant(string firstName, string lastName, int age)  
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;

            nParticipants++; //increase the number of participants
        }
        #region Participant properties
        public int Age
        {
            get; set;
        }
        public string FirstName
        {
            get; set;
        }
        public string LastName
        {
            get; set;
        }
        #endregion
        //method
        public static int GetNumberOfParticipants()
        {
            return nParticipants;
        }

        public int CompareTo(Participant p)
        {
            return this.LastName.CompareTo(p.LastName);
        }
        
    }
    #endregion
    #region Athlete class
    class Athlete : Participant
    {
        public Athlete(string firstName, string lastName, string position, int age)
            : base(firstName, lastName, age)
        {
            Position = position;
        }
        public string Position
        {
            get; set;
        }
    }
    #endregion
    #region Coach class
    public class Coach : Participant
    {
        public Coach(string firstName, string lastName, int age, Sport canCoachSport)
            : base(firstName, lastName, age)
        {
            CanCoachSport = canCoachSport;
        }
        public Sport CanCoachSport
        {
            get; set;
        }
        
    }
    #endregion
    //enum
    public enum Sport
    {
        HOCKEY, BASKETBALL, SOCCER
    }
    
    //team class
    class Team
    {
        //field
        private int teamSize = 0;
        private Athlete[] athletes;
        //constructor
        public Team() { }
        public Team(string name,Sport sport, int maxTeamSize)
        {
            TeamName = name;
            TeamSport = sport;
            MaxTeamSize = maxTeamSize;

            athletes = new Athlete[maxTeamSize];
        }
        #region Team class properties
        public Coach TeamCoach
        {
            get; private set;
            //only team class obj can set it 
        }
        public Sport TeamSport
        {
            get; set;
        }
        public string TeamName
        {
            get; set;
        }
        public int TeamSize
        {
            get { return teamSize;  }
            set
            {
                if (value > MaxTeamSize)
                    WriteLine("Team size must be lower than " + MaxTeamSize);
                else
                    teamSize = value;
            }
        }
        public int MaxTeamSize
        {
            get;
            set;
        }
        #endregion
        #region Team class methods
        public bool AddAthlete(Athlete a)
        {
            if(TeamSize < MaxTeamSize)
            {
                athletes[teamSize] = a;
                teamSize++;
                return true;
            }
            else
            {
                return false;
            }
            
        }
        public void AddCoach(Coach c)
        {
            if (c.CanCoachSport == TeamSport)
            {
                TeamCoach = c;
            }
        }

        public void DisplayTeam()
        {
            Array.Sort(athletes,0,teamSize); //sort array
            //Array.Sort(athletes,0, teamSize, new SortRoster() ); // 2nd way

            WriteLine($"\n======= {TeamSport} Team =======");
            WriteLine($"Team Name: {TeamName} - {TeamSize} players ({MaxTeamSize} max)");
            if (TeamCoach != null)
            {
                WriteLine($"Coach: {TeamCoach.FirstName} {TeamCoach.LastName} (age: {TeamCoach.Age}) (CanCoach {TeamCoach.CanCoachSport})");
                WriteLine("\nTeam Roster\n");
            }
            else
            {
                WriteLine("Coach: None");
            }
            for(int i=0; i < athletes.Length; i++)
            {
                if (athletes[i] != null)
                {
                    WriteLine("{0} {1} {2} (age: {3})", athletes[i].Position, athletes[i].FirstName, athletes[i].LastName, athletes[i].Age);
                }
                else
                {
                    break;
                }
                
            }
            
        }
        #endregion

        //2nd way sort rosters by last name
        //class SortRoster
        public class SortRoster : IComparer<Athlete>
        {
            public int Compare(Athlete athlete1, Athlete athlete2)
            {
                return athlete1.LastName.CompareTo(athlete2.LastName);
            }
        }

    }
}

