using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FirstSteps;
using PagedList;

namespace MVC4BlogSoftware
{
    public class DisableablePagedList
    {
        public DisableablePagedList(IPagedList<Post> pagedList, bool enabled = true )
        {
            PagedList = pagedList;
            Enabled = enabled;
        }

        public bool Enabled { get; private set; }
        public IPagedList<Post> PagedList { get; private set; }
    }
}