using System;

namespace FirstSteps
{
    public class Post
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public string Nickname { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public DateTime Published_DateTime { get; set; }

        public Post()
        {
        }

        public Post(int id, string title, string body, DateTime timeStamp, string author)
        {
            Id = id;
            Title = title;
            var nickname = Title;
            if (nickname.Length >= 10) nickname = nickname.Remove(9);
            Nickname = nickname.TrimEnd().ToLower().Replace(" ", "-");

            Nickname = nickname;
            Body = body;
            Author = author;
            Published_DateTime = timeStamp;
        }
    }
}