using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FirstSteps;

namespace MVC4BlogSoftware
{
    public class PagedEntries
    {
        public PagedEntries(IEnumerable<Post> pageOfPosts, int currentPage, bool pagingEnabled, string author = null, int? year = null )
        {
            PagingEnabled = pagingEnabled;
            Author = author;
            Year = year;
            CurrentPage = currentPage;
            PageOfPosts = pageOfPosts;
        }

        public IEnumerable<Post> PageOfPosts { get; private set; }
        public int CurrentPage { get; private set; }
        public bool PagingEnabled { get; private set; }
        public string Author { get; private set; }
        public int? Year { get; private set; }
    }
}