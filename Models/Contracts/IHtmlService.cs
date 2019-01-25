using System;
using Models.Context;


namespace Models.Contracts
{
    public interface IHtmlService
    {
        String HtmlAddAnchours(string htmlString);
        Page SelectPageByID(int pageId);
        string AddTags(string html, int tagNumber);
        string AddTagsLinks(string html);

    }
}
