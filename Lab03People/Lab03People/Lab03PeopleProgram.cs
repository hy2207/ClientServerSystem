using System;
using System.Collections.Generic;
using System.Linq;
using static Lab03People.Utilities;

namespace Lab03People
{
    class Lab03PeopleProgram
    {
        static void Main(string[] args)
        {
            Person[] people = new Person[]
            {
                new Person {FirstName= "Homer", LastName="Simpson", Age=47},
                new Person {FirstName= "Marge", LastName="Simpson", Age=45},
                new Person {FirstName= "Lisa", LastName="Simpson", Age=9},
                new Person {FirstName= "Bart", LastName="Simpson", Age=8},
                new Person {FirstName= "Maggie", LastName="Simpson", Age=2},
                new Person {FirstName= "Ned", LastName="Flanders", Age=42},
                new Person {FirstName= "Maude", LastName="Flanders", Age=40},
                new Person {FirstName= "Rod", LastName="Flanders", Age=12},
                new Person {FirstName= "Todd", LastName="Flanders", Age=13}
            };

            // TASK: display the list using your generic Display method

            Display("Initial array", people);

            // TASK: create a list from the array and display it
            List<Person> peopleList = new List<Person>();
            peopleList.AddRange(people); //add people using Addrange

            Display("List created from Array", peopleList);

            // TASK: sort the list using the default comparer (last name then first name) and display it
            peopleList.Sort(); //using compare function

            Display("List Sorted by Last Name then First name using default comparer", peopleList);

            // TASK: shuffle the list (NOT THE ARRAY) and display it 

            //based on the Fisher-Yates Shuffle
            Random rand = new Random();
            int n = peopleList.Count; //get number of list
            while (n > 1)
            {
                n--;
                int k = rand.Next(n + 1); //get random number
                //and shuffle it
                Person tmp = peopleList[k];
                peopleList[k] = peopleList[n];
                peopleList[n] = tmp;
            }
            /* another way to shuffle people list
             * using linq
             * peopleList = peopleList.OrderBy(p => rand.Next()).ToList();
            for (int i = 0; i < peopleList.Count(); i++)
            {
                int n = rand.Next(i, peopleList.Count());
                Person tmp = peopleList[i];
                peopleList[i] = peopleList[n];
                peopleList[n] = tmp;
            } 
            */

            Display("Randomized list (not the array)", peopleList);

            // TASK: sort the randomized list by first name and display
            peopleList.Sort(new SortPeopleByFirstName()); //sort list using compare function

            Display("Randomized list now sorted by First Name", peopleList);

            // TASK: remove the 2nd element of the sorted list and display
            peopleList.RemoveAt(1); //index 1 = 2nd element
            Display("Sorted list with 2nd element (Homer) removed", peopleList);

            // TASK: create a stack and push each element from the sorted list 
            //       with Homer missing onto the stack
            Stack<Person> peopleStack = new Stack<Person>(); //create stack
            for (int idx = 0; idx < peopleList.Count; idx++) //push each element
            {
                peopleStack.Push(peopleList[idx]);
            }
            // TASK: display the stack
            Display("Stack from sorted list above with Homer removed", peopleStack);

            // TASK: reverse the top two elements.
            // pop the top and save, then pop the next one and save
            // then push the top and next - reverses the elements
            // finally display the stack
            Person person1 = peopleStack.Pop();
            Person person2 = peopleStack.Pop();
            peopleStack.Push(person1);
            peopleStack.Push(person2);

            Display("Stack with top 2 flipped", peopleStack);

            // TASK: sort the list by age and display
            peopleList.Sort(new SortPeopleByAge());

            //Display("Sorted list by age", peopleList); //in output.txt, there is no display of this.

            // TASK: create a queue and add the sorted list to the queue and display
            Queue<Person> peopleQueue = new Queue<Person>(); //create a queue
            for (int idx = 0; idx < peopleList.Count; idx++) //add each element
            {
                peopleQueue.Enqueue(peopleList[idx]);
            }
            Display("Queue from sorted list by age with Homer removed", peopleQueue);

            // TASK: add more elements to the end of the queue and display
            peopleQueue.Enqueue(new Person { FirstName = "Grandma", LastName = "Simpson", Age = 95 });
            peopleQueue.Enqueue(new Person { FirstName = "Grandpa", LastName = "Simpson", Age = 100 });
            peopleQueue.Enqueue(new Person { FirstName = "Grandma", LastName = "Flanders", Age = 90 });
            peopleQueue.Enqueue(new Person { FirstName = "Grandpa", LastName = " Flanders ", Age = 89 });

            Display("Age sorted Queue with Grandmas and Grandpas at end", peopleQueue);

            // TASK: dequeue each element and show that they left and the resulting queue size
            Console.WriteLine("== DeQueue each element and display, queue size = " + peopleQueue.Count);
            int queueSize = peopleQueue.Count; //queue size
            for (int idx = 0; idx < queueSize; idx++)
            {
                Person dequeuePerson = peopleQueue.Dequeue();
                Console.WriteLine("  " + dequeuePerson.ToString() + " left the queue, queue size = "+peopleQueue.Count);
            }

            // TASK: Dequeue() again (on an empty queue) causing an exception
            //       Catch the exception and produce an error message
            try
            {
                peopleQueue.Dequeue();
            }catch(Exception e)
            {
                Console.WriteLine("  Dequeue() on an empty queue");
                Console.WriteLine("  Cannot Dequeue(): {0}", e.Message); //produce an error message
            }

            // TASK: create a dictionary with 5 entries consisting of phone number and a person and display
            Dictionary<int, Person> peopleDictionary = new Dictionary<int, Person>();
            peopleDictionary.Add(555, people[0]); //add 5 elemnts of the people array
            peopleDictionary.Add(452, people[1]);
            peopleDictionary.Add(253, people[2]);
            peopleDictionary.Add(157, people[3]);
            peopleDictionary.Add(855, people[4]);

            DisplayDictionary("Phone book", peopleDictionary);

            // TASK: look up phone number 157 and display result
            Person lookupPerson = peopleDictionary[157];
            Console.WriteLine("  Looking up 157: " + lookupPerson.ToString());

            // TASK: create a sorted dictionary with 5 entries consisting of phone number and a person and display
            SortedDictionary<int, Person> sortedPeopleDictionary = new SortedDictionary<int, Person>(peopleDictionary);

            DisplayDictionary("Sorted Phone book", sortedPeopleDictionary);

            // TASK: create a HashSet containing all of the people in the original array
            HashSet<Person> peopleHashSet = new HashSet<Person>(new Person());
            foreach (Person person in people) //add one more
            {
                peopleHashSet.Add(person);
            }
            // TASK: add the the SAME array of people to the HashSet, and display the HashSet
            foreach (Person person in people) //add one more
            {
                peopleHashSet.Add(person);
            }

            Display("HashSet with array added twice, but should show no duplicates", peopleHashSet);

            // TASK: look up Lisa Simpson in the HashSet
            //Person lisa = new Person { FirstName = "Lisa", LastName = "Simpson", Age = 9 }; 
            //Console.WriteLine("  Looking up Name: "+ lisa.ToString()+ ": found = "+ peopleHashSet.Contains(lisa));
            Console.WriteLine("  Looking up Name: "+ people[2]+ ": found = "+ peopleHashSet.Contains(people[2]));
            
            // but the result of Contains is false. why is the result diffrent?

            Console.ReadLine();
        }
    }
}
