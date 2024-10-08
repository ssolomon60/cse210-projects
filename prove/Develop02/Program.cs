using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.IO;

 class Entry
{
    public string _date {get; set; }
    public string _prompt {get; set; }
    public string _input {get; set;}
    public Entry (string date, string prompt, string input)
    {
        Console.WriteLine("Hello Develop02 World!");
        _date = date; 
        _prompt = prompt;
        _input = input;
    }
    
    public void DisplayEntry ()
    {
        Console.WriteLine($"{_date} - {_prompt}");
        Console.WriteLine($"{_input}");
    }
}
class PromptGenerator
{
    private List<string> aPrompts;
    private Random rand;
    public PromptGenerator()
    {
        aPrompts = new List<string>
        {
            "What was the highlight of your day?",
            "Who made an impact on you today?",
            "What challenge did you overcome?",
            "What did you learn today?", 
            "What are you grateful for today?"
        };
        rand = new Random();
    }
    public string GetRandomPrompt()
    {
        int index = rand.Next(aPrompts.Count); 
        return aPrompts[index];  
    }
}
class Journal
    {
        private List<Entry> entries = new List<Entry>();
        public void AddEntry(string prompt, string input)
        {
            string DateNow = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            Entry  newEntry = new Entry(DateNow, prompt, input);
            entries.Add(newEntry);
            Console.WriteLine("Entry was Added");
        }
        public void DisplayJournal()
        {
            foreach (Entry entry in entries)
            {
                entry.DisplayEntry();
                Console.WriteLine("-");
            }
        }
        public void SaveJournal(string filename)
        {
             using (StreamWriter writer = new StreamWriter(filename))
            {
                 foreach (Entry entry in entries)
                {
                     writer.WriteLine($"{entry._prompt}|{entry._input}|{entry._date}");
                 }
            }
        Console.WriteLine("Journal saved successfully.");
    }
    
    }
class JournalProgram
{
    public static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        bool running = true;
        while (running)
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display Journal");
            Console.WriteLine("3. Save Journal to a file");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");
            String choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                string randomPrompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine(randomPrompt);
                string _input = Console.ReadLine();
                journal.AddEntry(randomPrompt, _input);
                break;

                case "2":
                    journal.DisplayJournal();
                    break;
                case "3":
                    Console.Write("Enter filename to save journal: ");
                    string saveFilename = Console.ReadLine();
                    journal.SaveJournal(saveFilename);
                    break;
                case "4":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid Choice. Please select a valid option");
                    break;

            }
        }

    }
}
