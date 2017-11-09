using System;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Mvc.Ajax;

public static class HtmlHelperExtensions
{
    public static MvcHtmlString RawActionLink(this AjaxHelper ajaxHelper, string rawHtml, string action, string controller, object routeValues, AjaxOptions ajaxOptions, object htmlAttributes)
    {
        string holder = Guid.NewGuid().ToString();
        string anchor = ajaxHelper.ActionLink(holder, action, controller, routeValues, ajaxOptions, htmlAttributes).ToString();
        return MvcHtmlString.Create(anchor.Replace(holder, rawHtml));
    }
    //Transform to atributs html in a ancord rut
    public static MvcHtmlString RawActionLink(this HtmlHelper htmlHelper, string rawHtml, string action, string controller, object routeValues, object htmlAttributes)
    {
        string holder = Guid.NewGuid().ToString();
        string anchor = htmlHelper.ActionLink(holder, action, controller, routeValues, htmlAttributes).ToString();
        return MvcHtmlString.Create(anchor.Replace(holder, rawHtml));
    }

}
