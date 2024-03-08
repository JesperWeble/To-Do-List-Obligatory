using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.Remoting.Messaging;
using static To_Do_List.Program;

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
            string deserializedData = File.ReadAllText(filePath);
            
            try
            {
                var fullList = JsonSerializer.Deserialize<IList<Note>>(deserializedData);
                foreach (var note in fullList)
                {
                    noteList.Add(note);
                }
            }
            catch
            {
            }
            Console.WriteLine("Type 'read' to see the list. \nType 'add' to add an entry to the list. \nType 'remove' to remove an entry. \n---Input Below---");
            while (true)
            {
                var input = Console.ReadLine();


                if (input == "read")
                {
                    Console.WriteLine("---Reading---");
                    var entryNumber = 0;
                    foreach (var note in noteList)
                    {   
                        Console.WriteLine($"{entryNumber}: {note.content}");
                        entryNumber += 1;
                    }
                    Console.WriteLine("------------");

                }

                else if (input == "add")
                {
                    Console.WriteLine("---Type your note---");
                    string newNoteInput = Console.ReadLine();

                    if (newNoteInput == "cancel") 
                    {}

                    else
                    { 
                        Note newNote = new Note
                        {
                            content = newNoteInput
                        };
                        noteList.Add(newNote);
                        string jsonString = JsonSerializer.Serialize(noteList);
                        File.WriteAllText(filePath, jsonString);
                        Console.WriteLine($"Note: '{newNoteInput}' added successfully.");
                    }
                }

                else if (input == "remove")
                {
                    Console.WriteLine("---Type the entry number to remove---");
                    string removeNoteInput = Console.ReadLine();

                    if (removeNoteInput == "cancel") 
                    { }
                    
                    
                    else if (removeNoteInput == "all")
                    {
                        noteList.Clear();
                        File.WriteAllText(filePath, "");
                        Console.WriteLine($"All notes removed");
                    }

                    else
                    {
                        try
                        { 
                            int removedIndex = int.Parse(removeNoteInput);
                            noteList.RemoveAt(removedIndex);
                            string jsonString = JsonSerializer.Serialize(noteList);
                            File.WriteAllText(filePath, jsonString);
                            Console.WriteLine($"Note: '{removedIndex}' was removed successfully.");
                        }
                        catch
                        {
                            Console.WriteLine("Invalid entry...\n");
                        }
                        
                    }
                }

                else if (input == "help")
                {
                    Console.WriteLine("Type 'read' to see the list. \nType 'add' to add an entry to the list. \nType 'remove' to remove an entry. \n---Input Below---");
                }

                else if (input == "stop" || input == "Stop" || input == "exit" || input == "Exit")
                {
                    break;
                }

                else
                {
                    Console.WriteLine("Invalid command...\n");
                }
                Console.WriteLine("");
            }
        }
    }
}
