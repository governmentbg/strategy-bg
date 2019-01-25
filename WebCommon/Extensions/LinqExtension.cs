using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WebCommon.Models;

namespace WebCommon.Extensions
{
    /// <summary>
    /// Разширения на методите на Linq
    /// </summary>
    public static class LinqExtensions
    {
        public static SelectList ToSelectList<TSource, TValue, TText>(
        this IEnumerable<TSource> source,
        Expression<Func<TSource, TValue>> valueField,
        Expression<Func<TSource, TText>> textField)
        {
            return ToSelectList(source, valueField, textField, null);
        }
        public static SelectList ToSelectList<TSource, TValue, TText>(
         this IEnumerable<TSource> source,
         Expression<Func<TSource, TValue>> valueField,
         Expression<Func<TSource, TText>> textField,
            object selected)
        {
            if (source == null)
            {
                return new SelectList(new List<SelectListItem>());
            }
            string dataName = ExpressionHelper.GetExpressionText(valueField);
            string textName = ExpressionHelper.GetExpressionText(textField);
            return new SelectList(source, dataName, textName, selected);
        }

        public static SelectList ToSelectList(this IEnumerable<TextValueVM> model, object selected = null)
        {
            return new SelectList(model, nameof(TextValueVM.Value), nameof(TextValueVM.Text), selected);
        }


        public static SelectList SetSelected<TSource>(
        this IEnumerable<TSource> source, object selected)
        {
            if (source == null)
            {
                return new SelectList(new List<SelectListItem>());
            }
            return new SelectList(source, "Value", "Text", selected);
        }

        public static IEnumerable<SelectListItem> AddAllItem(
         this IEnumerable<SelectListItem> source, string allText = "Изберете", string allValue = "-1")
        {
            var allList = new List<SelectListItem>();
            allList.Add(new SelectListItem() { Text = allText, Value = allValue });
            return allList.Union(source);
        }
        public static IEnumerable<SelectListItem> AppendItem(
         this IEnumerable<SelectListItem> source, string Text, string Value)
        {
            var newList = new List<SelectListItem>();
            newList.Add(new SelectListItem() { Text = Text, Value = Value });
            return source.Union(newList);
        }

        public static bool IsEmpty<T>(this IEnumerable<T> source)
        {
            if (source == null)
                return true;

            if (source.Count() == 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Сортиране в DataTables
        /// </summary>
        /// <typeparam name="T">Тип на данните</typeparam>
        /// <param name="source">Дърво, което трябва да бъде подредено</param>
        /// <param name="sortModels">Модел с данни за начина на сортиране</param>
        /// <returns></returns>
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, IEnumerable<DataTables.AspNet.Core.IColumn> sortModels)
        {
            var expression = source.Expression;
            int count = 0;
            foreach (var item in sortModels)
            {
                var parameter = Expression.Parameter(typeof(T), "x");
                var selector = Expression.PropertyOrField(parameter, item.Field);
                var method = item.Sort.Direction == DataTables.AspNet.Core.SortDirection.Descending ?
                    (count == 0 ? "OrderByDescending" : "ThenByDescending") :
                    (count == 0 ? "OrderBy" : "ThenBy");
                expression = Expression.Call(typeof(Queryable), method,
                    new Type[] { source.ElementType, selector.Type },
                    expression, Expression.Quote(Expression.Lambda(selector, parameter)));
                count++;
            }
            return count > 0 ? source.Provider.CreateQuery<T>(expression) : source;
        }

        public static bool HasClass(this HtmlAgilityPack.HtmlNode node, string className)
        {
            if (!node.HasAttributes)
            {
                return false;
            }
            return node.Attributes.Any(x => x.Name == "class" && x.Value.Contains(className));
        }

        public static string Attr(this HtmlAgilityPack.HtmlNode node, string attributeName)
        {
            if (!node.HasAttributes)
            {
                return string.Empty;
            }
            return node.Attributes.FirstOrDefault(x => x.Name == attributeName)?.Value;
        }

        public static string EmptyToNull(this string model)
        {
            if (string.IsNullOrEmpty(model))
            {
                return null;
            }
            return model;
        }

        public static int? EmptyToNull(this int? model)
        {
            if (model == -1)
            {
                return null;
            }
            return model;
        }

        public static DateTime? MakeFromDate(this DateTime? model)
        {
            if (!model.HasValue)
            {
                return model;
            }
            return new DateTime(model.Value.Year, model.Value.Month, model.Value.Day);
        }

        public static DateTime? MakeToDate(this DateTime? model)
        {
            if (!model.HasValue)
            {
                return model;
            }
            return new DateTime(model.Value.Year, model.Value.Month, model.Value.Day).AddHours(23).AddMinutes(59).AddSeconds(59).AddMilliseconds(900);
        }

        public static bool Implements<I>(this Type type, I @interface) where I : class
        {
            if (((@interface as Type) == null) || !(@interface as Type).IsInterface)
                throw new ArgumentException("Only interfaces can be 'implemented'.");

            return (@interface as Type).IsAssignableFrom(type);
        }
    }
}
