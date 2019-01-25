using System;
using System.Collections.Generic;
using System.Text;
using Models.Contracts;

namespace Models
{
    public static class LangExtensions
    {
        public static string GetName(this IHaveLangNames model, string lang)
        {
            switch (lang)
            {
                case GlobalConstants.DefaultLang:
                    return model.NameBG;
                default:
                    return model.NameEN;
            }
        }
    }
}
