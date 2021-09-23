﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCrud.Paging
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;

        public PageLinkTagHelper(IUrlHelperFactory urlHelperFactory)
        {
            this.urlHelperFactory = urlHelperFactory;
        }
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        public PagingInfo PageModel { get; set; }
        public string PageName { get; set; }
        public Dictionary<string, object> PageOtherValues { get; set; } = new Dictionary<string, object>();
        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; }
        public string PageClassSelected { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            TagBuilder result = new TagBuilder("div");
            string anchorInnerHtml = "";
            for (int i = 1; i <= PageModel.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                anchorInnerHtml = anchorInnerHtml(i, PageModel);
                if (anchorInnerHtml == ". . ")
                    tag.Attributes["href"] = "";
                else if (PageOtherValues.Keys.Count != 0)
                    tag.Attributes["href"] = urlHelper.Page(PageName, AddDictionaryToQueryString(i));
                else
                    tag.Attributes["href"] = urlHelper.Page(PageName, new { id = i });
                if (PageClassesEnabled)
                {
                    tag.AddCssClass(PageClass);
                    tag.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : "");

                }
                tag.InnerHtml.Append(anchorInnerHtml);
                if (anchorInnerHtml != "")
                    result.InnerHtml.AppendHtml(tag);
            }
            output.Content.AppendHtml(result.InnerHtml);
        }
        public IDictionary<string, object> AddDictionaryToQueryString(int i)
        {
            object routeValues = null;
            var dict = (routeValues != null) ? new RouteValueDictionary(routeValues) : new RouteValueDictionary();
            dict.Add("id", i);
            foreach (string key in PageOtherValues.Keys)
            {
                dict.Add(key, PageOtherValues[key]);
            }
            var expandoOnject = new ExpandoObject();
            var expandoDictionary = (IDictionary<string, object>)expandoOnject;
            foreach (var KeyValuePair in dict)
            {
                expandoDictionary.Add(KeyValuePair);
            }
            return expandoDictionary;
        }
        public static string anchorInnerHtml;//-burda kaldım-//
    }
}
