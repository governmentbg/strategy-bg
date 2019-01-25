using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Contracts;
using System.Threading.Tasks;

namespace Domain.ViewComponents
{
    [ViewComponent]
    public class FileListViewComponent : ViewComponent
    {
        private readonly ICommonService service;

        public FileListViewComponent(ICommonService _service)
        {
            service = _service;
        }

        public async Task<IViewComponentResult> InvokeAsync(int sourceType, int sourceId)
        {
            var model = await service.FileCdn_GetList(sourceType, sourceId).ToListAsync();

            return View(model);
        }
    }
}
