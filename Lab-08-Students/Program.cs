using System;
using System.Collections.Generic;

namespace Lab_08_Students
{
    class Program
    {
        public static List<string> names = new List<string>() { "Steven Vallarsa", "Brad Kapteyn", "Lisa Rizzo", "Nathan Jefferis", "Miguel Gomez", "Callista Gloss", "Andre Otte", "Tommy Waalkes" };
        public static List<string> towns = new List<string>() { "Sudbury, ON", "Kentwood, MI", "Sokcho, South Korea", "Grand Rapids, MI", "Chicago, IL", "Traverse City, MI", "St Catherines, ON", "Raleigh, NC" };
        public static List<string> foods = new List<string>() { "Risotto", "Sushi", "Fruit", "Burgers", "BBQ Ribs", "Crab Rangoons", "Veggie Burgers", "Chicken Curry" };


        // Main Method
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to our C# class. Which student would you like to learn more about?");
            PrintMenu();

            GetInput();

        }


         
        public static void GetInput()
        {
            Console.Write("Please select 1 to " + names.Count + ": ");
            int index = 0;

            bool keepLooping = true;

            while (keepLooping)
            {

                string input = Console.ReadLine();
                string returnString;

                try
                {
                    index = int.Parse(input);
                    returnString = GetStudent(index - 1);
                    keepLooping = false;
                }
                catch (FormatException)
                {
                    Console.Write("That's not a number. Please try again: ");
                }
                catch (Exception e)
                {
                    Console.Write(e.Message);
                }

            }
            Console.WriteLine($"\nStudent {index} is {names[index - 1]}.");
            LearnMore(index);

        }



        // method that returns string of student name, hometown, and favorite food depending on index selected in GetInput method
        public static string GetStudent(int index)
        {

            string studentInfo;
            try
            {
                if (index < 0 || index >= names.Count)
                {
                    throw new IndexOutOfRangeException("Student not found. Try another index.");
                }
                // added "*" to separate name and town, and "^" to separate town and food
                studentInfo = names[index] + "*" + towns[index] + "^" + foods[index];
            }
            catch (IndexOutOfRangeException e)
            {
                return e.Message;
            }

            return studentInfo;
        }



        // method to add Name, Hometown and Favorite Food to appropriate lists 
        public static void AddStudent(string name, string town, string food)
        {
            names.Add(name);
            towns.Add(town);
            foods.Add(food);
        }



        // method that prints the index and names of the students
        public static void PrintMenu()
        {
            for (int i = 0; i < names.Count; i++)
            {
                // the printed index starts at 1 and not 0 as the list index,
                // so the writen index is listed + 1
                Console.WriteLine((i+1) + ") " + names[i].Substring(0, names[i].IndexOf(' ')));
            }
        }



        public static void LearnMore(int index)
        {
            Console.Write($"\nWould you like to know about {names[index - 1].Substring(0, names[index - 1].IndexOf(' '))}? Enter \"hometown\" or \"favorite food\": ");
            string knowMore = Console.ReadLine().ToLower();

            try
            {
                if (knowMore == "hometown")
                {
                    Console.WriteLine($"{names[index - 1].Substring(0, names[index - 1].IndexOf(' '))} is from {towns[index - 1]}.");
                }
                else if (knowMore == "favorite food")
                {
                    Console.WriteLine($"{names[index - 1].Substring(0, names[index - 1].IndexOf(' '))}'s favorite food is {foods[index - 1]}.");
                }
                else
                {
                    throw new Exception("Invalid Input");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.Write("Would you like to know more? (yes/no) ");



            //Console.WriteLine("That data does not exist. Please try again. (enter \"hometown\" or \"favorite food\"");

        }



    }
}
