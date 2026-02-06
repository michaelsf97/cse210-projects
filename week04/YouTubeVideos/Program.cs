using System;
using System.Transactions;

public class Video
{
    public string Title {get; set;}
    public string Author {get; set;}
    public float LengthSeconds {get; set;}

    private List<Comment> Comments {get; set;}

    public Video(string title, string author, float lengthseconds)
    {
        Title = title;
        Author = author;
        LengthSeconds = lengthseconds;
        Comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return Comments.Count;
    }

    public List<Comment> GetComments()
    {
        return Comments;
    }
}    
    public class Comment
    {
        public string CommenterName {get; set;}
        public string Text {get; set;}
        public Comment(string commenterName, string text)
        {
            CommenterName = commenterName;
            Text = text;
        }
    }    

    class Program
    {
        static void Main(string[] args)
    {
        // Create videos 

        var videos = new List<Video>();
        var video1 = new Video("How to learn C#", "Nephi", 600);
        video1.AddComment(new Comment("Lehi", "Great video, thanks for your perseverance!"));
        video1.AddComment(new Comment("Sariah", "Very helpful, I learned a lot."));
        video1.AddComment(new Comment("HolyGhost", "Can not wait to try this out!"));
        videos.Add(video1);

        var video2 = new Video("Eternal Families", "Elder Held", 250);
        video2.AddComment(new Comment("Ammon", "Inspiring message about families."));
        video2.AddComment(new Comment("King Benjamin", "Emotional and useful."));
        video2.AddComment(new Comment("HolyGhost", "I felt the spirit strongly."));
        videos.Add(video2);

        var video3 = new Video("Gospel Restoration", "Elder Bednard", 300);
        video3.AddComment(new Comment("Holy Ghost", "Powerful testimony of the restoration."));
        video3.AddComment(new Comment("Joseph Smith", "I am grateful for those teachings."));
        video3.AddComment(new Comment("Elder Eyring", "Wonderful insights."));
        videos.Add(video3);

        var video4 = new Video("Service to the Lord", "Elder Cook", 450);
        video4.AddComment(new Comment("Alma", "Motivating talk on service to others."));
        video4.AddComment(new Comment("Ether", "I felt inspired to serve more to the Lords"));
        video4.AddComment(new Comment("HolyGhost", "Truly Uplifting. "));
        videos.Add(video4);

        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length (seconds): {video.LengthSeconds}");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:"); 
            foreach(var comment in video.GetComments())
            {
                Console.WriteLine($"{comment.CommenterName}: {comment.Text}");
            }
            Console.WriteLine();
        }




    }  
    }    

    
