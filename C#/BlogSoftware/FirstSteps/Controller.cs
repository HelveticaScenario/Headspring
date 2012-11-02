using System;
using System.Collections.Generic;
using System.Globalization;
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
        public string Index()
        {
            //Ask the database for all posts,
            //find the most recent one,
            //return that one.
            return Nickname(ArchiveArray.First().Nickname);
        }

        public string Archives()
        {
            //Ask the database for all posts,
            //and return them in reverse
            //chronological order.
            
            return GetFormattedPostMap(ArchiveArray);
            
        }

        private IEnumerable<Post> ArchiveArray
        {
            get { return phoBase.GetAll().OrderByDescending(d => d.TimeStamp); }
        }

        public string Year(int year)
        {
            //Ask the database for all posts,
            //collect the ones in the given year,
            //and return *those* in reverse 
            //chronological order.
            return GetFormattedPostMap(ArchiveArray.Where(post => post.TimeStamp.Year == year));

        }

        public string Nickname(string nickname)
        {
            //Ask the database for the post
            //that has this exact nickname
            //and just return that.
            var post = phoBase.Get(nickname);
            var toReturn = "";
            toReturn += post.Title + "\n\n";
            toReturn += post.Body + "\n\n";
            toReturn += FormattedDateString(post.TimeStamp) + "\n";
            return toReturn;

        }

        public static string MonthName(DateTime date)
        {
            return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(date.Month);
        }

        private string FormattedDateString(DateTime date)
        {
            string toReturn = "";
            toReturn += date.DayOfWeek + ", ";
            toReturn += MonthName(date);
            toReturn += " " + date.Day.ToString();
            return toReturn;
        }

        private string GetFormattedPostMap(IEnumerable<Post> posts)
        {
            string toReturn = "";
            int currentYear = -1;
            int currentMonth = -1;
            foreach (Post post in posts)
            {
                if (post.TimeStamp.Year != currentYear)
                {
                    currentYear = post.TimeStamp.Year;
                    toReturn += "\n" + post.TimeStamp.Year + "\n";
                    currentMonth = -1;
                }
                if (post.TimeStamp.Month != currentMonth)
                {
                    currentMonth = post.TimeStamp.Month;
                    toReturn += "\t" + MonthName(post.TimeStamp) + "\n";
                }
                toReturn += "\t\t";
                toReturn += post.Title;
                toReturn += " - ";
                toReturn += FormattedDateString(post.TimeStamp) + "\n";
            }
            return toReturn.Remove(0,1);
        }

    }
}