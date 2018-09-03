using System;
using System.Collections.Generic;
using System.Linq;

namespace name_sorter
{
    //Contain functions to sort names ascending
    public class AscendingLastnameSorter  : INameSorter
    {
        //Sort an unsorted names list alphabetically based on LastNames and then FirstNames 
        //Return to the Enumerable sorted names list
        public IEnumerable<Person> SortedNamesList(IEnumerable<Person> unsortedNamesList)
        {
            IEnumerable<Person> sortedNamesList =
                from Person in unsortedNamesList
                orderby Person.LastName, Person.FirstNames
                select Person;

            return sortedNamesList;
        }
    } 
}
