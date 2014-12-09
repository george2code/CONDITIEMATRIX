using System;
using System.Text;
using System.Web.Mvc;
using HCalc.WebUI.Models;

namespace HCalc.WebUI.HtmlHelpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html,
            PagingInfo pagingInfo,
            Func<int, string> pageUrl)
        {
            var result = new StringBuilder();

            for (int i = 1; i <= pagingInfo.TotalPages; i++)
            {
                var tag = new TagBuilder("li");
                tag.InnerHtml = string.Format("<a href=\"{0}\">{1}</a>", pageUrl(i), i);

                if (i == pagingInfo.CurrentPage)
                {
                    tag.AddCssClass("active");
                }

                result.Append(tag);
            }

            return MvcHtmlString.Create(result.ToString());
        }
    }
}