using System;
using System.Transactions;

class Video
{
    public string _title;
    public string _author;
    public int _length;
    public List<Comment> _comments;

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = new List<Comment>();
    }

    public string GetTitle() => _title;
    public string GetAuthor() => _author;
    public int GetLength() => _length;

    public void CreateVideo()
    {
        Console.WriteLine($"Video: {_title} by {_author} ({_length} seconds)");
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return _comments.Count;
    }
}

class Comment
{
    public string _commenterName;
    public string _commentText;

    public Comment(string commenterName, string commentText)
    {
        _commenterName = commenterName;
        _commentText = commentText;
    }

    public string GetCommenterName() => _commenterName;
    public string GetCommentText() => _commentText;
}

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video("Knifes Out", "Rian Johnson", 120);
        Video video2 = new Video("The Great Gatsby", "F. Scott Fitzgerald", 180);
        Video video3 = new Video("Bridge to Terabithia", "Katherine Paterson", 150);

        // Add Comments to video 1
        video1.AddComment(new Comment("John Doe", "Great video!"));
        video1.AddComment(new Comment("Jane Doe", "I love this movie!"));
        video1.AddComment(new Comment("John Smith", "I can't wait to watch this!"));

        // Add Comments to video 2
        video2.AddComment(new Comment("Jill Roberts", "This is a classic!"));
        video2.AddComment(new Comment("Jack Roberts", "I love the book too!"));
        video2.AddComment(new Comment("haynes Carter", "I didn't like the movie."));
        video2.AddComment(new Comment("Mike Lynskey", "I love Leo!"));

        video3.AddComment(new Comment("Rachel Lauren", "I cried so much!"));
        video3.AddComment(new Comment("Susan Delregno", "Why'd she have to die?"));

        // Putting the video into a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Irrating through the list of videos and duisplay inforamtion
        foreach (Video video in videos)
        {
            video.CreateVideo();
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            foreach (Comment comment in video._comments)
            {
                Console.WriteLine($"Commenter: {comment.GetCommenterName()}");
                Console.WriteLine($"Comment: {comment.GetCommentText()}");
            }
            Console.WriteLine();
        }

    }
}