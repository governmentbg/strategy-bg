using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Domain.Extensions
{
    /// <summary>
    /// Разширения на методите на LINQ
    /// </summary>
    public static class LinqExtension
    {
        /// <summary>
        /// Създава SelectList от колекция
        /// </summary>
        /// <typeparam name="TSource">Тип на колекцията</typeparam>
        /// <typeparam name="TValue">Тип на стойността на елементите</typeparam>
        /// <typeparam name="TText">Тип на имената на елементите</typeparam>
        /// <param name="source">Изходна колекция</param>
        /// <param name="dataValueField">Стойност на елемента</param>
        /// <param name="dataTextField">Име на елемента</param>
        /// <returns></returns>
        public static SelectList ToSelectList<TSource, TValue, TText>(
        this IEnumerable<TSource> source,
        Expression<Func<TSource, TValue>> dataValueField,
        Expression<Func<TSource, TText>> dataTextField)
        {
            return ToSelectList(source, dataValueField, dataTextField, null);
        }

        /// <summary>
        /// Създава SelectList от колекция
        /// </summary>
        /// <typeparam name="TSource">Тип на колекцията</typeparam>
        /// <typeparam name="TValue">Тип на стойността на елементите</typeparam>
        /// <typeparam name="TText">Тип на имената на елементите</typeparam>
        /// <param name="source">Изходна колекция</param>
        /// <param name="dataValueField">Стойност на елемента</param>
        /// <param name="dataTextField">Име на елемента</param>
        /// <param name="selected">Избран елемент</param>
        /// <returns></returns>
        public static SelectList ToSelectList<TSource, TValue, TText>(
         this IEnumerable<TSource> source,
         Expression<Func<TSource, TValue>> dataValueField,
         Expression<Func<TSource, TText>> dataTextField,
            object selected)
        {
            if (source == null)
            {
                return new SelectList(new List<SelectListItem>());
            }
            string dataName = ExpressionHelper.GetExpressionText(dataValueField);
            string textName = ExpressionHelper.GetExpressionText(dataTextField);
            return new SelectList(source, dataName, textName, selected);
        }

        /// <summary>
        /// Маркира определен елемент, като избран
        /// </summary>
        /// <typeparam name="TSource">Тип на колекцията</typeparam>
        /// <param name="source">Изходна колекция</param>
        /// <param name="selected">Елемент, който да бъде избран</param>
        /// <returns></returns>
        public static SelectList SetSelected<TSource>(
        this IEnumerable<TSource> source, object selected)
        {
            if (source == null)
            {
                return new SelectList(new List<SelectListItem>());
            }
            return new SelectList(source, "Value", "Text", selected);
        }

        /// <summary>
        /// Добавя "Изберете" в SelectList, 
        /// стойността му по подразбиране е -1
        /// </summary>
        /// <param name="source">Изходна колекция</param>
        /// <param name="allText">Текст, по подразбиране "Изберете"</param>
        /// <param name="allValue">Стойност, по подразбиране -1</param>
        /// <returns></returns>
        public static IEnumerable<SelectListItem> AddAllItem(
         this IEnumerable<SelectListItem> source, string allText = "Изберете", string allValue = "-1")
        {
            var allList = new List<SelectListItem>();
            allList.Add(new SelectListItem() { Text = allText, Value = allValue });
            return allList.Union(source);
        }

        /// <summary>
        /// Добавяне на елемент
        /// </summary>
        /// <param name="source">Изходна колекция</param>
        /// <param name="Text">Име на елемента</param>
        /// <param name="Value">Стойност на елемента</param>
        /// <returns></returns>
        public static IEnumerable<SelectListItem> AppendItem(
         this IEnumerable<SelectListItem> source, string Text, string Value)
        {
            var newList = new List<SelectListItem>();
            newList.Add(new SelectListItem() { Text = Text, Value = Value });
            return source.Union(newList);
        }

        /// <summary>
        /// Проверява, дали колекцията е празна
        /// </summary>
        /// <typeparam name="T">Тип на колекцията</typeparam>
        /// <param name="source">Изходна колекция</param>
        /// <returns></returns>
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
                var parameter = Expression.Parameter(source.ElementType, "x");
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

        /// <summary>
        /// Търсене в DataTables
        /// </summary>
        /// <typeparam name="T">Тип на изходните данни</typeparam>
        /// <param name="source">Пълен сет данни</param>
        /// <param name="searchModel">Модел с колони, по които се търси</param>
        /// <param name="query">Стойност на полето за търсене</param>
        /// <returns></returns>
        public static IQueryable<T> SearchFor<T>(this IQueryable<T> source, IEnumerable<DataTables.AspNet.Core.IColumn> searchModel, string query)
        {
            if (searchModel?.Count() == 0 || String.IsNullOrEmpty(query))
            {
                return source;
            }

            var parameter = Expression.Parameter(source.ElementType, "x");
            Expression predicate = Expression.Constant(false, typeof(Boolean));
            string lowerQuery = query.ToLower();

            foreach (var item in searchModel)
            {   
                var selector = Expression.PropertyOrField(parameter, item.Field);
                Expression filter = Expression.Call(selector, typeof(string).GetMethod("ToString", Type.EmptyTypes));
                filter = Expression.Call(filter, typeof(string).GetMethod("ToLower", System.Type.EmptyTypes));
                filter = Expression.Call(filter, typeof(string).GetMethod("Contains", new Type[] { typeof(string) }), Expression.Constant(lowerQuery));
                predicate = Expression.OrElse(predicate, filter);
            }

            MethodCallExpression whereCallExpression = Expression.Call(
                typeof(Queryable),
                "Where",
                new Type[] { source.ElementType },
                source.Expression,
                Expression.Lambda<Func<T, bool>>(predicate, new ParameterExpression[] { parameter }));

            return source.Provider.CreateQuery<T>(whereCallExpression);
        }
    }
}
