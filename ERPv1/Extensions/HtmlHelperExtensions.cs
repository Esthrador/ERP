using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;

namespace ERPv1.Extensions
{
    public static class HtmlHelperExtensions
    {
        /// <summary>
        /// Diese Extension-Methode erzeugt einen Html Actionlink mit Font Awesome Icons.
        /// </summary>
        /// <param name="htmlHelper">HtmlHelper</param>
        /// <param name="linkText">Der Linktext des Actionlinks, mit möglichen HTML Elementen</param>
        /// <param name="actionName">Actioname des Controllers</param>
        /// <param name="controllerName">Controllername</param>
        /// <param name="routeValues">RouteValues</param>
        /// <param name="htmlAttributes">htmlAttributes</param>
        /// <param name="faClass">Die CSS Klasse des FA Icons</param>
        /// <param name="left">Falls true, wird das Icon linksbündig vom Text dargestellt</param>
        /// <returns>Html.Actionlink</returns>
        public static MvcHtmlString ActionLinkWithIcon(this HtmlHelper htmlHelper, string linkText, string faClass, bool left, string actionName, string controllerName, object routeValues, object htmlAttributes)
        {
            var repId = Guid.NewGuid().ToString();

            var lnk = htmlHelper.ActionLink(repId, actionName, controllerName, routeValues, htmlAttributes);

            var newLinkText = left
                ? "<i class=\"" + faClass + "\" style=\"margin-right:5px;\"></i> " + linkText
                : linkText + " <i class=\"" + faClass + "\" style=\"margin-left:5px;\"></i>";

            return MvcHtmlString.Create(lnk.ToString().Replace(repId, newLinkText));
        }

        /// <summary>
        /// Diese Extension-Methode erzeugt einen Ajax Actionlink mit Font Awesome Icons.
        /// </summary>
        /// <param name="ajaxHelper">AjaxHelper</param>
        /// <param name="linkText">Der Linktext des Actionlinks, mit möglichen HTML Elementen</param>
        /// <param name="actionName">Actioname des Controllers</param>
        /// <param name="controllerName">Controllername</param>
        /// <param name="routeValues">RouteValues</param>
        /// <param name="ajaxOptions">AjaxOptions</param>
        /// <param name="htmlAttributes">htmlAttributes</param>
        /// <param name="faClass">Die CSS Klasse des FA Icons</param>
        /// <param name="left">Falls true, wird das Icon linksbündig vom Text dargestellt</param>
        /// <returns>Ajax.Actionlink</returns>
        public static MvcHtmlString ActionLinkWithIcon(this AjaxHelper ajaxHelper, string linkText, string faClass, bool left, string actionName, string controllerName, object routeValues, AjaxOptions ajaxOptions, object htmlAttributes)
        {
            var repId = Guid.NewGuid().ToString();

            var lnk = ajaxHelper.ActionLink(repId, actionName, controllerName, routeValues, ajaxOptions, htmlAttributes);

            var newLinkText = left
                ? ("<i class=\"" + faClass + "\" ></i> " + linkText)
                : (linkText + " <i class=\"" + faClass + "\" ></i>");

            return MvcHtmlString.Create(lnk.ToString().Replace(repId, newLinkText));
        }
    }
}