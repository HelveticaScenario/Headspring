using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstSteps
{
    public class Controller
    {
        //A field for a Database object, and initialize it with a constructor.
        private PhoBase phoBase;

        public Controller(PhoBase pho)
        {
            phoBase = pho;
        }
        public Post Index()
        {
            //Ask the database for all posts,
            //find the most recent one,
            //return that one.
            return Archives().First();
        }

        public Post[] Archives()
        {
            //Ask the database for all posts,
            //and return them in reverse
            //chronological order.
            return phoBase.GetAll().OrderByDescending(d => d.TimeStamp).ToArray();
        }

        public Post[] Year(int year)
        {
            //Ask the database for all posts,
            //collect the ones in the given year,
            //and return *those* in reverse 
            //chronological order.
            return Archives().Where(post => post.TimeStamp.Year == year).ToArray();
        }

        public Post Nickname(string nickname)
        {
            //Ask the database for the post
            //that has this exact nickname
            //and just return that.
            return phoBase.Get(nickname);
        } 

    }
}