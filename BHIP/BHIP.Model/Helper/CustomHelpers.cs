using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BHIP.MVCHelpers
{
    public static class CustomHelpers
    {
        /// <summary>
        /// Creates a link that will open a jQuery UI dialog form.
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="linkText">The inner text of the anchor element</param>
        /// <param name="dialogContentUrl">The url that will return the content to be loaded into the dialog window</param>
        /// <param name="dialogId">The id of the div element used for the dialog window</param>
        /// <param name="dialogTitle">The title to be displayed in the dialog window</param>
        /// <param name="updateTargetId">The id of the div that should be updated after the form submission</param>
        /// <param name="updateUrl">The url that will return the content to be loaded into the traget div</param>
        /// <returns></returns>
        public static MvcHtmlString DialogFormLink(this HtmlHelper htmlHelper, string linkText, string dialogContentUrl,
             string dialogTitle, string updateTargetId, string updateUrl)
        {
            TagBuilder builder = new TagBuilder("a");
            builder.SetInnerText(linkText);
            builder.Attributes.Add("href", dialogContentUrl);
            builder.Attributes.Add("data-dialog-title", dialogTitle);
            builder.Attributes.Add("data-update-target-id", updateTargetId);
            builder.Attributes.Add("data-update-url", updateUrl);

            // Add a css class named dialogLink that will be
            // used to identify the anchor tag and to wire up
            // the jQuery functions
            builder.AddCssClass("dialogLink");

            return new MvcHtmlString(builder.ToString());
        }


        /// <summary>
        /// Create an image link that will open a jQuery UI dialog form.
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="action"></param>
        /// <param name="controller"></param>
        /// <param name="routValues"></param>
        /// <param name="dialogTitle"></param>
        /// <param name="updateTargetId"></param>
        /// <param name="updateUrl"></param>
        /// <param name="imageURL"></param>
        /// <param name="alternateText"></param>
        /// <param name="linkHtmlAttributes"></param>
        /// <param name="imageHtmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString ImageDialogLink(this HtmlHelper htmlHelper, string action, string controller, object routValues,
                                            string dialogTitle, string updateTargetId, string updateUrl,
                                            string imageURL, string alternateText, string dialogHeight, string dialogWidth, object linkHtmlAttributes, object imageHtmlAttributes)
        {
            UrlHelper url = new UrlHelper(htmlHelper.ViewContext.RequestContext);

            TagBuilder imageBuilder = new TagBuilder("img");
            imageBuilder.MergeAttribute("src", imageURL);
            imageBuilder.MergeAttribute("alt", alternateText);
            imageBuilder.MergeAttributes(new RouteValueDictionary(imageHtmlAttributes));

            // create link tag builder
            TagBuilder linkBuilder = new TagBuilder("a");

            // add attributes
            linkBuilder.MergeAttribute("href", url.Action(action, controller, new RouteValueDictionary(routValues)));
            linkBuilder.Attributes.Add("data-dialog-title", dialogTitle);
            linkBuilder.Attributes.Add("data-update-target-id", updateTargetId);
            linkBuilder.Attributes.Add("data-update-url", updateUrl);
            linkBuilder.Attributes.Add("data-dialog-width", dialogWidth);
            linkBuilder.Attributes.Add("data-dialog-height", dialogHeight);

            // Add a css class named dialogLink that will be
            // used to identify the anchor tag and to wire up
            // the jQuery functions
            linkBuilder.AddCssClass("dialogLink");

            linkBuilder.InnerHtml = imageBuilder.ToString(TagRenderMode.SelfClosing);
            linkBuilder.MergeAttributes(new RouteValueDictionary(linkHtmlAttributes));

            return new MvcHtmlString(linkBuilder.ToString(TagRenderMode.Normal));
        }


        /// <summary>
        /// Create a link with an image.
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="action">Name of the controller action</param>
        /// <param name="controller">Name of the controller</param>
        /// <param name="routValues">Any routing values</param>
        /// <param name="imageURL">The image path</param>
        /// <param name="alternateText">Alternate text for the image</param>
        /// <param name="linkHtmlAttributes">Html attributes for the link</param>
        /// <param name="imageHtmlAttributes">Html attributes for the image</param>
        /// <returns></returns>
        public static MvcHtmlString ImageLink(this HtmlHelper htmlHelper, string action, string controller, object routValues,
                                            string imageURL, string alternateText, object linkHtmlAttributes, object imageHtmlAttributes)
        {
            UrlHelper url = new UrlHelper(htmlHelper.ViewContext.RequestContext);

            TagBuilder imageBuilder = new TagBuilder("img");
            imageBuilder.MergeAttribute("src", imageURL);
            imageBuilder.MergeAttribute("alt", alternateText);
            imageBuilder.MergeAttributes(new RouteValueDictionary(imageHtmlAttributes));

            // create link tag builder
            TagBuilder linkBuilder = new TagBuilder("a");

            // add attributes
            linkBuilder.MergeAttribute("href", url.Action(action, controller, new RouteValueDictionary(routValues)));
            linkBuilder.InnerHtml = imageBuilder.ToString(TagRenderMode.SelfClosing);
            linkBuilder.MergeAttributes(new RouteValueDictionary(linkHtmlAttributes));

            return new MvcHtmlString(linkBuilder.ToString(TagRenderMode.Normal));
        }

        public static string ResolveUrl(this HtmlHelper htmlHelper, string Url)
        {
            UrlHelper url = new UrlHelper(htmlHelper.ViewContext.RequestContext);
            return MvcHtmlString.Create(url.Content(Url)).ToString();
        }

        public static string ToSafeString(this object obj)
        {
            return (obj ?? string.Empty).ToString();
        }

    }
}