using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

 class Entry
{
    public string _date {get; set; }
    public string _prompt {get; set; }
    public string _input {get; set;}
    public Entry (string date, string prompt, string input)
    {
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
    }
    public string GetRandomPrompt()
    {
        Random rand = new Random();
        int index = rand.Next(aPrompts.Count);  // Get a random index
        return aPrompts[index];  // Return the prompt at that index
    }
}
class Journal
    {
        private List<Entry> entries = new List<Entry>();
        public void AddEntry(string prompt, string input)
        {
            string DateNow = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            Entry  newEntry = new Entry(prompt, input, DateNow);
            entries.Add(newEntry);
            Console.WriteLine("Entry was Added");
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
        

    }



}