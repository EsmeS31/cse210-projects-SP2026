using System;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();
        Video video1 = new Video("C# for Beginners", "CodeWithJack", 340);
        video1.AddComment(new Comment("ChaseB","This is really helpful!"));
        video1.AddComment(new Comment ("KendraL", "This is a great resource"));
        video1.AddComment(new Comment("AliceY", "Can you do a video explaining only the Abstraction principle?"));
        videos.Add(video1);

        Video video2 = new Video("What to visit in Seoul, South Korea", "TravelwithJane", 670);
        video2.AddComment(new Comment("AlanK","Can't wait to go!"));
        video2.AddComment(new Comment ("AmeliaP", "This is so helful, hope I can go someday!"));
        video2.AddComment(new Comment("ConnorT", "I love your videos!"));
        videos.Add(video2);

         Video video3 = new Video("How sugar affects the brain - Nicole Avena", "TED-Ed", 303);
        video3.AddComment(new Comment("EricD","I like broccoli"));
        video3.AddComment(new Comment ("DanaP", "Too much of everything is bad for you..."));
        video3.AddComment(new Comment("BetoAcapulco", "im eating candy at the dentist while watch this video."));
        videos.Add(video3);

        foreach(Video v in videos)
        {
            v.DisplayVideoDetails();
        }
    }
}