using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Lab03People
{
    /// <summary>
    /// Person class
    /// contains their age and first/last name
    /// 
    /// You must implement CompareTo, Equals, and GetHashCode methods
    /// </summary>

    public class Person : IComparable<Person>, IEqualityComparer<Person>
    {
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        /// <summary>
        /// Compares this person to another based on last name then first name
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>

        public int CompareTo(Person person)
        {
            if (person == null)
                return -1;

            if (LastName.CompareTo(person.LastName) == 0) //if last name is same
              return FirstName.CompareTo(person.FirstName); //compare first name
            return LastName.CompareTo(person.LastName);
        }

        /// <summary>
        /// Determines if two Person objects are equal.
        /// Compare first names and last names.  -> how about age?
        /// </summary>
        /// <param name="personA"></param>
        /// <param name="personB"></param>
        /// <returns></returns>
        public bool Equals(Person personA, Person personB)
        {
            return (personA.FirstName == personB.FirstName &&
                personA.LastName == personB.LastName &&
                personA.Age == personB.Age); 
        }

        /// <summary>
        /// Gets a hash code for object based on first and last name.
        /// This gets called and is followed by Equals() if the
        /// hash codes are the same. So any consistent number
        /// will do.
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public int GetHashCode(Person person)
        {
            //xor the three hash code for first name, last name, and age
            //this is different from the hash code for the person object
            return person.FirstName.GetHashCode() ^ person.LastName.GetHashCode() ^ person.Age.GetHashCode(); //using XOR operator
        }

        // ToString() override to make it easy to display

        public override string ToString()
        {
            return $"Name: {FirstName} {LastName}, Age: {Age}";
        }
    }
}
