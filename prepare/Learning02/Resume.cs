using System.ComponentModel;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using Microsoft.VisualBasic;

namespace Paperwork
{
        class Entry
        {

            public string Prompt {get; private set;}
            public string User_Input {get; private set;}
            public string Date;
            public Entry(string aPrompt, string aUser_Input)
            {
                Prompt = aPrompt;
                User_Input = aUser_Input;
                Date = DateTime.Now.ToString("yyyy-MM-dd");

            }
            public void DisplayEntry()
            {
                Console.WriteLine($"{Date}");
                Console.WriteLine($"Question: {Prompt}");
                Console.WriteLine($"{User_Input}");
            }
    class Journal
    {
        private List<Entry> entries;
        private List<string> questions;

        public Journal()
        {
            entries = new List<Entry>();
            questions = new List<string>
            {
                "Who was the most interesting person I interacted with today?",
                "What was the best part of my day?",
                "How did I see the Hand of the Lord in my today?",
                "What was the strongest emotion I felt today?",
                "If I had one thing I could do over today, what would it be?"
            };
        }
        public void AddEntry()
        {
            Random random = new Random();
            string prompt = questions[random.Next(questions.Count)];
            Console.WriteLine(prompt);
            string aUser_Input = Console.ReadLine();
            entries.Add(new Entry (prompt, aUser_Input));
            Console.WriteLine("Entry Added.");
        }
    }
        
    }

    
}