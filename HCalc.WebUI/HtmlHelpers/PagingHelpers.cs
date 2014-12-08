﻿using System;
using System.Text;
using System.Web.Mvc;
using System.Web.UI.WebControls;
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
                TagBuilder tag = new TagBuilder("li");
                tag.InnerHtml = string.Format("<a href=\"{0}\">{1}</a>", pageUrl(i), i);

                if (i == pagingInfo.CurrentPage)
                {
                    tag.AddCssClass("active");
                }

                result.Append(tag);

//                TagBuilder tag = new TagBuilder("a");
//                tag.MergeAttribute("href", pageUrl(i));
//                tag.InnerHtml = i.ToString();
//                if (i == pagingInfo.CurrentPage)
//                {
//                    tag.AddCssClass("selected");
//                    tag.AddCssClass("btn-primary");
//                }
//                tag.AddCssClass("btn btn-default");
//                
//                result.AppendFormat("<li>{0}</li>", tag);
            }

            return MvcHtmlString.Create(result.ToString());
        }
    }
}