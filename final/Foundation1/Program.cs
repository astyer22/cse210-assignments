using System;
using System.Transactions;

class Video
{
    public string _title;
    public string _author;
    public int _length;
    public List<string> _comments;

    public int GetNumberOfComments()
    {
        return _comments.Count;
    }
}

class Comment 
{
    public string _commenterName;
    public string _commentText;

    public string GetCommenterName()
    {
        return _commenterName;
    }

    public string GetCommentText()
    {
        return _commentText;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Foundation1 World!");
    }
}