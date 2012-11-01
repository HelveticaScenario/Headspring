using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstSteps
{
    public enum UrlType {HomePage, Archive, Admin, Year, Nickname}
    public static class UrlParser
    {
        public static string GetSuffix(string url)
        {
            url = url.ToUpper();
            if (url.StartsWith("http://".ToUpper()))
            {
                url = url.Substring(7);
            }
            //var prefix = url.Substring(0, url.IndexOf('/'));
            return url.Substring(url.IndexOf('/')).Trim('/');
        }

        public static UrlType? EvalSuffix(string url)
        {
            var suffix = GetSuffix(url);
            if (IsHomePage(suffix)) return UrlType.HomePage;
            if (IsArchive(suffix)) return UrlType.Archive;
            if (IsAdmin(suffix)) return UrlType.Admin;
            if (IsYear(suffix)) return UrlType.Year;
            if (IsNickName(suffix)) return UrlType.Nickname;
            return null;
        }

        public static bool IsHomePage(string suffix)
        {
            return suffix == "";
        }

        public static bool IsArchive(string suffix)
        {
            return suffix == "ARCHIVE";
        }

        public static bool IsAdmin(string suffix)
        {
            return suffix == "ADMIN";
        }

        public static bool IsYear(string suffix)
        {
            int year;
            return (suffix.Length == 4 || suffix.Length == 2) && int.TryParse(suffix, out year);
        }

        public static bool IsNickName(string suffix)
        {
            //return true if the url is /some-nick-name
            //should return false for things like "/2010", "/Admin", "/Archive"...
            if (!(IsHomePage(suffix) || IsArchive(suffix) || IsYear(suffix)))
            {
                return !suffix.Contains(" "); // this line is the only thing this method has to contain.
            }
            return false;
        }
    }
}
