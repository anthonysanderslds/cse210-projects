using System;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Love All", "Peter", 25);
        Comment comment1 = new Comment("Enoch", "This was an awesome video");
        video1.AddComment(comment1);
        Comment comment2 = new Comment("James", "I love this so much!");
        video1.AddComment(comment2);
        Comment comment3 = new Comment("John", "This was very thoughtful.");
        video1.AddComment(comment3);
        videos.Add(video1);

        Video video2 = new Video("Be Kind", "James", 35);
        Comment comment4 = new Comment("Mary", "How wonderful!");
        video2.AddComment(comment4);
        Comment comment5 = new Comment("Martha", "How true!");
        video2.AddComment(comment5);
        Comment comment6 = new Comment("Eli", "Worth the watch!");
        video2.AddComment(comment6);
        videos.Add(video2);

        Video video3 = new Video("Trust the Lord", "Moroni", 55);
        Comment comment7 = new Comment("Helaman", "Amen, Brother!");
        video3.AddComment(comment7);
        Comment comment8 = new Comment("Lehi", "This man speaks the truth");
        video3.AddComment(comment8);
        Comment comment9 = new Comment("Joseph", "I know this guy! He's awesome.");
        video3.AddComment(comment9);
        videos.Add(video3);

        foreach (Video vid in videos)
        {
            Console.WriteLine($"Video Info: {vid.GroupVideoDetails()}");
            Console.WriteLine($"Comment Count: {vid.GetCommentCount()}");
            Console.WriteLine($"Comment List:");
            vid.DisplayComments();
            Console.WriteLine();
        }
    }
}