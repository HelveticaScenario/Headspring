using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstSteps
{
    public class PhoBase
    {
        //Maintains a collection of Post objects.
        //You can start out initializing the array with about 5 fake posts (new Post(...)...)
        private List<Post> posts; 

        public PhoBase()
        {
            posts = new List<Post>();

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
            return posts.FirstOrDefault(post => post.Nickname == nickname);
        }
    }
}
