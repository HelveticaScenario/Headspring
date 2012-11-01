using System;

namespace FirstSteps
{
    public class Post
    {
        public string Body { get; set; }
        public string Nickname { get; set; }
        public string Title { get; set; }
        public DateTime TimeStamp { get; set; }

        public Post(string title, string nickname, string body, DateTime timeStamp)
        {
            Title = title;
            Nickname = nickname;
            Body = body;
            TimeStamp = timeStamp;
        }


    }
}