using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.Remoting.Messaging;

namespace To_Do_List
{
    internal class Program
    {
        public class Note
        {
            public string content { get; set; }
        }
        static void Main(string[] args)
        {
            string filePath = "data.json";
            List<Note> noteList = new List<Note>();
            while (true)
            {

                Console.WriteLine("Welcome to the list.");
                Console.WriteLine("Type 'read' to see the list. Type 'add' to add an entry to the list. Type 'remove' to remove an entry.");
                var input = Console.ReadLine();


                if (input == "read")
                {

                }
                else if (input == "add") //Am currently trying to figure out why the below code is not adding anything to the JSON no matter what I do. Chat GPT has no clue.
                {
                    Console.WriteLine("Type your note.");
                    string newNoteInput = Console.ReadLine();
                    Note newNote = new Note();
                    newNote.content = newNoteInput;
                    noteList.Add(newNote);
                    try
                    {
                        string updatedData = JsonConvert.SerializeObject(noteList, Formatting.Indented);
                        File.AppendAllText(filePath, updatedData);
                        Console.WriteLine($"{updatedData} added successfully.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error");
                    }
                }
            }
            //    {$

            //        foreach (var iteratingNote in noteList)
            //        {
            //            Console.WriteLine("hello");
            //        }
            //        //try
            //        //{

            //        //}
            //        //catch (Exception e)
            //        //{ 
            //        //    Console.WriteLine(e); 
            //        //}
            //    }
            //    else if (input == "add")
            //    {
            //        Console.WriteLine("Type your note.");
            //        string newNoteInput = Console.ReadLine();
            //        Note newLine = new Note();
            //        newLine.content = newNoteInput;
            //        noteList.Add(newLine);
            //        List<Note> serializedObject = noteList;
            //        File.WriteAllText(filePath, serializedObject + Environment.NewLine);


            //    } 

            //    else if (input == "stop")
            //    {
            //        break;
            //    }
            //}

        }
    }
}
