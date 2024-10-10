using System;
using System.Collections.Concurrent;
using System.Diagnostics.Contracts;

class Word
{
    private string _text;
    private bool _isHide;
    public Word(string text)
    {
        _text = text;
        _isHide = false;
    }
    public void Hide()
    {
        _isHide = true;
    }
    public bool IsHidden()
    {
        return _isHide;
    }
    public string GetDisplayText()
    {
       return _isHide ? "_____": _text;
    }
}
public class Scripture
{
    private List<Word> _words;
    public string Reference { get; }
    public Scripture(string reference, string text)
    {
        Reference = reference;
        _words = CreateWordsFromText(text);
    }
    
    private List<Word> CreateWordsFromText(string text)
    {
        return text.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)

                   .Select(CreateWord).ToList();
    }
    private Word CreateWord(string word)
    {
        return new Word(word);
    }
    public void HideRandomWords(int count)
    {
        Random random = new Random();
         var hiddenWords = _words.Where(w => !w.IsHidden())
                                    .OrderBy(w => random.Next())
                                    .Take(count);
          
    foreach (var word in hiddenWords)
    {
        word.Hide();
    }
    }
    public string GetDisplayText()
    {
        return $"{Reference}: {string.Join(" ", _words.Select(w => w.GetDisplayText()))}";
    }
}
public class Program 
{
 public static void Main(string[] args)
 {
   Scripture scripture = new Scripture("1 Nephi 2:15", "And my father dwelt in a tent");
   Console.WriteLine(scripture.GetDisplayText());
   while (true)
   {
    Console.WriteLine("\nPress Enter to continue or type quit to end");
    var input = Console.ReadLine();
    if (input?.ToLower() == "quit")
    {
        break;
    }
    scripture.HideRandomWords(1);
    Console.WriteLine(scripture.GetDisplayText());
   }
 }
}