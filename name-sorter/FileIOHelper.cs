using System;
using System.IO;

namespace name_sorter
{
    //Contain functions to handle Files
    class FileIOHelper
    {
        public bool FileExists(String FilePath)
        {
            return File.Exists(FilePath);
        }

        //Read newline delimited lines from a file
        //and adding them into a collection
        public String[] ReadLinesFromFile(String FilePath)
        {
            try
            {
                String[] lines = File.ReadAllLines(FilePath);
                return lines;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to read a file.");
                Console.WriteLine("Error Message");
                Console.WriteLine("----------------------");
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        //Write contents in a collection each on a new line to a file
        public void WriteLinesToFile(String FilePath, String[] lines)
        {
            try
            {            
                File.WriteAllLines(FilePath, lines);            
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to write a file.");
                Console.WriteLine("Error Message");
                Console.WriteLine("----------------------");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
