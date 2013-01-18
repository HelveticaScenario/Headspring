using System;

namespace FirstSteps
{
    public class Post
    {
        public string Body { get; set; }
        public string Nickname { get
        {
            if (Title.Length >= 10)
                Title.Remove(9);
            return Title.TrimEnd().ToLower().Replace(" ", "-");
        }
        }
        public string Author { get; set; }
        public string Title { get; set; }
        public DateTime TimeStamp { get; set; }

        public Post(string title, string body, DateTime timeStamp, string author)
        {
            Title = title;
            Body = body;
            Author = author;
            TimeStamp = timeStamp;
        }
    }
}