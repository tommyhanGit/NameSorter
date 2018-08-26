using System;
using System.Collections.Generic;
using System.Linq;

namespace name_sorter
{
    //Contain functions to sort names
    public class NameSorter
    {
        //Sort an unsorted names list alphabetically based on LastNames and then FirstNames 
        //Return to the Enumerable sorted names list
        public List<Person> SortByLastName(List<Person> unsortedNamesList)
        {
            IEnumerable<Person> sortedNamesList =
                from Person in unsortedNamesList
                orderby Person.LastName, Person.FirstNames
                select Person;

            return sortedNamesList.ToList();
        }
    }
}
