using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FirstSteps;

namespace MVC4BlogSoftware
{
    public class PagedEntries
    {
        public PagedEntries(IEnumerable<Post> pageOfPosts, int currentPage, int totalPages, bool enabled, string author = null, int? year = null )
        {
            Enabled = enabled;
            Author = author;
            Year = year;
            TotalPages = totalPages;
            CurrentPage = currentPage;
            PageOfPosts = pageOfPosts;
        }

        public IEnumerable<Post> PageOfPosts { get; private set; }
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public bool Enabled { get; private set; }
        public string Author { get; private set; }
        public int? Year { get; private set; }
    }
}