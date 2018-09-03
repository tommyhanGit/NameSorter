using System;
using System.Collections.Generic;
using System.Linq;

namespace name_sorter
{
    public interface INameSorter
    {
        IEnumerable<Person> SortedNamesList(IEnumerable<Person> unsortedNamesList);
    }
}
