using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;

namespace WebCommon.TagHelpers
{
    [HtmlTargetElement("menuitem", Attributes = "menu")]
    public class MenuItemTagHelper : TagHelper
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public MenuItemTagHelper(IHttpContextAccessor _httpContextAccessor)
        {
            httpContextAccessor = _httpContextAccessor;
        }

        [HtmlAttributeName("menu")]
        public string DataMenuItem { get; set; }

        [HtmlAttributeName("roles")]
        public string Roles { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            try
            {
                bool userOk = true;
                if (!string.IsNullOrEmpty(this.Roles))
                {
                    userOk = false;
                    var currentUser = httpContextAccessor.HttpContext.User;
                    
                    if(currentUser != null)
                    {
                        foreach (var role in this.Roles.Split(','))
                        {
                            if (currentUser.IsInRole(role))
                            {
                                userOk = true;
                                break;
                            }
                        }
                    }
                    
                }
                if (userOk)
                {
                    var content = output.GetChildContentAsync().Result.GetContent();

                    output.TagName = "li";
                    output.Attributes.Add("data-menuitem", DataMenuItem);
                    output.Content.AppendHtml(content);
                }
                else
                {
                    output.SuppressOutput();
                }
            }
            catch (Exception ex)
            {
                //ErrorHelper.WriteToLog("TextBoxTagHelper.cs", ex);
            }
            base.Process(context, output);
        }

    }
}
