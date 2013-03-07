using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FirstSteps;
using MVC4BlogSoftware.Models;
using WebMatrix.WebData;
using PagedList;
using Controller = System.Web.Mvc.Controller;
using MVC4BlogSoftware;

namespace MVC4BlogSoftware.Controllers
{
    public class PostForm
    {
        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Body")]
        public string Body { get; set; }

        [Required]
        [Display(Name = "Author")]
        public string Author { get; set; }
    }

    public class HomeController : Controller
    {
        private readonly IPostRepository _postRepository;

        //

        // POST: /Account/Login


        public HomeController(IPostRepository pho)
        {
            _postRepository = pho;
        }

        public ActionResult Index()
        {
            return View(IndexGet());
        }

        public ActionResult Add(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Add(PostForm form, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                _postRepository.Add(new Post(
                                 -1,
                                 form.Title,
                                 form.Body,
                                 DateTime.Now,
                                 form.Author));
                return RedirectToAction("Index", "Home");
            }

            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "Something happened.");
            return View();
        }

        public ActionResult Archive(int page = 1)
        {
            const int perPage = 2;
            IEnumerable<Post> aa = ArchiveArray;
            return PagedActionResult(aa, page, perPage, "Archive");
        }

        public ActionResult Author(string name, int page = 1)
        {
            const int perPage = 2;
            IEnumerable<Post> aa = AllByAuthor(name);
            return PagedActionResult(aa, page, perPage, "Author",name);
        }

        public ActionResult PostTest()
        {
            var postRepo = _postRepository.GetAll();
            return PagedActionResult(postRepo,1,postRepo.Count(),"Archive");
        }

        public ActionResult Year(int year, int page = 1)
        {
            const int perPage = 2;
            IEnumerable<Post> aa = YearGet(year);
            return PagedActionResult(aa, page, perPage, "Year",null,year);
        }

        private ActionResult PagedActionResult(IEnumerable<Post> aa, int page, int perPage, string view, string name = null, int? year = null )
        {
            if (page == 0)
            {
                return View(view,new PagedEntries(aa, 1, 1, false,name,year));
            }
            var totalPages = aa.Count()/perPage;
            if (aa.Count()%perPage != 0)
            {
                totalPages++;
            }
            aa = aa.Skip(perPage*(page - 1));
            aa = aa.Take(perPage);
            return View(view,new PagedEntries(aa, page, totalPages, true,name,year));
        }

        public ActionResult Nickname(string nickname)
        {
            var model = NicknameGet(nickname);
            
            return View("Index", model);
        }

        private Post IndexGet()
        {
            //Ask the database for all posts,
            //find the most recent one,
            //return that one.
            var post = ArchiveArray.FirstOrDefault();
            if (post != null)
            {
                return NicknameGet(post.Nickname);
            }
            return null;

        }

        private IEnumerable<Post> ArchiveArray
        {
            get { return _postRepository.GetAll().OrderByDescending(d => d.Published_DateTime); }
        }

        public IEnumerable<Post> YearGet(int year)
        {
            //Ask the database for all posts,
            //collect the ones in the given year,
            //and return *those* in reverse 
            //chronological order.
            return ArchiveArray.Where(post => post.Published_DateTime.Year == year);

        }

        public IEnumerable<Post> AllByAuthor(string author)
        {
            //Ask the database for all posts,
            //collect the ones in the given year,
            //and return *those* in reverse 
            //chronological order.
            return ArchiveArray.Where(post => post.Author == author);

        }

        public Post NicknameGet(string nickname)
        {
            //Ask the database for the post
            //that has this exact nickname
            //and just return that.
            var post = _postRepository.Get(nickname: nickname);
//            var toReturn = "";
//            toReturn += post.Title + "\n";
//            toReturn += "by " + post.Author + "\n\n";
//            toReturn += post.Body + "\n\n";
//            toReturn += FormattedDateString(post.TimeStamp) + "\n";
            return post;// toReturn;

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
                if (post.Published_DateTime.Year != currentYear)
                {
                    currentYear = post.Published_DateTime.Year;
                    toReturn += "\n" + post.Published_DateTime.Year + "\n";
                    currentMonth = -1;
                }
                if (post.Published_DateTime.Month != currentMonth)
                {
                    currentMonth = post.Published_DateTime.Month;
                    toReturn += "\t" + MonthName(post.Published_DateTime) + "\n";
                }
                toReturn += "\t\t";
                toReturn += post.Title;
                toReturn += " - ";
                toReturn += FormattedDateString(post.Published_DateTime) + "\n";
            }
            return toReturn == "" ? "No Posts!" : toReturn.Remove(0, 1);
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

}
