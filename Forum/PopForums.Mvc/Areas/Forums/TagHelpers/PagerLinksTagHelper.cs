﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Routing;
using PopForums.Models;

namespace PopForums.Mvc.Areas.Forums.TagHelpers
{
	[HtmlTargetElement("pf-pagerLinks", Attributes = "controllerName, actionName, pagerContext")]
	public class PagerLinksTagHelper : TagHelper
	{
		private readonly IHtmlGenerator _htmlGenerator;

		[HtmlAttributeName("controllerName")]
		public string ControllerName { get; set; }
		[HtmlAttributeName("actionName")]
		public string ActionName { get; set; }
		[HtmlAttributeName("pagerContext")]
		public PagerContext PagerContext { get; set; }
		[HtmlAttributeName("class")]
		public string Class { get; set; }
		[HtmlAttributeName("moreTextClass")]
		public string MoreTextClass { get; set; }
		[HtmlAttributeName("currentTextClass")]
		public string CurrentTextClass { get; set; }
		[HtmlAttributeName("routeParameters")]
		public Dictionary<string, object> RouteParameters { get; set; }
		[HtmlAttributeName("low")]
		public int Low { get; set; }
		[HtmlAttributeName("high")]
		public int High { get; set; }

		[HtmlAttributeNotBound]
		[ViewContext]
		public ViewContext ViewContext { get; set; }

		public PagerLinksTagHelper(IHtmlGenerator htmlGenerator)
		{
			_htmlGenerator = htmlGenerator;
		}

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			if (PagerContext == null)
				return;
			if (String.IsNullOrEmpty(ControllerName) || String.IsNullOrEmpty(ActionName))
				throw new Exception("controllerName and actionName must be specified for PageLinks.");
			if (PagerContext.PageCount <= 1)
				return;
			
			var builder = new StringBuilder();
			if (String.IsNullOrEmpty(MoreTextClass)) builder.Append($"<li><span>{Resources.More}:</span></li>");
			else builder.Append($"<li class=\"{MoreTextClass}\"><span>{Resources.More}</span></li>");

			if (PagerContext.PageIndex != 1 && Low != 1)
			{
				// first page link
				builder.Append("<li>");
				var firstRouteDictionary = new RouteValueDictionary(new { controller = ControllerName, action = ActionName, page = 1 });
				if (RouteParameters != null)
					foreach (var item in RouteParameters)
						firstRouteDictionary.Add(item.Key, item.Value);
				var firstLink = _htmlGenerator.GenerateActionLink(ViewContext, "", ActionName, ControllerName, null, null, null,
					firstRouteDictionary, new { title = Resources.First, @class = "glyphicon glyphicon-step-backward" });
				builder.Append(GetString(firstLink));
				builder.Append("</li>");
				if (PagerContext.PageIndex > 2)
				{
					// previous page link
					var previousIndex = PagerContext.PageIndex - 1;
					if (Low != 0)
						previousIndex = Low - 1;
					builder.Append("<li>");
					var previousRouteDictionary = new RouteValueDictionary(new { controller = ControllerName, action = ActionName, page = previousIndex });
					if (RouteParameters != null)
						foreach (var item in RouteParameters)
							previousRouteDictionary.Add(item.Key, item.Value);
					var previousLink = _htmlGenerator.GenerateActionLink(ViewContext, "", ActionName, ControllerName, null, null, null, previousRouteDictionary, new { title = Resources.Previous, @class = "glyphicon glyphicon-chevron-left", rel = "prev" });
					builder.Append(GetString(previousLink));
					builder.Append("</li>");
				}
			}

