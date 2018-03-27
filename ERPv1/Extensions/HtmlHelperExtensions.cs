using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERPv1.Extensions
{
    public static class HtmlHelperExtensions
    {
        /// <summary>
        /// Erweiterter AntiForgeryToken mit zusätzlichem Html Element.
        /// </summary>
        /// <param name="helper">HtmlHelper</param>
        /// <param name="additionalHtml">Zusätzliches Html in Form eines Span mit Display None</param>
        /// <returns>AntiForgeryToken</returns>
        public static MvcHtmlString AntiForgeryToken(this HtmlHelper helper, bool additionalHtml)
        {
            var antiForgeryToken = helper.AntiForgeryToken();

            var defaultString = antiForgeryToken.ToString();
            var defaultStringLength = defaultString.Length;

            var htmlString = MvcHtmlString.Create(defaultString.Insert(defaultStringLength, "</span>").Insert(0, "<span style=\"display:none\">"));

            return MvcHtmlString.Empty;
        }
    }
}