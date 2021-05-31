using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_WEB.App
{
    public static class ViewExtend
    {
        public static string FillByIdex<T>(this List<T> list, T item, int loop, string text)
        {
            var index = list.IndexOf(item);
            if (index == 0) return string.Empty;
            if (index % loop == 0) return text;
            return string.Empty;
        }

        public static string FillFirstItem<T>(this List<T> list, T item, string text)
        {
            var index = list.IndexOf(item);
            if (index == 0) return text;
            return string.Empty;
        }

     
        public static string ToSafeTitle(this string text)
        {
            if (string.IsNullOrEmpty(text)) return string.Empty;
            text = HttpUtility.HtmlDecode(text);
            text = text.Replace("\"", "");
            return text;
        }

        public static string SubText(this string input, int length = 100)
        {
            if (string.IsNullOrEmpty(input) || length > input.Length)
            {
                return input;
            }

            var endPosition = input.IndexOf(" ", length, StringComparison.Ordinal);
            if (endPosition < 0) endPosition = input.Length;

            return length >= input.Length ? input : input.Substring(0, endPosition) + "...";
        }

        public static string GetUri()
        {
            var uri = HttpContext.Current.Request.Path + HttpContext.Current.Request.QueryString.ToString();
            return uri;
        }

       
    }
}