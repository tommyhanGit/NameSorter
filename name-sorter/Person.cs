using System;

namespace name_sorter
{
    //Person class which contains a String FirstNames and a string LastNames
    public class Person
    {
        public Person()
        {
            FirstNames = "";
            LastName = "";
        }

        public string FirstNames {get; set;}
        public string LastName {get; set;}

        // Returns full name in a "FirstName Lastname" format
        public string GetFullNameString()
        {
            return FirstNames + " " + LastName;
        }

        public override bool Equals(Object obj)
        {
            Person person = obj as Person;
            if (person == null)
            {
                return false;
            }
            if (person.FirstNames == this.FirstNames && person.LastName == this.LastName)
            {
                return true;
            }
            return false;
        }        

        public override int GetHashCode()
        {
            return this.GetFullNameString().GetHashCode();
        }
    }
}
