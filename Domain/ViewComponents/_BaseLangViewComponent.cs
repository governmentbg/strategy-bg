using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Domain.ViewComponents
{
    public abstract class BaseLangViewComponent : ViewComponent
    {
        private string _currentLang;
        protected string GetCurrentLang
        {
            get
            {
                if (string.IsNullOrEmpty(_currentLang))
                {
                    var requestCulture = Request.HttpContext.Features.Get<IRequestCultureFeature>();
                    _currentLang = requestCulture.RequestCulture.UICulture.TwoLetterISOLanguageName;

                }
                return _currentLang;
            }
        }
        protected int Lang
        {
            get
            {
                return GlobalConstants.GetLanguageId(GetCurrentLang);
            }
        }
    }
}