			if (Low == 0 || High == 0)
			{
				// not a multipage set of links used in partial page
				// calc low and high limits for numeric links
				var low = PagerContext.PageIndex - 1;
				var high = PagerContext.PageIndex + 3;
				if (low < 1) low = 1;
				if (high > PagerContext.PageCount) high = PagerContext.PageCount;
				if (high - low < 5) while ((high < low + 4) && high < PagerContext.PageCount) high++;
				if (high - low < 5) while ((low > high - 4) && low > 1) low--;
				for (var x = low; x < high + 1; x++)
				{
					// numeric links
					if (x == PagerContext.PageIndex)
					{
						if (String.IsNullOrEmpty(CurrentTextClass))
							builder.Append(String.Format("<li><span class=\"active\">{0} of {1}</span></li>", x, PagerContext.PageCount));
						else builder.Append(String.Format("<li class=\"active {0}\"><span>{1} of {2}</span></li>", CurrentTextClass, x, PagerContext.PageCount));
					}
					else
					{
						builder.Append("<li>");
						var numericRouteDictionary = new RouteValueDictionary { { "controller", ControllerName }, { "action", ActionName }, { "page", x } };
						if (RouteParameters != null)
							foreach (var item in RouteParameters)
								numericRouteDictionary.Add(item.Key, item.Value);
						var link = _htmlGenerator.GenerateActionLink(ViewContext, x.ToString(), ActionName, ControllerName, null, null, null, numericRouteDictionary, null);
						builder.Append(GetString(link));
						builder.Append("</li>");
					}
				}
			}
			else
			{
				// multipage set of links used in partial page
				// calc low and high limits for numeric links
				var calcLow = PagerContext.PageIndex - 1;
				var calcHigh = PagerContext.PageIndex + 3;
				if (calcLow < 1) calcLow = 1;
				if (calcHigh > PagerContext.PageCount) calcHigh = PagerContext.PageCount;
				if (calcHigh - calcLow < 5) while ((calcHigh < calcLow + 4) && calcHigh < PagerContext.PageCount) calcHigh++;
				if (calcHigh - calcLow < 5) while ((calcLow > calcHigh - 4) && calcLow > 1) calcLow--;
				var isRangeRendered = false;
				for (var x = calcLow; x < calcHigh + 1; x++)
				{
					// numeric links
					if (x >= Low && x <= High)
					{
						if (!isRangeRendered)
						{
							isRangeRendered = true;
							if (String.IsNullOrEmpty(CurrentTextClass))
								builder.Append(String.Format("<li class=\"active\"><span>{0}-{1} of {2}</span></li>", Low, High, PagerContext.PageCount));
							else builder.Append(String.Format("<li class=\"active {0}\"><span>{1}-{2} of {3}</span></li>", CurrentTextClass, Low, High, PagerContext.PageCount));
						}
					}
					else
					{
						builder.Append("<li>");
						var numericRouteDictionary = new RouteValueDictionary { { "controller", ControllerName }, { "action", ActionName }, { "page", x } };
						if (RouteParameters != null)
							foreach (var item in RouteParameters)
								numericRouteDictionary.Add(item.Key, item.Value);
						var link = _htmlGenerator.GenerateActionLink(ViewContext, x.ToString(), ActionName, ControllerName, null, null, null, numericRouteDictionary, null);
						builder.Append(GetString(link));
						builder.Append("</li>");
					}
				}
			}

			if (PagerContext.PageIndex != PagerContext.PageCount && High < PagerContext.PageCount)
			{
				if (PagerContext.PageIndex < PagerContext.PageCount - 1)
				{
					// next page link
					var nextIndex = PagerContext.PageIndex + 1;
					builder.Append("<li>");
					var nextRouteDictionary = new RouteValueDictionary(new { controller = ControllerName, action = ActionName, page = nextIndex });
					if (RouteParameters != null)
						foreach (var item in RouteParameters)
							nextRouteDictionary.Add(item.Key, item.Value);
					var nextLink = _htmlGenerator.GenerateActionLink(ViewContext, "", ActionName, ControllerName, null, null, null, nextRouteDictionary, new { title = Resources.Next, @class = "glyphicon glyphicon-chevron-right", rel = "next" });
					builder.Append(GetString(nextLink));
					builder.Append("</li>");
				}
				// last page link
				builder.Append("<li>");
				var lastRouteDictionary = new RouteValueDictionary(new { controller = ControllerName, action = ActionName, page = PagerContext.PageCount });
				if (RouteParameters != null)
					foreach (var item in RouteParameters)
						lastRouteDictionary.Add(item.Key, item.Value);
				var lastLink = _htmlGenerator.GenerateActionLink(ViewContext, "", ActionName, ControllerName, null, null, null, lastRouteDictionary, new { title = Resources.Last, @class = "glyphicon glyphicon-step-forward", rel = "next" });
				builder.Append(GetString(lastLink));
				builder.Append("</li>");
			}

			output.TagMode = TagMode.StartTagAndEndTag;
			output.TagName = "ul";
			if (!String.IsNullOrWhiteSpace(Class))
				output.Attributes.Add("class", Class);
			output.Content.AppendHtml(builder.ToString());
		}

		private static string GetString(IHtmlContent content)
		{
			var writer = new System.IO.StringWriter();
			content.WriteTo(writer, HtmlEncoder.Default);
			return writer.ToString();
		}
	}
}