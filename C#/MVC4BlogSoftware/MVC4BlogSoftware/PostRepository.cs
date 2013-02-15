using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace FirstSteps
{
    public interface IPostRepository
    {
        bool Empty { get; }
        void Add(Post post);
        void Delete(Post post);
        Post[] GetAll();
        Post Get(string nickname);
    }

    public class Author
    {
        public int id { get; set; }
        public string username { get; set; }
    }

    public class AuthorRepository
    {
        public Author[] GetAll()
        {
            using (var connection = new MySqlConnection("Server=localhost;Database=blog;Uid=root;Pwd=bfgiadbif;"))
            {
                connection.Open();
                var someVar = connection.Query<Author>("select * from authors").ToArray();
                return someVar;
            }
        }
    }

    public class PostRepository : IPostRepository
    {
        public bool Empty { get { return FakeDb.Empty; } }
        private static readonly StubPostRepository FakeDb;
        static PostRepository()
        {
            FakeDb = new StubPostRepository();
            FakeDb.FillWithFakeData();
        }
        
        public void Add(Post post)
        {
            FakeDb.Add(post);
        }

        public void Delete(Post post)
        {
            FakeDb.Delete(post);
        }

        public Post[] GetAll()
        {
            return FakeDb.GetAll();
        }

        public Post Get(string nickname)
        {
            return FakeDb.Get(nickname);
        }
    }

    public class StubPostRepository : IPostRepository
    {
        //Maintains a collection of Post objects.
        //You can start out initializing the array with about 5 fake posts (new Post(...)...)
        public List<Post> posts;
        public bool Empty 
        { 
            get { return posts.Count == 0; } 
        }

        public StubPostRepository()
        {
            posts = new List<Post>();

        }

        public void FillWithFakeData()
        {
            posts.Add(new Post("First", "first post", new DateTime(34, 4, 23), "John Doe"));
            posts.Add(new Post("Second", "second post", new DateTime(98, 7, 25), "John Doe"));
            posts.Add(new Post("Third", "third post", new DateTime(34, 6, 23), "John Doe"));
            posts.Add(new Post("Fourth", "fourth post", new DateTime(53, 7, 13), "Some Guy"));
            posts.Add(new Post("Fifth", "fifth post", new DateTime(26, 6, 27), "John Doe"));
        }

        public void Add(Post post)
        {
            posts.Add(post);
        }
        public void Delete(Post post)
        {
            posts.Remove(post);
        }
        public Post[] GetAll()
        {
            var collection = new Post[posts.Count()];
            int i = 0;
            foreach (Post post in posts)
            {
                collection[i] = post;
                i++;
            }
            return collection;
        }
        public Post Get(string nickname)
        {
   

//            foreach (Post post in posts)
//            {
//                if (post.Nickname == nickname) return post;
//            }
//            return null;
            //suggested converting to LINQ?
            var returnPost = posts.FirstOrDefault(post => post.Nickname == nickname);
            if (returnPost == null)
            {
                throw new Exception("No post with that nickname.");
            }
            return returnPost;
        }
    }
}
