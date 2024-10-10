using System;

class video
{
    public string title;
    public string author;
    public int length;
    public List<Comments> comments = new List<Comments>();
    public video(string _title, string _author, int _length, int _comments)
    {
        _title = title;
        _author = author;
        _length = length;
    }
    public void GetComments()
    {
        return comments;
    }
    public int GetCommentCount()
    {
        return comments.Count;
    }
}
class Comments
{
    public string CommentName;
    public string text;
    public Comments(string _CommentName, string _text)
    {
        _CommentName = CommentName;
        _text = text;
    }
}
class Program
{
    static void Main()
    {
        List<video> videos = new List<video>();
        foreach (video video in videos) 
        {
            Console.WriteLine($"Title: {video.title}");
            Console.WriteLine($"Author: {video.author}");
            Console.WriteLine($"Length: {video.length}");
            Console.WriteLine($"Comment Count: {video.GetCommentCount()}")

            Console.WriteLine($"Comments:")
            foreach (Comments comments in comments)
            {
                Console.WriteLine($"{CommentName}: {text}")
            }

        }
    }
}