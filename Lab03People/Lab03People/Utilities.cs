using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab03People
{
    /// <summary>
    /// Contains Display methods for collections and dictionaries
    /// </summary>
    public static class Utilities
    {
        /// <summary>
        /// Display a collection with a header message 
        /// 
        /// This is readonly because stack/queue do not permit remove.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message">Header message</param>
        /// <param name="collection"></param>
        public static void Display<T>(string message, IReadOnlyCollection<T> collection)
        {
            Console.Write("===== ");
            Console.WriteLine(message);
            foreach (T entry in collection)
            {
                Console.WriteLine("  " + entry);
            }
        }

        /// <summary>
        /// Display a dictionary with a header message. Uses KeyValuePair to iterate
        /// </summary>
        /// <typeparam name="K">Key type</typeparam>
        /// <typeparam name="V">Value type</typeparam>
        /// <param name="message">Header message</param>
        /// <param name="dictionary"></param>
        public static void DisplayDictionary<K, V>(string message, IDictionary<K, V> dictionary)
        {
            Console.Write("===== ");
            Console.WriteLine(message);
            foreach(KeyValuePair<K, V> entry in dictionary)
            {
                Console.WriteLine("  Key: " + entry.Key + " Value: " + entry.Value);
            }

        }
    }
    // Sort classes

    public class SortPeopleByFirstName : IComparer<Person>
    {
        public int Compare(Person personA, Person personB)
        {
            return personA.FirstName.CompareTo(personB.FirstName); //compare firstname
        }
    }

    public class SortPeopleByAge : IComparer<Person>
    {
        public int Compare(Person personA, Person personB)
        {
            return personA.Age.CompareTo(personB.Age); //compare age
            //return personA.Age - personB.Age;
        }
    }
}
