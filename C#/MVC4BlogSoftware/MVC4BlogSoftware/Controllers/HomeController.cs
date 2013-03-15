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
        private const int PerPage = 2;
        private readonly IPostRepository _postRepository;

        //

        // POST: /Account/Login


        public HomeController(IPostRepository pho)
        {
            _postRepository = pho;
        }

        public ActionResult Index()
        {
            return View(_postRepository.GetMostRecent());
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
            return PagedActionResult(_postRepository.GetAll(page, PerPage), page, "Archive");
        }

        public ActionResult Author(string name, int page = 1)
        {
            return PagedActionResult(_postRepository.GetAuthor(name, page, PerPage), page, "Author",name);
        }

        public ActionResult Year(int year, int page = 1)
        {
            return PagedActionResult(_postRepository.GetYear(year, page, PerPage), page, "Year",null,year);
        }

        private ActionResult PagedActionResult(IEnumerable<Post> PostCollection, int page, string view, string name = null, int? year = null )
        {
            if (page == 0)
            {
                return View(view,new PagedEntries(PostCollection, 1, false,name,year));
            }
            return View(view,new PagedEntries(PostCollection, page, true,name,year));
        }

        public ActionResult Nickname(string nickname)
        {
            //Ask the database for the post
            //that has this exact nickname
            //and just return that.
            var post = _postRepository.Get(nickname: nickname);
            var model = post;
            
            return View("Index", model);
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
