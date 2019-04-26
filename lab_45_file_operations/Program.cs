using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab_45_file_operations
{
    class Program
    {
        static void Main(string[] args)
        {
            if(!File.Exists("file.txt"))
            {
                File.WriteAllText("file.txt", "Some data");
            }

            // Read 1 line of text as a string
            string data = File.ReadAllText("file.txt");
            Console.WriteLine(data);

            // Write data
            Console.WriteLine("Writing new text...");
            File.WriteAllText("file.txt", "here is some new data", new UTF8Encoding(false));

            Console.WriteLine("\n\nReading text back again:");
            data = File.ReadAllText("file.txt");
            Console.WriteLine(data);

            File.AppendAllText("file.txt", Environment.NewLine + "some data");

            //using (StreamWriter sw = File.AppendText("file.txt"))
            //{
            //    sw.WriteLine("\nand some more data 1");
            //    sw.WriteLine("and some more data 2");
            //    sw.WriteLine("and some more data 3");
            //    sw.WriteLine("and some more data 4");
            //}

            // append : adds at end
            File.AppendAllText("file.txt", Environment.NewLine + Environment.NewLine + DateTime.Now.ToString() + " and here is some more data 1");
            File.AppendAllText("file.txt", Environment.NewLine + DateTime.Now.ToString() + " and here is some more data 2");
            File.AppendAllText("file.txt", Environment.NewLine + DateTime.Now.ToString() + " searchterm22");
            File.AppendAllText("file.txt", Environment.NewLine + DateTime.Now.ToString() + " and here is some more data 4");
            File.AppendAllText("file.txt", Environment.NewLine + DateTime.Now.ToString() + " and here is some more data 5");
            data = File.ReadAllText("file.txt");
            Console.WriteLine(data);

            // data logging : used all the time - add a DateTime.Now
            Console.WriteLine("\n\nLogging with DateTime Stamp");
            File.AppendAllText("file.txt", Environment.NewLine + DateTime.Now.ToString());
            data = File.ReadAllText("file.txt");
            Console.WriteLine(data);

            // reading multiple lines to an array
            Console.WriteLine("\n\nSearching text file for a term...");
            string[] dataArray = File.ReadAllLines("file.txt");
            foreach(string item in dataArray)
            {
                if(item == "searchterm22")
                {
                    Console.WriteLine("Bingo ! searchterm22 has been found!!!");
                }
            }
            for(int i = 0; i < dataArray.Length; i++)
            {
                if(dataArray[i] == "searchterm22")
                {
                    Console.WriteLine($"(Found on line {i})");
                }
            }

            // File.Copy    (true means yes overwrite if exists already)
            File.Copy("file.txt", "filecopy.txt", true);
            File.Delete("file.txt");

            // In 1 line
            File.Move("filecopy.txt", "file.txt");

            Console.WriteLine(File.GetCreationTime("file.txt"));
            Console.WriteLine(File.GetLastWriteTime("file.txt"));

            // folders
            // create folder
            Directory.CreateDirectory("Parent");
            Directory.CreateDirectory("Parent\\Child1");
            Directory.CreateDirectory("Parent\\Child2");
            Directory.CreateDirectory("Parent\\Child3");
            File.WriteAllText("Parent\\Child3\\file.txt", "hello");
            File.WriteAllText("Parent\\Child2\\file.txt", "hello");
            File.WriteAllText("Parent/Child1/file.txt", "hello");

            // delete one
            Directory.Delete("Parent/Child2", true);

            // create in C:\ drive
            //Directory.CreateDirectory("/Test2");

            // Path to my documents folder
            var pathMyDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // create in MyDocuments
            Directory.CreateDirectory(pathMyDocuments + "/Test");

            // list all files in folder and see if one file exists
            // lab : create a folder in My Documents
            var FileList = Directory.EnumerateFiles(pathMyDocuments + "\\Temp");
            {
                var BobIsThere = false;
                foreach (var item in FileList)
                {
                    if(item == pathMyDocuments + "\\Temp\\BobsFile.txt")
                    {
                        BobIsThere = true;
                    }
                }
                Console.WriteLine(BobIsThere ? "Bob is there" : "Bob is not there");
            }
            
        }
    }
}
