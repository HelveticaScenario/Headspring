using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace FirstSteps
{
    public class Controller
    {
        //A field for a Database object, and initialize it with a constructor.
        private readonly PhoBase phoBase;
        private string password;

        public Controller(PhoBase phobase, string password)
        {
            this.phoBase = phobase;
            this.password = password;
        }
        public string Index()
        {
            //Ask the database for all posts,
            //find the most recent one,
            //return that one.
            return phoBase.Empty ? "No Posts!" : Nickname(ArchiveArray.First().Nickname);
        }

        public string Archives()
        {
            //Ask the database for all posts,
            //and return them in reverse
            //chronological order.

            return phoBase.Empty ? "No Posts!" : GetFormattedPostMap(ArchiveArray);
            
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
        
        public string AllByAuthor(string author)
        {
            //Ask the database for all posts,
            //collect the ones in the given year,
            //and return *those* in reverse 
            //chronological order.
            return GetFormattedPostMap(ArchiveArray.Where(post => post.Author == author));

        }

        public string Nickname(string nickname)
        {
            //Ask the database for the post
            //that has this exact nickname
            //and just return that.
            var post = phoBase.Get(nickname);
            var toReturn = "";
            toReturn += post.Title + "\n";
            toReturn += "by " + post.Author + "\n\n";
            toReturn += post.Body + "\n\n";
            toReturn += FormattedDateString(post.TimeStamp) + "\n";
            return toReturn;

        }



        private bool AdminMode()
        {
            Console.Write("Password: ");
            if (Console.ReadLine() != this.password)
            {
                Console.WriteLine("Incorrect password.");
                return false;
            }
            Console.WriteLine("Welcome to admin mode! Have a cookie.");
            Console.WriteLine("Admin powers available: Add");
            Console.Write("What do you want to do: ");
            string cmd = Console.ReadLine();
            if (cmd != null)
            {
                if (cmd.ToLower() == "add")
                {
                    AddPost();
                    return true;
                }
            }
            return false;
        } 

        private string GenerateNickname(string title)
        {
            if (title.Length >= 10)
                title.Remove(9);
            return title.TrimEnd().ToLower().Replace(" ", "-");
        }

        private void AddPost()
        {
            Console.Write("Title: ");
            string title = Console.ReadLine();
            Console.Write("Body: ");
            string body = Console.ReadLine(); //Not very good, cant read in multi-line
            Console.Write("Author: ");
            string author = Console.ReadLine();
            phoBase.Add(new Post(title, GenerateNickname(title), body, DateTime.Now, author));
        }

        public void Access()
        {
            Console.Write("Enter a URL: ");
            var url = Console.ReadLine();
            if (url != null)
            {
                url.Trim();
            }
            else return;
            if (url == "")
            {
                return;
            }

            var tmp = UrlParser.EvalSuffix(url);
            if (tmp == null)
                return;
            var type = (UrlType) tmp;
            switch (type)
            {
                case UrlType.HomePage:
                    Console.WriteLine(Index());
                    break;
                case UrlType.Archive:
                    Console.WriteLine(Archives());
                    break;
                case UrlType.Admin:
                    AdminMode();
                    break;
                case UrlType.Year:
                    Console.WriteLine(Year(Convert.ToInt32(UrlParser.GetSuffix(url))));
                    break;
                case UrlType.Nickname:
                    try
                    {
                        Console.WriteLine(Nickname(UrlParser.GetSuffix(url)));
                    }
                    catch(Exception e)
                    {
                        Console.Write("404: " + e.Message);
                    }
                    break;   
                default:
                    throw new ArgumentOutOfRangeException();
            }
            Console.WriteLine();
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
            return toReturn == "" ? "No Posts!" : toReturn.Remove(0,1);
        }

    }
}