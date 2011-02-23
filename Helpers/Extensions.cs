﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using FlickrGallery.Models;

namespace FlickrGallery.Helpers
{
    public static class HtmlDropDownExtensions
    {
        public static MvcHtmlString EnumDropDownList<TEnum>(this HtmlHelper htmlHelper, string name, TEnum selectedValue)
        {
            // Use the in-built html helpers to render the SelectListItems as a drop down list 
            return htmlHelper.DropDownList(
                name,
                GetEnumSelectListItems<TEnum>(selectedValue)
                );
        }

        public static MvcHtmlString EnumDropDownList<TEnum>(this HtmlHelper htmlHelper, string name, TEnum selectedValue, object htmlAttributes)
        {
            // Use the in-built html helpers to render the SelectListItems as a drop down list 
            return htmlHelper.DropDownList(
                name,
                GetEnumSelectListItems<TEnum>(selectedValue),
                htmlAttributes
                );
        }

        public static IEnumerable<SelectListItem> GetEnumSelectListItems<TEnum>(TEnum selectedValue)
        {
            // Get the list of possible enum values 
            IEnumerable<TEnum> values = Enum.GetValues(typeof(TEnum))
                .Cast<TEnum>();

            // Convert the enum values to SelectListItems 
            IEnumerable<SelectListItem> items =
                from value in values
                select new SelectListItem
                {
                    Text = Utilities.GetEnumDescription(value),
                    Value = value.ToString(),
                    Selected = (value.Equals(selectedValue))
                };

            return items;
        }
    }
}