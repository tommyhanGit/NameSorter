using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using name_sorter;

namespace name_sorter_tester
{
    [TestClass]
    public class NameSorterTester
    {
        [TestMethod]
        public void TestAscending()
        {
            INameSorter nameSorter; 
            List<Person> unsortedNamesList = new List<Person>();
            List<Person> sortedNamesList = new List<Person>();
            List<Person> expectedNamesList = new List<Person>();

            unsortedNamesList.Add(new Person {FirstNames = "Beau Tristan", LastName = "Bentley"});
            unsortedNamesList.Add(new Person {FirstNames = "Marin", LastName = "Alvarez"});
            unsortedNamesList.Add(new Person {FirstNames = "Frankie Conner", LastName = "Ritter"});

            expectedNamesList.Add(new Person {FirstNames = "Marin", LastName = "Alvarez"});
            expectedNamesList.Add(new Person {FirstNames = "Beau Tristan", LastName = "Bentley"});
            expectedNamesList.Add(new Person {FirstNames = "Frankie Conner", LastName = "Ritter"});

            nameSorter = new AscendingLastnameSorter();
            sortedNamesList = nameSorter.SortedNamesList(unsortedNamesList).ToList();

            CollectionAssert.AreEqual(expectedNamesList, sortedNamesList, "The SortByLastName function should be sorted by last name and then first name.");
        }

        public void TestDescending()
        {
            INameSorter nameSorter; 
            List<Person> unsortedNamesList = new List<Person>();
            List<Person> sortedNamesList = new List<Person>();
            List<Person> expectedNamesList = new List<Person>();

            unsortedNamesList.Add(new Person {FirstNames = "Beau Tristan", LastName = "Bentley"});
            unsortedNamesList.Add(new Person {FirstNames = "Marin", LastName = "Alvarez"});
            unsortedNamesList.Add(new Person {FirstNames = "Frankie Conner", LastName = "Ritter"});

            expectedNamesList.Add(new Person {FirstNames = "Frankie Conner", LastName = "Ritter"});
            expectedNamesList.Add(new Person {FirstNames = "Beau Tristan", LastName = "Bentley"});
            expectedNamesList.Add(new Person {FirstNames = "Marin", LastName = "Alvarez"});

            nameSorter = new DescendingLastnameSorter();
            sortedNamesList = nameSorter.SortedNamesList(unsortedNamesList).ToList();

            CollectionAssert.AreEqual(expectedNamesList, sortedNamesList, "The SortByLastName function should be sorted by last name and then first name.");
        }

        [TestMethod]
        public void TestFirstNames()
        {
            Person person = new Person {FirstNames = "Beau Tristan", LastName = "Bentley"};
            Assert.AreEqual("Beau Tristan", person.FirstNames, "First name(s) hasn't been assigned correctly");
        }

        [TestMethod]
        public void TestLastName()
        {
            Person person = new Person {FirstNames = "Beau Tristan", LastName = "Bentley"};
            Assert.AreEqual("Bentley", person.LastName, "Last name hasn't been assigned correctly");
        }        

        [TestMethod]
        public void TestFullName()
        {
            Person person = new Person {FirstNames = "Beau Tristan", LastName = "Bentley"};
            Assert.AreEqual("Beau Tristan Bentley", person.GetFullNameString(), "Full name hasn't been formatted correctly");
        }        

    }
}
