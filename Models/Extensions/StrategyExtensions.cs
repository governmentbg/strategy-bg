using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Extensions
{
    public static class StrategyExtensions
    {
        public static string ValidToText(this DateTime model)
        {
            if (model.Year - DateTime.Now.Year > 75)
            {
                return "Не е указан срок";
            }
            else
            {
                return model.ToString(GlobalConstants.DateFormat);
            }
        }
    }
}
