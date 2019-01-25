using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace WebCommon
{
	public class CommonConstants
	{
        public class Auth
        {
            public const string ExternalScheme = "external";
        }
		public static IEnumerable<SelectListItem> EmptySelectList()
		{
			return new List<SelectListItem>();
		}
	}
}
