using System;
using System.Collections.Generic;

namespace name_sorter
{
    class Program
    {
        static void Main(string[] args)
        {
            //Check if an argument has been entered.
            if(args.Length == 1)
            {
                //Initialise and Set filpaths
                FileIOHelper file = new FileIOHelper();
                NameSorter nameSorter = new NameSorter();

                List<Person> sortedNamesList = new List<Person>();
                List<Person> unsortedNamesList = new List<Person>();

                String readPath = args[0];
                String writePath = "sorted-names-list.txt";
                
                //Check if a file does exist
                if(file.FileExists(readPath))
                {
                    //Read names list from a file
                    String[] persons = file.ReadLinesFromFile(readPath);
                    if(persons.Length > 0)
                    {
                        try
                        {
                            //Process the readed names to the Person class
                            unsortedNamesList = ConvertToListOfPerson(persons);

                            //Sort names by a last name firstly and then first names.
                            sortedNamesList = nameSorter.SortByLastName(unsortedNamesList);                            

                            //Print to the screen
                            PrintPersonFromList(sortedNamesList);

                            //Write sorted names list to file
                            file.WriteLinesToFile(writePath, ConvertToArray(sortedNamesList));
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine("Failed to process sorting.");
                            Console.WriteLine("Error Message");
                            Console.WriteLine("----------------------");
                            Console.WriteLine(ex.Message);
                        }
                    }
                    else
                    {
                        Console.WriteLine("The file doesn't have a data");
                    }
                }
                else
                {
                    Console.WriteLine("The file path is not valid.");
                    PrintUsuage();
                }                
            }
            else
            {
                PrintUsuage();
            }
        }

        //Display an way how to use this program
        private static void PrintUsuage()
        {
            Console.WriteLine("Usage: name_sort [file-path-to-read]");
            Console.WriteLine("");
            Console.WriteLine("file-path-to-read");
            Console.WriteLine("The path to a file to read");            
        }

        //Display person list on the screen in a "FirstNames Lastname" format
        private static void PrintPersonFromList(List<Person> persons)
        {
            foreach (Person person in persons)
            {
                Console.WriteLine(person.GetFullNameString());
            }   
        }

        //Convert names list of Persons to array in the "FirstName Lastname" format
        //and then return it. 
        private static String[] ConvertToArray(List<Person> persons)
        {
            String[] namesArray = new String[persons.Count];

            for(int personIndex = 0; personIndex < persons.Count; personIndex++)
            {
                namesArray[personIndex] = persons[personIndex].GetFullNameString();
            }

            return namesArray;
        }

        //Process full name strings to a List<Person>.
        //Iterate over the array Names and then covert to a Person object
        //Add it to the List
        private static List<Person> ConvertToListOfPerson(String[] persons)
        {
            List<Person> namesList = new List<Person>();

            foreach(String person in persons)
            {
                Person convertedPerson = ConvertToPerson(person, " ");
                if(convertedPerson != null)
                {
                    namesList.Add(convertedPerson);
                }
                else
                {
                    return null;
                }
            }

            return namesList;
        }
        
        //Splitting strings based on the last index of the input delimiter.
        //Creates a new Person Object and return it
        private static Person ConvertToPerson(String Names, String delimiter)
        {
            int lastIndex = Names.LastIndexOf(delimiter);

            if( lastIndex > 0 )
            {
                Person person = new Person();
                person.FirstNames = Names.Substring(0, lastIndex);
                person.LastName = Names.Substring(lastIndex + 1);

                return person;
            }

            return null;
        }
    }
}
