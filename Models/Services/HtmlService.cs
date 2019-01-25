using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Models.Context;
using Models.Contracts;
using Models.ViewModels;

namespace Models.Services
{
    public class HtmlService : IHtmlService
    {
        private readonly MainContext db;
        public HtmlService(MainContext _db)
        {
            db = _db;
        }

        public String HtmlAddAnchours(string htmlString)
        {
            string pageHTML = "";


            return pageHTML;
        }


        public Page SelectPageByID(int pageId)
        {
            Page page = db.Pages.Where(x => x.Id == pageId).FirstOrDefault();

            page.Content = AddTags(page.Content, 0);
            page.Content = AddTagsLinks(page.Content);
            return page;
        }

        public string AddTags(string html, int tagNumber)
        {
            if (html.IndexOf("<p>") < 0)
            {
                return html;
            }
            else
            {
                int pos = html.IndexOf("<p>");

                string beforeP = html.Substring(0, pos);
                string afterP = html.Remove(0, pos + 3);

                return String.Format("{0}<a id=\"TAG{1}\" /><P>{2}", beforeP, tagNumber.ToString(), AddTags(afterP, tagNumber + 1));
            };
        }

        public string AddTagsLinks(string html)
        {
            if (html.IndexOf("<a id=\"TAG") < 0)
            {
                return html;
            }
            else
            {
                int pos = html.IndexOf("<a id=\"TAG");
                string tagNumber = html.Remove(0, pos + 10);
                tagNumber = tagNumber.Substring(0, tagNumber.IndexOf("\""));


                string beforeP = html.Substring(0, pos) + "<a id=\"LinkTag" + tagNumber + "\" href=\"#TAG" + tagNumber + "\">Take Position</a>";
                string afterP = html.Remove(0, pos + 14 + tagNumber.Length);
                string tag = html.Substring(pos, 14 + tagNumber.Length);
                return beforeP + tag + AddTagsLinks(afterP);
            };
        }

    }
}
