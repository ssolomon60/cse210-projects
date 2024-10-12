using System;

class Video
{
    public string title;
    public string author;
    public int length;
    public List<Comments> comments = new List<Comments>();
    public Video(string _title, string _author, int _length)
    {
        title = _title;
        author = _author;
        length = _length;
    }
    public List<Comments> GetComments()
    {
        return comments;
    }
    public void AddComments(Comments comment)
    {
        comments.Add(comment);
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
        CommentName =_CommentName;
        text = _text;
    }
}
class Program
{
    static void Main()
    {
        List<Video> videos = new List<Video>();
        Video video_1 = new Video("Minecraft Stories Part 1", "Cheesypie", 625);
        video_1.AddComments(new Comments("George", "What a wack video yo! How you going to let my character die like that"));

        videos.Add(video_1);
        foreach (Video video in videos) 
        {
            Console.WriteLine($"Title: {video.title}");
            Console.WriteLine($"Author: {video.author}");
            Console.WriteLine($"Length: {video.length} in seconds");
            Console.WriteLine($"Comment Count: {video.GetCommentCount()}");

            Console.WriteLine($"--Comments--");
            foreach (Comments comment in video.GetComments())
            {
                Console.WriteLine($"{comment.CommentName}: {comment.text}");
            }

        }
    }
}